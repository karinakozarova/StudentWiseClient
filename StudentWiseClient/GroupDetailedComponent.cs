using System;
using System.Collections.Generic;
using System.Windows.Forms;
using StudentWiseApi;

namespace StudentWiseClient
{
    public partial class GroupDetailedComponent : UserControl
    {
        private Group group;
        private List<User> users;

        public GroupDetailedComponent(Group group, List<User> users)
        {
            this.group = group;
            this.users = users;

            InitializeComponent();
            LoadGroupData();
        }

        private void LoadGroupData()
        {
            lblName.Text = group.Name.UppercaseFirst();
            lblDescription.Text = group.Description.UppercaseFirst();
            lblRules.Text = group.Rules.UppercaseFirst();
            lblDateTime.Text = $"Created on {group.CreatedAt.ToShortDateString()}";

            cbxMembers.Items.AddRange(UsersFullNames(users));
        }

        private string[] UsersFullNames(List<User> users)
        {
            List<string> results = new List<string>();

            foreach (var user in users)
            {
                results.Add($"{user.FirstName.UppercaseFirst()} {user.LastName.UppercaseFirst()}");
            }

            return results.ToArray();
        }

        private void BtnMoveMember_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxMembers.SelectedIndex == -1)
                    throw new Exception("Please, select a user.");

                User user = users[cbxMembers.SelectedIndex];
                user.MoveToGroup(group.Id);

                MessageBox.Show(
                    $"Successfully moved {user.FirstName.UppercaseFirst()} to the {group.Name.UppercaseFirst()} group.",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, null, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnRemoveMember_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxMembers.SelectedIndex == -1)
                    throw new Exception("Please, select a user.");

                User user = users[cbxMembers.SelectedIndex];
                group.RemoveMember(user.Id);

                MessageBox.Show(
                    $"Successfully removed {user.FirstName.UppercaseFirst()} from the {group.Name.UppercaseFirst()} group.",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, null, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
