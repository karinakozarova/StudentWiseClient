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
    public partial class AgreementComponent : UserControl
    {
        public AgreementComponent(String title, String description, String username, DateTime createdAt)
        {
            InitializeComponent();
            titleLbl.Text = title;
            descriptionLbl.Text = description;
            timestampLbl.Text = $"Created by {username} \n on {createdAt.ToShortDateString()}";
        }
    }
}
