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
        }

        private void ContinueBttn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(emailAddressTbx.Text) ||
                !EmailValidation.IsValidEmail(emailAddressTbx.Text))
                throw new ApplicationException("Please, enter a valid email address.");

            if (string.IsNullOrEmpty(passwordTbx.Text))
                throw new ApplicationException("Please, enter your password");

            Server.CurrentSession = Server.Login(emailAddressTbx.Text, passwordTbx.Text);
            this.Hide();

            FormMain dashboard = new FormMain();
            dashboard.Show();
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
