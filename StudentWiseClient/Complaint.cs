using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Net;

namespace StudentWiseApi
{
    public enum ComplaintStatus
    {
        In_progress,
        Received,
        Rejected,
        Resolved,
        Sent
    }

    public class Complaint
    {
        public int Id { get; }
        public string Title { get; protected set; }
        public string Description { get; protected set; }
        public User Creator { get; }
        public DateTime CreatedAt { get; }
        public DateTime UpdatedAt { get; protected set; }
        public ComplaintStatus Status { get; }

        /// <summary>
        /// Create a new complaint.
        /// </summary>
        public static Complaint Create(string title, string description = null, UserSession session = null)
        {
            // Modifiying complaints with negative IDs is reserved for creating new ones.
            return InvokeUpdate(-1,
                new
                {
                    title,
                    description
                },
                session
            );
        }

        /// <summary>
        /// Enumerate existing complaints.
        /// </summary>
        public static List<Complaint> Enumerate(UserSession session = null)
        {
            // Assume current session by default
            session = session ?? Server.FallbackToCurrentSession;

            var response = Server.Send(
                Server.complaint_url,
                session.token,
                "GET",
                null
            );

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                return ParsedJson.ParseArray(reader.ReadToEnd()).ConvertAll(c => new Complaint(c));
            }

            // TODO: parse the response to throw proper exceptions
            throw new Exception("Something went wrong during complaint enumeration.");
        }

        /// <summary>
        /// View an existing complaint by ID.
        /// </summary>
        public static Complaint Query(int complaint_id, UserSession session = null)
        {
            // Assume current session by default
            session = session ?? Server.FallbackToCurrentSession;

            var response = Server.Send(
                string.Format(Server.complaint_manage_url, complaint_id),
                session.token,
                "GET",
                null
            );

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                return new Complaint(ParsedJson.Parse(reader.ReadToEnd()));
            }

            // TODO: parse the response to throw proper exceptions
            throw new Exception("Something went wrong during complaint querying.");
        }

        /// <summary>
        /// Update information about a comlaint by ID.
        /// </summary>
        public static Complaint Modify(int complaint_id, string title, string description = null, UserSession session = null)
        {
            return InvokeUpdate(complaint_id,
                new
                {
                    title,
                    description
                },
                session
            );
        }
        
        /// <summary>
        /// Update a title of this complaint.
        /// </summary>
        public void UpdateTitle(string value, UserSession session = null)
        {
            if (value != Title)
            {
                UpdatedAt = InvokeUpdate(Id, new { title = value }, session).UpdatedAt;
                Title = value;
            }
        }

        /// <summary>
        /// Update a description of this complaint.
        /// </summary>
        public void UpdateDesctiption(string value, UserSession session = null)
        {
            if (value != Description)
            {
                UpdatedAt = InvokeUpdate(Id, new { description = value }, session).UpdatedAt;
                Description = value;
            }
        }

        /// <summary>
        /// Delete a complaint by ID.
        /// </summary>
        public static void Delete(int complaint_id, UserSession session = null)
        {
            // Assume current session by default
            session = session ?? Server.FallbackToCurrentSession;

            // Negative complaint IDs are reserved for creating new complaints.
            var response = Server.Send(
                string.Format(Server.complaint_manage_url, complaint_id),
                session.token,
                "DELETE",
                null
            );

            // TODO: parse the response to throw proper exceptions
            if (response.StatusCode != HttpStatusCode.NoContent)            
                throw new Exception("Something went wrong during complaint deletion.");
        }

        /// <summary>
        /// Delete this complaint.
        /// </summary>
        public void Delete(UserSession session = null)
        {
            Delete(Id, session);
        }

        internal static Complaint InvokeUpdate(
            int complaint_id,
            object body,
            UserSession session = null
        )
        {
            // Assume current session by default
            session = session ?? Server.FallbackToCurrentSession;

            // Negative complaint IDs are reserved for creating new complaints.
            var response = Server.Send(
                complaint_id < 0 ? Server.complaint_url : 
                    string.Format(Server.complaint_manage_url, complaint_id),
                session.token,
                complaint_id < 0 ? "POST" : "PUT",
                new
                {
                    complaint = body
                }
            );

            if (response.StatusCode == HttpStatusCode.Created || response.StatusCode == HttpStatusCode.OK)
            {
                var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                return new Complaint(ParsedJson.Parse(reader.ReadToEnd()));
            }

            // TODO: parse the response to throw proper exceptions
            throw new Exception("Something went wrong during complaint creation/modification.");
        }

        internal Complaint(ParsedJson json)
        {
            Id = json.GetMember("id", JsonValueKind.Number).GetInt32();
            Title = json.GetString("title");
            Description = json.GetString("description");
            CreatedAt = json.GetDateTime("created_at", false).Value;
            UpdatedAt = json.GetDateTime("updated_at", false).Value;
            Creator = new User(json.GetObject("creator"));
            Status = json.GetEnum<ComplaintStatus>("status");
        }
    }
}
