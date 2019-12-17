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
    public partial class Register : Form
    {
        public Register()
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

        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(fNameTbx.Text))
            {
                MessageBox.Show("Enter your first name!");
                return;
            }
            if(String.IsNullOrEmpty(lNameTbx.Text))
            {
                MessageBox.Show("Enter your last name!");
                return;
            }
            if (String.IsNullOrEmpty(emailAddressTbx.Text))
            {
                MessageBox.Show("Enter your email address!");
                return;
            }

            if (String.IsNullOrEmpty(passwordTbx.Text))
            {
                MessageBox.Show("Enter a password!");
                return;
            }

            if (!IsValidEmail(emailAddressTbx.Text))
            {
                MessageBox.Show("Enter a valid email address!");
                return;
            }

            try
            {
                Server.CreateUser(emailAddressTbx.Text, fNameTbx.Text, lNameTbx.Text, passwordTbx.Text);

                // User logged in successfully, go to the according page
                this.Hide();
                FormMain dashboard = new FormMain();
                dashboard.Show();
            } catch(Exception ex){
                MessageBox.Show(ex.ToString());
            }            
        }

        private void LoginLinkL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Login loginScreen = new Login();
            loginScreen.Show();
        }
    }
}
