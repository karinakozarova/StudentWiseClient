using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentWiseClient
{
    public partial class FormMain : Form
    {
        bool isLoggedIn = false;
        public FormMain(bool isLoggedIn = false)
        {
            InitializeComponent();
            if (!isLoggedIn)
            {
                Login login = new Login();
                login.ShowDialog();

            }

        }

        private void TsBtn_Click(object sender, EventArgs e)
        {
            if (!isLoggedIn)
            {
                // Login login = new Login();
                //login.Show();
            }
            else
            {
               // int targetTabIndex = tsMain.Items.IndexOf(sender as ToolStripItem);
                //tcMain.SelectTab(targetTabIndex);
            }
            
        }
    }
}
