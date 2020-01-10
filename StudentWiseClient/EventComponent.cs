using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public User Creator
        {
            get;
            set;
        }

        public void SetAllNeededProperties(int id, UserSession session, String title, String description, EventType type, DateTime? start, DateTime? end, int points = 0)
        {
            this.SetTitle(title);
            this.SetDescription(description);
            this.SetType(type);
            this.SetDeadline(start, end);
            this.setEventPoints();
            this.Id = id;
            this.Session = session;
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

        public void setEventPoints(int points = 0)
        {
            EventPointsLbl.Text = points.ToString();
        }


        private void DeleteEventPbx_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DeleteEvent();
                this.Parent.Controls.Remove(this);
            }
            else
            {
                
            }
        }

        private void EventCompletePbx_Click(object sender, EventArgs e)
        {

        }

        private void DeleteEvent()
        {
            if(this.Creator == this.Session.Info) Event.Delete(this.Id, this.Session);
        }
        
    }
}
