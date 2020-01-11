using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentWiseApi;

namespace StudentWiseClient
{
    public partial class ComplaintsComponent : UserControl
    {
        public ComplaintsComponent()
        {
            InitializeComponent();
            this.BorderStyle = BorderStyle.FixedSingle;
        }

        public void ChangeComplainStatus()
        {
            // TODO: add parameter type
            // statusLbl.Text = 
        }

        public void ChangeTitle(String title)
        {
            titleLbl.Text = title;
        }

        public void ChangeDescription(String description)
        {
            descriptionLbl.Text = description;
        }

        public void ChangeTimestamp()
        {
            // TODO: add parameter type
            // timestampLbl.Text = 
        }

        public void ChangeLabels(String title, String description)
        {
            // TODO: add missing parameters
            ChangeTitle(title);
            ChangeDescription(description);
            ChangeComplainStatus();
            ChangeTimestamp();
        }
    }
}
