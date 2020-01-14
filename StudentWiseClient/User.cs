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
    /// <summary>
    /// Represents an account.
    /// </summary>
    public class User
    {
        public int Id { get; }
        public string Email { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public DateTime CreatedAt { get; }
        public DateTime? UpdatedAt { get; }

        /// <summary>
        /// Query information about an account.
        /// </summary>
        public static User Query(int id, UserSession session = null)
        {
            // Assume current session by default
            session = session ?? Server.FallbackToCurrentSession;

            var response = Server.Send(
                string.Format(Server.user_manage_url, id),
                session.token,
                "GET",
                null
            );

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                return new User(ParsedJson.Parse(reader.ReadToEnd()));
            }

            throw new Exception(Server.UnexpectedStatus(response.StatusCode));
        }

        /// <summary>
        /// Enumerate user accounts.
        /// </summary>
        public static List<User> Enumerate(UserSession session = null)
        {
            // Assume current session by default
            session = session ?? Server.FallbackToCurrentSession;

            var response = Server.Send(
                Server.user_url,
                session.token,
                "GET",
                null
            );

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                return ParsedJson.ParseArray(reader.ReadToEnd()).ConvertAll(e => new User(e));
            }

            throw new Exception(Server.UnexpectedStatus(response.StatusCode));
        }

        internal User(ParsedJson info)
        {
            Id = info.GetInt("id");
            Email = info.GetString("email");
            FirstName = info.GetString("first_name");
            LastName = info.GetString("last_name");
            CreatedAt = info.GetDateTime("created_at", false).Value;
            UpdatedAt = info.GetDateTime("updated_at", true);
        }
    }
}
