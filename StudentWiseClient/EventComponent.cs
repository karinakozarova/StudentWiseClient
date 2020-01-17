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
    public partial class EventComponent : UserControl
    {
        public EventComponent()
        {
            InitializeComponent();
            this.BorderStyle = BorderStyle.FixedSingle;
        }

        public UserSession Session
        {
            get;
            set;
        }

        public int Id
        {
            set;
            get;
        }
        public Event CurrentEvent
        {
            set;
            get;
        }

        public User Creator
        {
            get;
            set;
        }

        public void SetEvent(Event ev)
        {
            CurrentEvent = ev;
            if (CurrentEvent.Participants.Contains(Server.CurrentSession.Info))
            {
                if (CurrentEvent.Status == EventStatus.Pending)
                {
                    EventCompletePbx.Image = Properties.Resources.undo_favicon;
                }
                else if (CurrentEvent.Status == EventStatus.Finished)
                {
                    EventCompletePbx.Image = Properties.Resources.kisspng_check_mark_symbol_icon_black_checkmark_5a76d35a732948_8416047115177367944717;
                }
                else
                {
                    EventCompletePbx.Visible = false;
                }
            }
        }
        public void SetAllNeededProperties(int id, User creator, UserSession session, String title, String description, EventType type, DateTime? start, DateTime? end, int points = 0)
        {
            this.SetTitle(title);
            this.SetDescription(description);
            this.SetType(type);
            this.SetDeadline(start, end);
            this.SetEventPoints();
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
            if(start == null && end == null)
            {
                EventDeadlineLbl.Text = "";
            }else if(start == null)
            {
                EventDeadlineLbl.Text = $"Until {end}";
            }else if(end == null)
            {
                EventDeadlineLbl.Text = $"From {start}";
            }
            else
            {
                EventDeadlineLbl.Text = $"From {start} untill {end}";
            }
            
        }

        public void SetEventPoints(int points = 0)
        {
            EventPointsLbl.Text = points.ToString();
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
            if (CurrentEvent.Participants.Contains(Server.CurrentSession.Info))
            {
                if (CurrentEvent.Status == EventStatus.Pending)
                {
                    CurrentEvent.MarkAsFinished();
                    EventCompletePbx.Image = Properties.Resources.undo_favicon;
                }
                else if (CurrentEvent.Status == EventStatus.Finished)
                {
                    Event.MarkEvent(CurrentEvent.Id, false);
                    EventCompletePbx.Image = Properties.Resources.kisspng_check_mark_symbol_icon_black_checkmark_5a76d35a732948_8416047115177367944717;
                }
            }

        }

        private void DeleteEvent()
        {
            Event.Delete(this.Id, this.Session);

            this.Parent.Controls.Remove(this);

            //this.Enabled = false;
        }
        
    }
}
