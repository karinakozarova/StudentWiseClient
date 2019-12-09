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
        public FormMain()
        {
            InitializeComponent();
        }

        private void TsBtn_Click(object sender, EventArgs e)
        {
            ToolStripButton button = sender as ToolStripButton;
            string targetTab = button.Text;

            switch (targetTab)
            {
                case "Dashboard":
                case "Events":
                case "Expenses":
                case "Complaints":
                    tcMain.SelectTab($"tp{targetTab}");
                break;

                default:
                    tcMain.SelectTab(0);
                break;
            }
        }
    }
}
