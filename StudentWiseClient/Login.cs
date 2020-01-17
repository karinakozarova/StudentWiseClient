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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void ContinueBttn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(emailAddressTbx.Text))
            {
                MessageBox.Show("Please, enter your email address.", null, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (String.IsNullOrEmpty(passwordTbx.Text))
            {
                MessageBox.Show("Please, enter your password.", null, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!EmailValidation.IsValidEmail(emailAddressTbx.Text))
            {
                MessageBox.Show("Please, enter a valid email address.", null, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Server.CurrentSession = Server.Login(emailAddressTbx.Text, passwordTbx.Text);
                this.Hide();

                FormMain dashboard = new FormMain();
                dashboard.Show();
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, null, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Register registerScreen = new Register();
            registerScreen.Show();
        }

        private void passwordTbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                continueBttn.PerformClick();
        }
    }
}
