using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net;

namespace StudentWiseApi
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
        public User Creator { get; }
        public List<User> Participants { get; }

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
                return new Event(ParsedJson.Parse(reader.ReadToEnd()));
            }

            // TODO: parse the response to throw proper exceptions
            throw new Exception("Something went wrong during event querying.");
        }

        /// <summary>
        /// Enumerate events in which you participate.
        /// </summary>
        public static List<Event> Enumerate(UserSession user = null)
        {
            // Assume current session by default
            user = user ?? Server.FallbackToCurrentSession;

            var response = Server.Send(
                Server.event_enumerate_url,
                user.token,
                "GET",
                null
            );

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                return ParsedJson.ParseArray(reader.ReadToEnd()).ConvertAll(e => new Event(e));
            }

            // TODO: parse the response to throw proper exceptions
            throw new Exception("Something went wrong during event enumeration.");
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
            if (response.StatusCode != HttpStatusCode.NoContent)
                throw new Exception("Something went wrong during event deletion.");
        }

        /// <summary>
        /// Delete this event.
        /// </summary>
        public void Delete(UserSession user = null)
        {
            Delete(Id, user);
        }

        /// <summary>
        /// Add a user as a participant of an event by ID.
        /// </summary>
        public static void AddParticipant(int event_id, int user_id, UserSession session = null)
        {
            // Assume current session by default
            session = session ?? Server.FallbackToCurrentSession;

            var response = Server.Send(
                string.Format(Server.event_add_user_url, event_id),
                session.token,
                "POST",
                new
                {
                    event_participant = new
                    {
                        participant_id = user_id
                    }
                }
            );

            // TODO: parse the response to throw proper exceptions
            if (response.StatusCode != HttpStatusCode.Created)
                throw new Exception("Something went wrong during event participant addition.");
        }

        /// <summary>
        /// Add a user as a participant if this event.
        /// </summary>
        public void AddParticipant(int user_id, UserSession session = null)
        {
            AddParticipant(Id, user_id, session);
            Participants.Add(User.Query(user_id));
        }

        /// <summary>
        /// Remove a participating user from an event by ID.
        /// </summary>
        public static void RemoveParticipant(int event_id, int user_id, UserSession session = null)
        {
            // Assume current session by default
            session = session ?? Server.FallbackToCurrentSession;

            var response = Server.Send(
                string.Format(Server.event_remove_user_url, event_id),
                session.token,
                "DELETE",
                new
                {
                    event_participant = new
                    {
                        participant_id = user_id
                    }
                }
            );

            // TODO: parse the response to throw proper exceptions
            if (response.StatusCode != HttpStatusCode.NoContent)
                throw new Exception("Something went wrong during event participant removing.");
        }

        /// <summary>
        /// Remove a participating user from this event.
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="session"></param>
        public void RemoveParticipant(int user_id, UserSession session = null)
        {
            RemoveParticipant(Id, user_id, session);
            Participants.Remove(Participants.Find(u => u.Id == user_id));
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
            Creator = new User(ParsedJson.Parse(json.Members["creator"].GetRawText()));

            if (Enum.TryParse(json.Member("event_type")?.GetString(), true, out EventType parsedType))
                Type = parsedType;
            else
                Type = EventType.Other;

            Participants = ParsedJson.ParseArray(
                json.Members["participants"].GetRawText()).ConvertAll(e => new User(e));
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
                return new Event(ParsedJson.Parse(reader.ReadToEnd()));
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
