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

            Server.CurrentSession = Server.Login("string@string.string", "string");
            this.Hide();

            FormMain dashboard = new FormMain();
            dashboard.Show();
            return;
        }

        private void ContinueBttn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(emailAddressTbx.Text))
            {
                MessageBox.Show("Enter your email address");
                return;
            }

            if (String.IsNullOrEmpty(passwordTbx.Text))
            {
                MessageBox.Show("Enter a password");
                return;
            }

            if (!EmailValidation.IsValidEmail(emailAddressTbx.Text)){
                MessageBox.Show("Enter a valid email address");
                return;
            }

            try
            {
                Server.CurrentSession =  Server.Login(emailAddressTbx.Text, passwordTbx.Text);
                this.Hide();

                FormMain dashboard = new FormMain();
                dashboard.Show();
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Register registerScreen = new Register();
            registerScreen.Show();
        }
    }
}
