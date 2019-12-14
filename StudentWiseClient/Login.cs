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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void ContinueBttn_Click(object sender, EventArgs e)
        {
            bool isPasswordCorrect = true;

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

            if (!IsValidEmail(emailAddressTbx.Text)){
                MessageBox.Show("Enter a valid email address");
                return;
            }

            // TODO: send them to the api
            // TODO: check if they are correct 

            if(isPasswordCorrect){
                this.Hide();

                // TODO: open the dashboard with arguments
                FormMain dashboard = new FormMain(true);
                dashboard.Show();
                return;
            }
            MessageBox.Show("Wrong credentials, try again!");
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Register registerScreen = new Register();
            registerScreen.Show();
        }
    }
}
