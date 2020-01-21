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
            NewEvent createEventDlg = new NewEvent();
            createEventDlg.ShowDialog(FormMain.Instance);
        }
    }
}
