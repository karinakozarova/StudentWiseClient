using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net;

namespace StudentWiseClient
{
    public enum EventType
    {
        Other,
        Duty,
        Party
    }

    /// <summary>
    /// Represents an event organized by a user.
    /// </summary>
    public class Event
    {
        public int Id { get; }
        public EventType Type { get; protected set; }
        public string Title { get; protected set; }
        public string Description { get; protected set; }
        public DateTime? StartsAt { get; protected set; }
        public DateTime? FinishesAt { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }

        /// <summary>
        /// Create a new event.
        /// </summary>
        public static Event Create(
            string title,
            string description = null,
            EventType event_type = EventType.Other,
            DateTime? starts_at = null,
            DateTime? finishes_at = null,
            UserSession user = null
            )
        {
            // Updating events with negative IDs is reserved for creation of new ones
            return InvokeUpdate(-1,
                new
                {
                    title,
                    description,
                    event_type = event_type.ToString().ToLower(),
                    starts_at,
                    finishes_at
                },
                user
            );
        }

        /// <summary>
        /// Modify an existing event by ID.
        /// </summary>
        public static Event Modify(
            int event_id,
            string title,
            string description = null,
            EventType event_type = EventType.Other,
            DateTime? starts_at = null,
            DateTime? finishes_at = null,
            UserSession user = null
            )
        {
            return InvokeUpdate(
                event_id,
                new
                {
                    title,
                    description,
                    event_type = event_type.ToString().ToLower(),
                    starts_at,
                    finishes_at
                },
                user
            );
        }

        /// <summary>
        /// Open an existing event by ID.
        /// </summary>
        public static Event Query(int id, UserSession user = null)
        {
            // Assume current session by default
            user = user ?? Server.FallbackToCurrentSession;

            var response = Server.Send(
                string.Format(Server.event_query_url, id),
                user.token,
                "GET",
                null
            );

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                var eventInfo = JsonSerializer.Deserialize<ParsedJson>(reader.ReadToEnd());

                return new Event(eventInfo);
            }

            // TODO: parse the response to throw proper exceptions
            throw new Exception("Something went wrong during event querying.");
        }

        /// <summary>
        /// Delete an event by ID.
        /// </summary>
        public static void Delete(int id, UserSession user = null)
        {
            // Assume current session by default
            user = user ?? Server.FallbackToCurrentSession;

            var response = Server.Send(
                string.Format(Server.event_delete_url, id),
                user.token,
                "DELETE",
                null
            );

            // TODO: parse the response to throw proper exceptions
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception("Something went wrong during event deletion.");
        }

        /// <summary>
        /// Delete this event.
        /// </summary>
        public void Delete(UserSession user = null)
        {
            Delete(Id, user);
        }

        #region Propery updaters
        public void UpdateType(EventType value, UserSession user = null)
        {
            if (value != Type)
            {
                InvokeUpdate(Id, new { event_type = Type.ToString().ToLower() }, user);
                Type = value;
            }
        }

        public void UpdateTitle(string value, UserSession user = null)
        {
            if (value != Title)
            {
                InvokeUpdate(Id, new { title = Title }, user);
                Title = value;
            }
        }

        public void UpdateDescription(string value, UserSession user = null)
        {
            if (value != Description)
            {
                InvokeUpdate(Id, new { description = Description }, user);
                Description = value;
            }

        }
        public void UpdateStartsAt(DateTime? value, UserSession user = null)
        {
            if (value != StartsAt)
            {
                InvokeUpdate(Id, new { starts_at = StartsAt }, user);
                StartsAt = value;
            }
        }
        public void UpdateFinishesAt(DateTime? value, UserSession user = null)
        {
            if (value != FinishesAt)
            {
                InvokeUpdate(Id, new { finishes_at = FinishesAt }, user);
                FinishesAt = value;
            }
        }
        #endregion

        internal Event(ParsedJson json)
        {
            Id = json.Members["id"].GetInt32();
            Description = json.Member("description")?.GetString();
            Title = json.Member("title")?.GetString();
            StartsAt = json.Member("starts_at")?.GetDateTime();
            FinishesAt = json.Member("finishes_at")?.GetDateTime();
            CreatedAt = json.Members["created_at"].GetDateTime();
            UpdatedAt = json.Members["updated_at"].GetDateTime();

            if (Enum.TryParse(json.Member("event_type")?.GetString(), true, out EventType parsedType))
                Type = parsedType;
            else
                Type = EventType.Other;
        }

        protected static Event InvokeUpdate(
            int event_id,
            object payload,
            UserSession user = null
            )
        {
            // Assume current session by default
            user = user ?? Server.FallbackToCurrentSession;

            // Negative event IDs are reserved for creating new events.
            var response = Server.Send(
                event_id < 0 ?
                    Server.event_create_url :
                    string.Format(Server.event_update_url, event_id),
                user.token,
                event_id < 0 ? "POST" : "PUT",
                new
                {
                    // The API expects "event" which is reserved in C#
                    _event = payload
                },
                new JsonSerializerOptions
                {
                    // Fix the "event" issue
                    PropertyNamingPolicy = new FixReservedWordsNamingPolicy()
                }
            );

            if (response.StatusCode == HttpStatusCode.Created || response.StatusCode == HttpStatusCode.OK)
            {
                var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                var eventInfo = JsonSerializer.Deserialize<ParsedJson>(reader.ReadToEnd());

                return new Event(eventInfo);
            }

            // TODO: parse the response to throw proper exceptions
            throw new Exception("Something went wrong during event creation/modification.");
        }
    }

    /// <summary>
    /// A class that overwrites names in JSON to fix issues with reserved words in C#.
    /// </summary>
    internal class FixReservedWordsNamingPolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name)
        {
            switch (name)
            {
                case "_event": return "event";
            }
            return name;
        }
    }
}
