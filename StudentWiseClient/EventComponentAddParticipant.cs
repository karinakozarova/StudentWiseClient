using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentWiseApi;


namespace StudentWiseClient
{
    public partial class EventComponentAddParticipant : UserControl
    {
        public EventComponentAddParticipant()
        {
            InitializeComponent();
            this.BorderStyle = BorderStyle.FixedSingle;
        }

        public Event CurrentEvent
        {
            get;
            set;
        }
        public UserSession Session
        {
            set;
            get;
        }

        public int Id
        {
            set;
            get;
        }

        public User Creator
        {
            get;
            set;
        }

        public void SetAllNeededProperties(int id, User creator, UserSession session, String title, String description, EventType type, DateTime? start, DateTime? end, int points = 0)
        {
            this.SetTitle(title);
            this.SetDescription(description);
            this.SetType(type);
            this.SetDeadline(start, end);
            this.Id = id;
            this.Session = session;
            this.Creator = creator;

            if (this.Creator.Id != this.Session.Info.Id)
            {
                DeleteEventPbx.Visible = false;
            }
            else
            {
                DeleteEventPbx.Visible = true;
            }
        }
        public void SetEvent(Event eventParam)
        {
            this.CurrentEvent = eventParam;
            ReloadParticipants();
        }

        public void SetTitle(String title)
        {
            EventTitleLbl.Text = title;
        }
        public void SetDescription(String description)
        {
            EventDescriptionLbl.Text = description;
        }

        public void SetType(EventType type)
        {
            EventTypeLbl.Text = type.ToString();
        }

        public void SetDeadline(DateTime? start, DateTime? end)
        {
            EventDeadlineLbl.Text = $"from {start} untill {end}";
        }

        private void DeleteEvent()
        {
            Event.Delete(this.Id, this.Session);
            this.Parent.Controls.Remove(this);
            //this.Enabled = false;
        }

        private void ReloadParticipants()
        {
            ParticipantsCmb.Items.Clear();

            List<User> users = User.Enumerate();
            List<User> participants = CurrentEvent.Participants;
            List<User> result = users.Except(participants).ToList();


            foreach (User user in result)
            {
                ParticipantsCmb.Items.Add(user.FirstName);
            }

        }

        private void AddParticipantBtn_Click(object sender, EventArgs e)
        {
            int userID = 0;
            List<User> users = User.Enumerate();
            List<User> participants = CurrentEvent.Participants;
            List<User> result = users.Except(participants).ToList();

            foreach (User user in result)
            {

                if (ParticipantsCmb.SelectedIndex == -1) continue;
                string selected = ParticipantsCmb.SelectedItem.ToString();
                if (user.FirstName == selected)
                {
                    userID = user.Id;
                    CurrentEvent.AddParticipant(userID, this.Session);
                    ReloadParticipants();
                }
            }
        }

        private void DeleteEventPbx_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DeleteEvent();
            }
        }

        private void EventCompletePbx_Click(object sender, EventArgs e)
        {
            //When the event is mark as finished the picture box icon will change to undo icon, in order someone
            //has marked his event by mistake.
            //Should retrieve data from the server in order to check whether the event is marked as finished or not
            //and then update the picture box accordingly.

            EventCompletePbx.Image = Properties.Resources.undo_favicon;
            EventCompletePbx.BackColor = Color.DarkGreen;
        }
    }
}
