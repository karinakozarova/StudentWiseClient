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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }        

        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(fNameTbx.Text))
            {
                MessageBox.Show("Please, enter your first name.", null, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(String.IsNullOrEmpty(lNameTbx.Text))
            {
                MessageBox.Show("Please, enter your last name.", null, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (String.IsNullOrEmpty(emailAddressTbx.Text))
            {
                MessageBox.Show("Please, enter your email address.", null, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (String.IsNullOrEmpty(passwordTbx.Text))
            {
                MessageBox.Show("Please, enter a password", null, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!EmailValidation.IsValidEmail(emailAddressTbx.Text))
            {
                MessageBox.Show("Please, enter a valid email address.", null, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Server.CurrentSession = Server.CreateUser(emailAddressTbx.Text, fNameTbx.Text, lNameTbx.Text, passwordTbx.Text);

                // User logged in successfully, go to the according page
                this.Hide();
                FormMain dashboard = new FormMain();
                dashboard.Show();
            } catch(Exception ex){
                MessageBox.Show(ex.Message, null, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void LoginLinkL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Login loginScreen = new Login();
            loginScreen.Show();
        }

        private void passwordTbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                registerBtn.PerformClick();
        }
    }
}
