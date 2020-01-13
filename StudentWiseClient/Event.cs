﻿using System;
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
            UserSession session = null
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
                session
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
            UserSession session = null
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
                session
            );
        }

        /// <summary>
        /// Open an existing event by ID.
        /// </summary>
        public static Event Query(int id, UserSession session = null)
        {
            // Assume current session by default
            session = session ?? Server.FallbackToCurrentSession;

            var response = Server.Send(
                string.Format(Server.event_manage_url, id),
                session.token,
                "GET",
                null
            );

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                return new Event(ParsedJson.Parse(reader.ReadToEnd()));
            }

            throw new Exception(Server.UnexpectedStatus(response.StatusCode));
        }

        /// <summary>
        /// Enumerate events in which you participate.
        /// </summary>
        public static List<Event> Enumerate(UserSession session = null)
        {
            // Assume current session by default
            session = session ?? Server.FallbackToCurrentSession;

            var response = Server.Send(
                Server.event_url,
                session.token,
                "GET",
                null
            );

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                return ParsedJson.ParseArray(reader.ReadToEnd()).ConvertAll(e => new Event(e));
            }

            throw new Exception(Server.UnexpectedStatus(response.StatusCode));
        }

        /// <summary>
        /// Delete an event by ID.
        /// </summary>
        public static void Delete(int id, UserSession session = null)
        {
            // Assume current session by default
            session = session ?? Server.FallbackToCurrentSession;

            var response = Server.Send(
                string.Format(Server.event_manage_url, id),
                session.token,
                "DELETE",
                null
            );

            if (response.StatusCode != HttpStatusCode.NoContent)
                throw new Exception(Server.UnexpectedStatus(response.StatusCode));
        }

        /// <summary>
        /// Delete this event.
        /// </summary>
        public void Delete(UserSession session = null)
        {
            Delete(Id, session);
        }

        /// <summary>
        /// Add a user as a participant of an event by ID.
        /// </summary>
        public static User AddParticipant(int event_id, int user_id, UserSession session = null)
        {
            // Assume current session by default
            session = session ?? Server.FallbackToCurrentSession;

            var response = Server.Send(
                string.Format(Server.event_participant_url, event_id),
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
            
            if (response.StatusCode == HttpStatusCode.Created)
            {
                var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                var json = ParsedJson.Parse(reader.ReadToEnd());
                return new User(json.GetObject("participant"));
            }

            throw new Exception(Server.UnexpectedStatus(response.StatusCode));
        }

        /// <summary>
        /// Add a user as a participant if this event.
        /// </summary>
        public void AddParticipant(int user_id, UserSession session = null)
        {
            Participants.Add(AddParticipant(Id, user_id, session));
        }

        /// <summary>
        /// Remove a participating user from an event by ID.
        /// </summary>
        public static void RemoveParticipant(int event_id, int user_id, UserSession session = null)
        {
            // Assume current session by default
            session = session ?? Server.FallbackToCurrentSession;

            var response = Server.Send(
                string.Format(Server.event_participant_url, event_id),
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

            if (response.StatusCode != HttpStatusCode.NoContent)
                throw new Exception(Server.UnexpectedStatus(response.StatusCode));
        }

        /// <summary>
        /// Remove a participating user from this event.
        /// </summary>
        public void RemoveParticipant(int user_id, UserSession session = null)
        {
            RemoveParticipant(Id, user_id, session);
            Participants.Remove(Participants.Find(u => u.Id == user_id));
        }

        #region Propery updaters
        public void UpdateType(EventType value, UserSession session = null)
        {
            if (value != Type)
            {
                UpdatedAt = InvokeUpdate(Id, new { event_type = value.ToString().ToLower() }, session).UpdatedAt;
                Type = value;
            }
        }

        public void UpdateTitle(string value, UserSession session = null)
        {
            if (value != Title)
            {
                UpdatedAt = InvokeUpdate(Id, new { title = value }, session).UpdatedAt;
                Title = value;
            }
        }

        public void UpdateDescription(string value, UserSession session = null)
        {
            if (value != Description)
            {
                UpdatedAt = InvokeUpdate(Id, new { description = value }, session).UpdatedAt;
                Description = value;
            }

        }
        public void UpdateStartsAt(DateTime? value, UserSession session = null)
        {
            if (value != StartsAt)
            {
                UpdatedAt = InvokeUpdate(Id, new { starts_at = value }, session).UpdatedAt;
                StartsAt = value;
            }
        }
        public void UpdateFinishesAt(DateTime? value, UserSession session = null)
        {
            if (value != FinishesAt)
            {
                UpdatedAt = InvokeUpdate(Id, new { finishes_at = value }, session).UpdatedAt;
                FinishesAt = value;
            }
        }
        #endregion

        internal Event(ParsedJson json)
        {
            Id = json.GetMember("id", JsonValueKind.Number).GetInt32();
            Description = json.GetString("description");
            Title = json.GetString("title");
            StartsAt = json.GetDateTime("starts_at", true);
            FinishesAt = json.GetDateTime("finishes_at", true);
            CreatedAt = json.GetDateTime("created_at", false).Value;
            UpdatedAt = json.GetDateTime("updated_at", false).Value;
            Creator = new User(json.GetObject("creator"));
            Type = json.GetEnum<EventType>("event_type");
            Participants = json.GetArray("participants").ConvertAll(e => new User(e));
        }

        protected static Event InvokeUpdate(
            int event_id,
            object payload,
            UserSession session = null
            )
        {
            // Assume current session by default
            session = session ?? Server.FallbackToCurrentSession;

            // Negative event IDs are reserved for creating new events.
            var response = Server.Send(
                event_id < 0 ?
                    Server.event_url :
                    string.Format(Server.event_manage_url, event_id),
                session.token,
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

            throw new Exception(Server.UnexpectedStatus(response.StatusCode));
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
