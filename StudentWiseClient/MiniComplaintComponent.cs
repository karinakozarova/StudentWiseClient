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
    public partial class MiniComplaintComponent : UserControl
    {
        public MiniComplaintComponent()
        {
            InitializeComponent();
        }

        public void ChangeComplainStatus(ComplaintStatus status)
        {
            statusLbl.Text = status.ToString();
        }

        public void ChangeTitle(String title)
        {
            titleLbl.Text = title;
        }


        public void ChangeLabels(String title, ComplaintStatus status)
        {
            ChangeTitle(title);
            ChangeComplainStatus(status);
        }
    }
}
