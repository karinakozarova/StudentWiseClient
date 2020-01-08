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

    /// <summary>
    /// A generic class to hold parsed JSON and access its members.
    /// </summary>
    internal class ParsedJson
    {
        [JsonExtensionData]
        public Dictionary<string, JsonElement> Members { get; set; }
        public JsonElement? Member(string name)
        {
            if (Members.TryGetValue(name, out JsonElement result) && result.ValueKind != JsonValueKind.Null)
                return result;

            return null;
        }
    }

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

        public void SetType(EventType value, UserSession user = null)
        {
            if (value != Type)
            {
                InvokeUpdate(Id, new { event_type = Type.ToString().ToLower() }, user);
                Type = value;
            }
        }

        public void SetTitle(string value, UserSession user = null)
        {
            if (value != Title)
            {
                InvokeUpdate(Id, new { title = Title }, user);
                Title = value;
            }
        }

        public void SetDescription(string value, UserSession user = null)
        {
            if (value != Description)
            {
                InvokeUpdate(Id, new { description = Description }, user);
                Description = value;
            }

        }
        public void SetStartsAt(DateTime? value, UserSession user = null)
        {
            if (value != StartsAt)
            {
                InvokeUpdate(Id, new { starts_at = StartsAt }, user);
                StartsAt = value;
            }
        }
        public void SetFinishesAt(DateTime? value, UserSession user = null)
        {
            if (value != FinishesAt)
            {
                InvokeUpdate(Id, new { finishes_at = FinishesAt }, user);
                FinishesAt = value;
            }
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

    }

    /// <summary>
    /// Represents an authenticated user.
    /// </summary>
    public class UserSession
    {
        internal readonly string token;

        internal UserSession(string authToken)
        {
            token = authToken;
        }

        /// <summary>
        /// Invalidates current session.
        /// </summary>
        public void Logout()
        {
            var response = Server.Send(
                Server.user_logout_url,
                token,
                "DELETE",
                null
            );

            if (response.StatusCode != HttpStatusCode.OK)
            {
                // TODO: or maybe we should ignore logout errors?
                throw new Exception("Something went wrong during logging out.");
            }
        }
    }

    /// <summary>
    /// Represents a server that logs in users and creates new accounts.
    /// </summary>
    public class Server
    {
        private const string base_url = "https://studentwise.herokuapp.com/api/v1";
        internal const string user_create_url = base_url + "/users";
        internal const string user_login_url = base_url + "/users/login";        
        internal const string user_logout_url = base_url + "/users/logout";
        internal const string event_create_url = base_url + "/events";
        internal const string event_query_url = base_url + "/events/{0}";
        internal const string event_update_url = base_url + "/events/{0}";
        internal const string event_delete_url = base_url + "/events/{0}";

        static internal HttpWebResponse Send(string url, string token, string method, object data, JsonSerializerOptions options = null)
        {
            WebRequest request = WebRequest.Create(url);

            request.Method = method;
            request.ContentType = "application/json";

            if (token != null)
                request.Headers.Add("authorization", token);

            if (data != null)
                using (var stream = new StreamWriter(request.GetRequestStream()))
                    stream.Write(JsonSerializer.Serialize(data, options));

            return (HttpWebResponse)request.GetResponse();
        }

        /// <summary>
        /// Methods that act on behalf of a user assume this session 
        /// if the caller does not specify a user session explicitly.
        /// </summary>
        static public UserSession CurrentSession { get; set; }

        static internal UserSession FallbackToCurrentSession
        {
            get
            {
                if (CurrentSession != null)
                    return CurrentSession;
                else
                    throw new ArgumentNullException("Current user session is not assigned.");
            } 
        }

        /// <summary>
        /// Authenticate the user on the server.
        /// </summary>
        /// <returns>A new user session.</returns>
        static public UserSession Login(string email, string password)
        {
            var response = Send(
                user_login_url,
                null,
                "POST",
                new
                {
                    user = new
                    {
                        email,
                        password
                    }
                }
            ) ;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return new UserSession(response.Headers.Get("authorization"));
            }

            // TODO: parse the response to throw proper exceptions
            throw new Exception("Something went wrong during authentication.");
        }

        /// <summary>
        /// Create a new user account on the server.
        /// </summary>
        /// <returns>A new user session.</returns>
        static public UserSession CreateUser(string email, string first_name, string last_name, string password)
        {
            var response = Send(
                user_create_url,
                null,
                "POST",
                new
                {
                    user = new
                    {
                        email,
                        first_name,
                        last_name,
                        password
                    }
                }
            );

            if (response.StatusCode == HttpStatusCode.Created)
            {
                return new UserSession(response.Headers.Get("authorization"));
            }

            // TODO: parse the response to throw proper exceptions
            throw new Exception("Something went wrong during account creation.");
        }
    }
}
