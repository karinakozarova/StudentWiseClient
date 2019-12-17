using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Net;

namespace StudentWiseClient
{
    /// <summary>
    /// Represents an authenticated user.
    /// </summary>
    class UserSession
    {
        private readonly string token;

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
    class Server
    {
        private const string base_url = "https://studentwise.herokuapp.com/api/v1";
        internal const string user_create_url = base_url + "/users";
        internal const string user_login_url = base_url + "/users/login";        
        internal const string user_logout_url = base_url + "/users/logout";
        
        static internal HttpWebResponse Send(string url, string token, string method, object data)
        {
            WebRequest request = WebRequest.Create(url);

            request.Method = method;
            request.ContentType = "application/json";

            if (token != null)
                request.Headers.Add("authorization", token);

            if (data != null)
                using (var stream = new StreamWriter(request.GetRequestStream()))
                    stream.Write(JsonSerializer.Serialize(data));

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
