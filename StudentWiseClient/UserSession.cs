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

    /// <summary>
    /// Represents an event organized by a user.
    /// </summary>
    public class Event
    {
        public int Id { get; internal set; }
        public string EventType { get; internal set; }
        public string Title { get; internal set; }
        public string Description { get; internal set; }
        public DateTime? StartsAt { get; internal set; }
        public DateTime? FinishesAt { get; internal set; }
        public DateTime CreatedAt { get; internal set; }
        public DateTime UpdatedAt { get; internal set; }
    }

    /// <summary>
    /// Represents an authenticated user.
    /// </summary>
    public class UserSession
    {
        private readonly string token;

        internal UserSession(string authToken)
        {
            token = authToken;
        }

        /// <summary>
        /// Creates a new shared event.
        /// </summary>
        public Event CreateEvent(string title, string description, string starts_at, string finishes_at)
        {
            var serializeOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = new FixReservedWordsNamingPolicy()
            };

            var response = Server.Send(
                Server.event_create_url,
                token,
                "POST",
                new
                {
                    _event = new
                    {
                        title,
                        description,
                        starts_at,
                        finishes_at
                    }
                },
                serializeOptions
            );

            if (response.StatusCode == HttpStatusCode.Created)
            {
                var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                string json = reader.ReadToEnd();
                var eventInfo = JsonSerializer.Deserialize<ParsedJson>(json, serializeOptions);

                return new Event()
                {
                    Id = eventInfo.Members["id"].GetInt32(),
                    Description = eventInfo.Member("description")?.GetString(),
                    EventType = eventInfo.Member("event_type")?.GetString(),
                    Title = eventInfo.Member("title")?.GetString(),
                    StartsAt = eventInfo.Member("starts_at")?.GetDateTime(),
                    FinishesAt = eventInfo.Member("finishes_at")?.GetDateTime(),
                    CreatedAt = eventInfo.Members["created_at"].GetDateTime(),
                    UpdatedAt = eventInfo.Members["updated_at"].GetDateTime()
                };
            }

            // TODO: parse the response to throw proper exceptions
            throw new Exception("Something went wrong during event creation.");
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
