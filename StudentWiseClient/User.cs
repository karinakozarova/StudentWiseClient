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
    public class User
    {
        public int Id { get; }
        public string Email { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public DateTime CreatedAt { get; }
        public DateTime? UpdatedAt { get; }

        internal User(ParsedJson info)
        {
            Id = info.Members["id"].GetInt32();
            Email = info.Member("email")?.GetString();
            FirstName = info.Member("first_name")?.GetString();
            LastName = info.Member("last_name")?.GetString();
            CreatedAt = info.Members["created_at"].GetDateTime();
            UpdatedAt = info.Member("updated_at")?.GetDateTime(); ;
        }

        public static User Query(int id, UserSession session = null)
        {
            // Assume current session by default
            session = session ?? Server.FallbackToCurrentSession;

            var response = Server.Send(
                string.Format(Server.user_query_url, id),
                session.token,
                "GET",
                null
            );

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                var info = JsonSerializer.Deserialize<ParsedJson>(reader.ReadToEnd());

                return new User(info);
            }

            // TODO: parse the response to throw proper exceptions
            throw new Exception("Something went wrong during user querying.");
        }

        public static List<User> Enumerate(UserSession session = null)
        {
            // Assume current session by default
            session = session ?? Server.FallbackToCurrentSession;

            var response = Server.Send(
                Server.user_enumerate_url,
                session.token,
                "GET",
                null
            );

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                var doc = JsonDocument.Parse(reader.ReadToEnd());
                var result = new List<User>(doc.RootElement.GetArrayLength());

                foreach (JsonElement element in doc.RootElement.EnumerateArray())
                {
                    var info = JsonSerializer.Deserialize<ParsedJson>(element.GetRawText());
                    result.Add(new User(info));
                }

                return result;
            }

            // TODO: parse the response to throw proper exceptions
            throw new Exception("Something went wrong during user enumeration.");
        }
    }
}
