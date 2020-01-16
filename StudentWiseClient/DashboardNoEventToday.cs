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
    public partial class DashboardNoEventToday : UserControl
    {
        public DashboardNoEventToday()
        {
            InitializeComponent();
        }

        private void AddEventBtn_Click_1(object sender, EventArgs e)
        {
            List<Form> openForms = new List<Form>();

            foreach (Form f in Application.OpenForms)
                openForms.Add(f);

            foreach (Form f in openForms)
            {
                if (f.Name == "FormMain")
                    f.Close();
            }

            NewEvent createEvent = new NewEvent();
            createEvent.Show();
        }
    }
}
