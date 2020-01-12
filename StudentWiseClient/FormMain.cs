using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentWiseApi;

namespace StudentWiseClient
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void TsBtn_Click(object sender, EventArgs e)
        { 
            int targetTabIndex = tsMain.Items.IndexOf(sender as ToolStripItem);
            tcMain.SelectTab(targetTabIndex);
        }

        private void AddEventBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            NewEvent dashboard = new NewEvent();
            dashboard.Show();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            List<Event> events = Event.Enumerate();
           

            foreach (Event ev in events)
            {
                EventComponent eventComponent = new EventComponent();
                eventComponent.SetAllNeededProperties(ev.Id, ev.Creator, Server.CurrentSession, ev.Title, ev.Description, ev.Type, ev.StartsAt, ev.FinishesAt);
                flowLayoutPanelToday.Controls.Add(eventComponent);
            }

            ReloadComplaints();
        }

        private void ReloadComplaints()
        {
            List<Complaint> complaints = Complaint.Enumerate();

            complaintsFllpnl.Controls.Clear();

            foreach (Complaint complaint in complaints)
            {
                ComplaintsComponent complaintComponent = new ComplaintsComponent();
                complaintComponent.ChangeLabels(complaint.Title, complaint.Description, complaint.Status, complaint.CreatedAt);
                complaintsFllpnl.Controls.Add(complaintComponent);
            }
        }

        private void FileComplaintBttn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(titleTbx.Text))
            {
                MessageBox.Show("Please enter a title for your complaint");
                return;
            }

            if (String.IsNullOrEmpty(descriptionTbx.Text))
            {
                MessageBox.Show("Please enter a description for your complaint");
                return;
            }

            Complaint.Create(titleTbx.Text, descriptionTbx.Text, Server.CurrentSession);
            titleTbx.Clear();
            descriptionTbx.Clear();
            ReloadComplaints();
        }
    }
}
