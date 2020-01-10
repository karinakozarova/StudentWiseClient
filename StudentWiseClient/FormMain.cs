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
                EventComponent event1 = new EventComponent();
                flowLayoutPanelToday.Controls.Add(event1);
                event1.SetTitle(ev.Title);
                event1.SetDescription(ev.Description);
                event1.SetType(ev.Type);
                event1.SetDeadline(ev.StartsAt, ev.FinishesAt);
                event1.setEventPoints();
            }
        }
    }
}
