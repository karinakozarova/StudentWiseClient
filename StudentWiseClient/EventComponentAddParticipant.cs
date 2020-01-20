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
        public EventComponentAddParticipant(Event ev)
        {
            InitializeComponent();
            Self = ev;
            SetAllNeededProperties();
            SetEvent();
        }

        public Event Self { get; private set; }        

        public void SetAllNeededProperties()
        {
            EventTitleLbl.Text = Self.Title;
            EventDescriptionLbl.Text = Self.Description ?? "No description provided.";
            EventTypeLbl.Text = Self.Kind.ToString();
            SetDeadline(Self.StartsAt, Self.FinishesAt);

            DeleteEventPbx.Visible = Self.Creator == Server.CurrentSession.Info;
        }
        public void SetEvent()
        {
            if (Self.Participants.Contains(Server.CurrentSession.Info))
            {
                switch (Self.Status)
                {
                    case EventStatus.Pending:
                        EventCompletePbx.Image = Properties.Resources.undo_favicon;
                        break;

                    case EventStatus.Finished:
                        EventCompletePbx.Image = Properties.Resources.kisspng_check_mark_symbol_icon_black_checkmark_5a76d35a732948_8416047115177367944717;
                        break;

                    default:
                        EventCompletePbx.Visible = false;
                        break;
                }
            }

            ReloadParticipants();
        }

        public void SetDeadline(DateTime? start, DateTime? end)
        {
            string result = "";

            if (start.HasValue)
                result += $"From {start} ";

            if (end.HasValue)
                result += $"Until {end}";

            EventDeadlineLbl.Text = result;
        }

        private void DeleteEvent()
        {
            Self.Delete();
            Parent.Controls.Remove(this);
        }

        private void ReloadParticipants()
        {
            ParticipantsCmb.Items.Clear();

            List<User> users = User.Enumerate();
            List<User> participants = Self.Participants;
            List<User> result = users.Except(participants).ToList();


            foreach (User user in result)
                ParticipantsCmb.Items.Add(user.FirstName);
        }

        private void AddParticipantBtn_Click(object sender, EventArgs e)
        {
            int userID = 0;
            List<User> users = User.Enumerate();
            List<User> participants = Self.Participants;
            List<User> result = users.Except(participants).ToList();

            foreach (User user in result)
            {
                if (ParticipantsCmb.SelectedIndex == -1) continue;
                string selected = ParticipantsCmb.SelectedItem.ToString();
                if (user.FirstName == selected)
                {
                    userID = user.Id;
                    Self.AddParticipant(userID);
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
            if (Self.Participants.Contains(Server.CurrentSession.Info))
            {
                if (Self.Status == EventStatus.Pending)
                {
                    Self.MarkAsFinished();
                    EventCompletePbx.Image = Properties.Resources.undo_favicon;
                }
                else if (Self.Status == EventStatus.Finished)
                {
                    Self.MarkAsPending(); 
                    EventCompletePbx.Image = Properties.Resources.kisspng_check_mark_symbol_icon_black_checkmark_5a76d35a732948_8416047115177367944717;
                }
            }
        }
    }
}
