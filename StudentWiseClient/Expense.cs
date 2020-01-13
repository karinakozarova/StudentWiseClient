﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Net;

namespace StudentWiseApi
{
    class Expense
    {
        public int Id { get; }
        public string Name { get; protected set; }
        public decimal Price { get; protected set; }
        public int Amount { get; protected set; }
        public string Notes { get; protected set; }
        public User Creator { get; }
        public DateTime CreatedAt { get; }
        public DateTime UpdatedAt { get; protected set; }
        public List<User> Participants { get; }

        /// <summary>
        /// Create a new expense.
        /// </summary>
        public static Expense Create(string name, decimal price, int amount = 1, string notes = null, UserSession session = null)
        {
            // Modifiying expenses with negative IDs is reserved for creating new ones.
            return InvokeUpdate(-1,
                new
                {
                    name,
                    notes,
                    price,
                    amount
                },
                session
            );
        }

        /// <summary>
        /// Enumerate existing expenses.
        /// </summary>
        public static List<Expense> Enumerate(UserSession session = null)
        {
            // Assume current session by default
            session = session ?? Server.FallbackToCurrentSession;

            var response = Server.Send(
                Server.expense_url,
                session.token,
                "GET",
                null
            );

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                return ParsedJson.ParseArray(reader.ReadToEnd()).ConvertAll(e => new Expense(e));
            }

            throw new Exception(Server.UnexpectedStatus(response.StatusCode));
        }

        /// <summary>
        /// View an existing expense by ID.
        /// </summary>
        public static Expense Query(int expense_id, UserSession session = null)
        {
            // Assume current session by default
            session = session ?? Server.FallbackToCurrentSession;

            var response = Server.Send(
                string.Format(Server.expense_manage_url, expense_id),
                session.token,
                "GET",
                null
            );

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                return new Expense(ParsedJson.Parse(reader.ReadToEnd()));
            }

            throw new Exception(Server.UnexpectedStatus(response.StatusCode));
        }

        /// <summary>
        /// Update information about an expense by ID.
        /// </summary>
        public static Expense Modify(int expense_id, string name, decimal price, int amount = 1, string notes = null, UserSession session = null)
        {
            return InvokeUpdate(expense_id,
                new
                {
                    name,
                    notes,
                    price,
                    amount
                },
                session
            );
        }

        /// <summary>
        /// Update the name of this expense.
        /// </summary>
        public void UpdateName(string value, UserSession session = null)
        {
            if (value != Name)
            {
                UpdatedAt = InvokeUpdate(Id, new { name = value }, session).UpdatedAt;
                Name = value;
            }
        }

        /// <summary>
        /// Update the price for this expense.
        /// </summary>
        public void UpdatePrice(decimal value, UserSession session = null)
        {
            if (value != Price)
            {
                UpdatedAt = InvokeUpdate(Id, new { price = value }, session).UpdatedAt;
                Price = value;
            }
        }

        /// <summary>
        /// Update the amount for this expense.
        /// </summary>
        public void UpdateAmount(int value, UserSession session = null)
        {
            if (value != Amount)
            {
                UpdatedAt = InvokeUpdate(Id, new { amount = value }, session).UpdatedAt;
                Amount = value;
            }
        }

        /// <summary>
        /// Update the note for this expense.
        /// </summary>
        public void UpdateNotes(string value, UserSession session = null)
        {
            if (value != Notes)
            {
                UpdatedAt = InvokeUpdate(Id, new { notes = value }, session).UpdatedAt;
                Notes = value;
            }
        }

        /// <summary>
        /// Delete an expense by ID.
        /// </summary>
        public static void Delete(int expense_id, UserSession session = null)
        {
            // Assume current session by default
            session = session ?? Server.FallbackToCurrentSession;

            // Negative expense IDs are reserved for creating new expenses.
            var response = Server.Send(
                string.Format(Server.expense_manage_url, expense_id),
                session.token,
                "DELETE",
                null
            );

            if (response.StatusCode != HttpStatusCode.NoContent)
                throw new Exception(Server.UnexpectedStatus(response.StatusCode));
        }

        /// <summary>
        /// Delete this expense.
        /// </summary>
        public void Delete(UserSession session = null)
        {
            Delete(Id, session);
        }

        /// <summary>
        /// Add a user as a participant of an expense by ID.
        /// </summary>
        public static User AddParticipant(int expense_id, int user_id, UserSession session = null)
        {
            // Assume current session by default
            session = session ?? Server.FallbackToCurrentSession;

            var response = Server.Send(
                string.Format(Server.expense_participant_url, expense_id),
                session.token,
                "POST",
                new
                {
                    expense_participant = new
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
        /// Add a user as a participant if this expense.
        /// </summary>
        public void AddParticipant(int user_id, UserSession session = null)
        {
            Participants.Add(AddParticipant(Id, user_id, session));
        }

        /// <summary>
        /// Remove a participating user from an expense by ID.
        /// </summary>
        public static void RemoveParticipant(int expense_id, int user_id, UserSession session = null)
        {
            // Assume current session by default
            session = session ?? Server.FallbackToCurrentSession;

            var response = Server.Send(
                string.Format(Server.expense_participant_url, expense_id),
                session.token,
                "DELETE",
                new
                {
                    expense_participant = new
                    {
                        participant_id = user_id
                    }
                }
            );

            if (response.StatusCode != HttpStatusCode.NoContent)
                throw new Exception(Server.UnexpectedStatus(response.StatusCode));
        }

        /// <summary>
        /// Remove a participating user from this expense.
        /// </summary>
        public void RemoveParticipant(int user_id, UserSession session = null)
        {
            RemoveParticipant(Id, user_id, session);
            Participants.Remove(Participants.Find(u => u.Id == user_id));
        }

        internal static Expense InvokeUpdate(
            int expense_id,
            object body,
            UserSession session = null
        )
        {
            // Assume current session by default
            session = session ?? Server.FallbackToCurrentSession;

            // Negative expense IDs are reserved for creating new expenses.
            var response = Server.Send(
                expense_id < 0 ? Server.expense_url:
                    string.Format(Server.expense_manage_url, expense_id),
                session.token,
                expense_id < 0 ? "POST" : "PUT",
                new
                {
                    expense = body
                }
            );

            if (response.StatusCode == HttpStatusCode.Created || response.StatusCode == HttpStatusCode.OK)
            {
                var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                return new Expense(ParsedJson.Parse(reader.ReadToEnd()));
            }

            throw new Exception(Server.UnexpectedStatus(response.StatusCode));
        }

        internal Expense(ParsedJson json)
        {
            Id = json.GetMember("id", JsonValueKind.Number).GetInt32();
            Name = json.GetString("name");
            Notes = json.GetString("notes");
            Price = Convert.ToDecimal(json.GetString("price"));
            Amount = json.GetMember("amount", JsonValueKind.Number).GetInt32();
            CreatedAt = json.GetDateTime("created_at", false).Value;
            UpdatedAt = json.GetDateTime("updated_at", false).Value;
            Creator = new User(json.GetObject("creator"));
            Participants = json.GetArray("participants").ConvertAll(e => new User(e));
        }
    }
}
