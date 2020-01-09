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
    /// Represents an authenticated user.
    /// </summary>
    public class UserSession
    {
        internal readonly string token;
        public User Info { get; }

        internal UserSession(string authToken, ParsedJson info)
        {
            token = authToken;
            Info = new User(info);
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

            if (response.StatusCode != HttpStatusCode.NoContent)
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
        internal const string user_enumerate_url = base_url + "/users";
        internal const string user_query_url = base_url + "/users/{0}";
        internal const string user_login_url = base_url + "/users/login";        
        internal const string user_logout_url = base_url + "/users/logout";
        internal const string event_create_url = base_url + "/events";
        internal const string event_enumerate_url = base_url + "/events";
        internal const string event_query_url = base_url + "/events/{0}";
        internal const string event_update_url = base_url + "/events/{0}";
        internal const string event_delete_url = base_url + "/events/{0}";

        static internal HttpWebResponse Send(string url, string token, string method, object data, JsonSerializerOptions options = null)
        {
            WebRequest request = WebRequest.Create(url);

            request.Method = method;

            if (token != null)
                request.Headers.Add("authorization", token);

            if (data != null)
            {
                request.ContentType = "application/json";
                using (var stream = new StreamWriter(request.GetRequestStream()))
                    stream.Write(JsonSerializer.Serialize(data, options));
            }

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
                var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                
                return new UserSession(
                    response.Headers.Get("authorization"),
                    ParsedJson.Parse(reader.ReadToEnd())
                );
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
                var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                
                return new UserSession(
                    response.Headers.Get("authorization"),
                    ParsedJson.Parse(reader.ReadToEnd())
                );
            }

            // TODO: parse the response to throw proper exceptions
            throw new Exception("Something went wrong during account creation.");
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

        public static ParsedJson Parse(string json, JsonSerializerOptions options = null)
        {
            return JsonSerializer.Deserialize<ParsedJson>(json, options);
        }

        public static List<ParsedJson> ParseArray(string json, JsonSerializerOptions options = null)
        {
            var root = JsonDocument.Parse(json).RootElement;
            var result = new List<ParsedJson>(root.GetArrayLength());

            foreach (JsonElement element in root.EnumerateArray())
            {
                result.Add(Parse(element.GetRawText(), options));
            }
            return result;
        }
    }
}
