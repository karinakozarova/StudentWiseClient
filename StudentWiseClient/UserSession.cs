using System;
using System.Linq;
using System.Threading.Tasks;
using System.Net;

namespace StudentWiseApi
{
    /// <summary>
    /// Represents a session of an authenticated user.
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
        /// Invalidates this session.
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
                throw new Exception(Server.UnexpectedStatus(response.StatusCode));
        }
    }
}
