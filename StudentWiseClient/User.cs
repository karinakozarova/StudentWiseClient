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

        internal User(ParsedJson info)
        {
            Id = info.Members["id"].GetInt32();
            Email = info.Member("email")?.GetString();
            FirstName = info.Member("first_name")?.GetString();
            LastName = info.Member("last_name")?.GetString();
            CreatedAt = info.Members["created_at"].GetDateTime();
            UpdatedAt = info.Member("updated_at")?.GetDateTime(); ;
        }

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

            // TODO: parse the response to throw proper exceptions
            throw new Exception("Something went wrong during user querying.");
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

            // TODO: parse the response to throw proper exceptions
            throw new Exception("Something went wrong during user enumeration.");
        }
    }
}
