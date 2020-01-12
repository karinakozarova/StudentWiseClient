namespace StudentWiseClient
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tpDashboard = new System.Windows.Forms.TabPage();
            this.dashboardComplaintsLbl = new System.Windows.Forms.Label();
            this.balanceAmountLbl = new System.Windows.Forms.Label();
            this.balanceLbl = new System.Windows.Forms.Label();
            this.complaintsFllPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.todaysEventsFllpnl = new System.Windows.Forms.FlowLayoutPanel();
            this.dashboardEventsLbl = new System.Windows.Forms.Label();
            this.timeNowLbl = new System.Windows.Forms.Label();
            this.tpEvents = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanelDay1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanelDay2 = new System.Windows.Forms.FlowLayoutPanel();
            this.AddEventBtn = new System.Windows.Forms.Button();
            this.flowLayoutPanelToday = new System.Windows.Forms.FlowLayoutPanel();
            this.lblEvents = new System.Windows.Forms.Label();
            this.flowLayoutPanelTommorow = new System.Windows.Forms.FlowLayoutPanel();
            this.TommorowEventsLbl = new System.Windows.Forms.Label();
            this.tpExpenses = new System.Windows.Forms.TabPage();
            this.lblExpenses = new System.Windows.Forms.Label();
            this.tpComplaints = new System.Windows.Forms.TabPage();
            this.complaintsFllpnl = new System.Windows.Forms.FlowLayoutPanel();
            this.newComplaintGb = new System.Windows.Forms.GroupBox();
            this.fileComplaintBttn = new System.Windows.Forms.Button();
            this.titleTbx = new System.Windows.Forms.TextBox();
            this.descriptionTbx = new System.Windows.Forms.RichTextBox();
            this.descriptionLbl = new System.Windows.Forms.Label();
            this.titleLbl = new System.Windows.Forms.Label();
            this.newComplaintLbl = new System.Windows.Forms.Label();
            this.complaintsLbl = new System.Windows.Forms.Label();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.tsBtnDashboard = new System.Windows.Forms.ToolStripButton();
            this.tsBtnEvents = new System.Windows.Forms.ToolStripButton();
            this.tsBtnExpenses = new System.Windows.Forms.ToolStripButton();
            this.tsBtnComplaints = new System.Windows.Forms.ToolStripButton();
            this.timeNowTimer = new System.Windows.Forms.Timer(this.components);
            this.tcMain.SuspendLayout();
            this.tpDashboard.SuspendLayout();
            this.tpEvents.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanelToday.SuspendLayout();
            this.flowLayoutPanelTommorow.SuspendLayout();
            this.tpExpenses.SuspendLayout();
            this.tpComplaints.SuspendLayout();
            this.newComplaintGb.SuspendLayout();
            this.tsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcMain
            // 
            this.tcMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcMain.Controls.Add(this.tpDashboard);
            this.tcMain.Controls.Add(this.tpEvents);
            this.tcMain.Controls.Add(this.tpExpenses);
            this.tcMain.Controls.Add(this.tpComplaints);
            this.tcMain.Location = new System.Drawing.Point(0, 39);
            this.tcMain.Margin = new System.Windows.Forms.Padding(0);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(957, 475);
            this.tcMain.TabIndex = 0;
            // 
            // tpDashboard
            // 
            this.tpDashboard.Controls.Add(this.dashboardComplaintsLbl);
            this.tpDashboard.Controls.Add(this.balanceAmountLbl);
            this.tpDashboard.Controls.Add(this.balanceLbl);
            this.tpDashboard.Controls.Add(this.complaintsFllPanel);
            this.tpDashboard.Controls.Add(this.todaysEventsFllpnl);
            this.tpDashboard.Controls.Add(this.dashboardEventsLbl);
            this.tpDashboard.Controls.Add(this.timeNowLbl);
            this.tpDashboard.Location = new System.Drawing.Point(4, 25);
            this.tpDashboard.Margin = new System.Windows.Forms.Padding(0);
            this.tpDashboard.Name = "tpDashboard";
            this.tpDashboard.Size = new System.Drawing.Size(949, 446);
            this.tpDashboard.TabIndex = 0;
            this.tpDashboard.Text = "Dashboard";
            this.tpDashboard.UseVisualStyleBackColor = true;
            // 
            // dashboardComplaintsLbl
            // 
            this.dashboardComplaintsLbl.AutoSize = true;
            this.dashboardComplaintsLbl.Font = new System.Drawing.Font("Oswald", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashboardComplaintsLbl.Location = new System.Drawing.Point(543, 34);
            this.dashboardComplaintsLbl.Name = "dashboardComplaintsLbl";
            this.dashboardComplaintsLbl.Size = new System.Drawing.Size(143, 51);
            this.dashboardComplaintsLbl.TabIndex = 7;
            this.dashboardComplaintsLbl.Text = "Complaints";
            // 
            // balanceAmountLbl
            // 
            this.balanceAmountLbl.AutoSize = true;
            this.balanceAmountLbl.Font = new System.Drawing.Font("Oswald", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.balanceAmountLbl.ForeColor = System.Drawing.Color.SpringGreen;
            this.balanceAmountLbl.Location = new System.Drawing.Point(708, 371);
            this.balanceAmountLbl.Name = "balanceAmountLbl";
            this.balanceAmountLbl.Size = new System.Drawing.Size(35, 35);
            this.balanceAmountLbl.TabIndex = 6;
            this.balanceAmountLbl.Text = "0$";
            // 
            // balanceLbl
            // 
            this.balanceLbl.AutoSize = true;
            this.balanceLbl.Font = new System.Drawing.Font("Oswald", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.balanceLbl.Location = new System.Drawing.Point(554, 365);
            this.balanceLbl.Name = "balanceLbl";
            this.balanceLbl.Size = new System.Drawing.Size(159, 41);
            this.balanceLbl.TabIndex = 5;
            this.balanceLbl.Text = "Your balance is:";
            // 
            // complaintsFllPanel
            // 
            this.complaintsFllPanel.AutoScroll = true;
            this.complaintsFllPanel.Location = new System.Drawing.Point(552, 88);
            this.complaintsFllPanel.Name = "complaintsFllPanel";
            this.complaintsFllPanel.Size = new System.Drawing.Size(315, 261);
            this.complaintsFllPanel.TabIndex = 4;
            // 
            // todaysEventsFllpnl
            // 
            this.todaysEventsFllpnl.AutoScroll = true;
            this.todaysEventsFllpnl.Location = new System.Drawing.Point(17, 88);
            this.todaysEventsFllpnl.Name = "todaysEventsFllpnl";
            this.todaysEventsFllpnl.Size = new System.Drawing.Size(460, 318);
            this.todaysEventsFllpnl.TabIndex = 3;
            // 
            // dashboardEventsLbl
            // 
            this.dashboardEventsLbl.AutoSize = true;
            this.dashboardEventsLbl.Font = new System.Drawing.Font("Oswald", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashboardEventsLbl.Location = new System.Drawing.Point(8, 34);
            this.dashboardEventsLbl.Name = "dashboardEventsLbl";
            this.dashboardEventsLbl.Size = new System.Drawing.Size(261, 51);
            this.dashboardEventsLbl.TabIndex = 2;
            this.dashboardEventsLbl.Text = "Your events for today:";
            // 
            // timeNowLbl
            // 
            this.timeNowLbl.AutoSize = true;
            this.timeNowLbl.Font = new System.Drawing.Font("Oswald", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeNowLbl.Location = new System.Drawing.Point(748, 14);
            this.timeNowLbl.Name = "timeNowLbl";
            this.timeNowLbl.Size = new System.Drawing.Size(101, 41);
            this.timeNowLbl.TabIndex = 1;
            this.timeNowLbl.Text = "Time now";
            // 
            // tpEvents
            // 
            this.tpEvents.Controls.Add(this.flowLayoutPanel1);
            this.tpEvents.Location = new System.Drawing.Point(4, 25);
            this.tpEvents.Margin = new System.Windows.Forms.Padding(0);
            this.tpEvents.Name = "tpEvents";
            this.tpEvents.Size = new System.Drawing.Size(949, 446);
            this.tpEvents.TabIndex = 1;
            this.tpEvents.Text = "Events";
            this.tpEvents.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanelDay1);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanelDay2);
            this.flowLayoutPanel1.Controls.Add(this.AddEventBtn);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanelToday);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanelTommorow);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(933, 422);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // flowLayoutPanelDay1
            // 
            this.flowLayoutPanelDay1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flowLayoutPanelDay1.AutoSize = true;
            this.flowLayoutPanelDay1.Location = new System.Drawing.Point(3, 37);
            this.flowLayoutPanelDay1.Name = "flowLayoutPanelDay1";
            this.flowLayoutPanelDay1.Size = new System.Drawing.Size(0, 0);
            this.flowLayoutPanelDay1.TabIndex = 3;
            // 
            // flowLayoutPanelDay2
            // 
            this.flowLayoutPanelDay2.AutoSize = true;
            this.flowLayoutPanelDay2.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanelDay2.Location = new System.Drawing.Point(9, 3);
            this.flowLayoutPanelDay2.Name = "flowLayoutPanelDay2";
            this.flowLayoutPanelDay2.Size = new System.Drawing.Size(0, 0);
            this.flowLayoutPanelDay2.TabIndex = 5;
            // 
            // AddEventBtn
            // 
            this.AddEventBtn.AllowDrop = true;
            this.AddEventBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AddEventBtn.AutoEllipsis = true;
            this.AddEventBtn.BackColor = System.Drawing.Color.LawnGreen;
            this.AddEventBtn.Font = new System.Drawing.Font("Oswald SemiBold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddEventBtn.Location = new System.Drawing.Point(15, 3);
            this.AddEventBtn.Name = "AddEventBtn";
            this.AddEventBtn.Size = new System.Drawing.Size(907, 68);
            this.AddEventBtn.TabIndex = 4;
            this.AddEventBtn.Text = "Add new event";
            this.AddEventBtn.UseVisualStyleBackColor = false;
            this.AddEventBtn.Click += new System.EventHandler(this.AddEventBtn_Click);
            // 
            // flowLayoutPanelToday
            // 
            this.flowLayoutPanelToday.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.flowLayoutPanelToday.AutoSize = true;
            this.flowLayoutPanelToday.Controls.Add(this.lblEvents);
            this.flowLayoutPanelToday.Location = new System.Drawing.Point(3, 77);
            this.flowLayoutPanelToday.Name = "flowLayoutPanelToday";
            this.flowLayoutPanelToday.Size = new System.Drawing.Size(907, 66);
            this.flowLayoutPanelToday.TabIndex = 9;
            // 
            // lblEvents
            // 
            this.lblEvents.AllowDrop = true;
            this.lblEvents.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblEvents.BackColor = System.Drawing.Color.LightGray;
            this.lblEvents.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEvents.Font = new System.Drawing.Font("Oswald", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEvents.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblEvents.Location = new System.Drawing.Point(0, 0);
            this.lblEvents.Margin = new System.Windows.Forms.Padding(0);
            this.lblEvents.Name = "lblEvents";
            this.lblEvents.Size = new System.Drawing.Size(907, 66);
            this.lblEvents.TabIndex = 8;
            this.lblEvents.Text = "Today\'s events";
            this.lblEvents.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanelTommorow
            // 
            this.flowLayoutPanelTommorow.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.flowLayoutPanelTommorow.AutoSize = true;
            this.flowLayoutPanelTommorow.Controls.Add(this.TommorowEventsLbl);
            this.flowLayoutPanelTommorow.Location = new System.Drawing.Point(3, 149);
            this.flowLayoutPanelTommorow.Name = "flowLayoutPanelTommorow";
            this.flowLayoutPanelTommorow.Size = new System.Drawing.Size(907, 68);
            this.flowLayoutPanelTommorow.TabIndex = 10;
            // 
            // TommorowEventsLbl
            // 
            this.TommorowEventsLbl.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TommorowEventsLbl.BackColor = System.Drawing.Color.LightGray;
            this.TommorowEventsLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TommorowEventsLbl.Font = new System.Drawing.Font("Oswald", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TommorowEventsLbl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TommorowEventsLbl.Location = new System.Drawing.Point(0, 0);
            this.TommorowEventsLbl.Margin = new System.Windows.Forms.Padding(0);
            this.TommorowEventsLbl.Name = "TommorowEventsLbl";
            this.TommorowEventsLbl.Size = new System.Drawing.Size(907, 68);
            this.TommorowEventsLbl.TabIndex = 9;
            this.TommorowEventsLbl.Text = "Tommorow\'s events";
            this.TommorowEventsLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tpExpenses
            // 
            this.tpExpenses.Controls.Add(this.lblExpenses);
            this.tpExpenses.Location = new System.Drawing.Point(4, 25);
            this.tpExpenses.Margin = new System.Windows.Forms.Padding(0);
            this.tpExpenses.Name = "tpExpenses";
            this.tpExpenses.Size = new System.Drawing.Size(949, 446);
            this.tpExpenses.TabIndex = 2;
            this.tpExpenses.Text = "Expenses";
            this.tpExpenses.UseVisualStyleBackColor = true;
            // 
            // lblExpenses
            // 
            this.lblExpenses.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblExpenses.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpenses.Location = new System.Drawing.Point(0, 0);
            this.lblExpenses.Margin = new System.Windows.Forms.Padding(0);
            this.lblExpenses.Name = "lblExpenses";
            this.lblExpenses.Padding = new System.Windows.Forms.Padding(0, 20, 0, 20);
            this.lblExpenses.Size = new System.Drawing.Size(949, 66);
            this.lblExpenses.TabIndex = 2;
            this.lblExpenses.Text = "Expenses";
            this.lblExpenses.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tpComplaints
            // 
            this.tpComplaints.Controls.Add(this.complaintsFllpnl);
            this.tpComplaints.Controls.Add(this.newComplaintGb);
            this.tpComplaints.Controls.Add(this.complaintsLbl);
            this.tpComplaints.Location = new System.Drawing.Point(4, 25);
            this.tpComplaints.Margin = new System.Windows.Forms.Padding(0);
            this.tpComplaints.Name = "tpComplaints";
            this.tpComplaints.Size = new System.Drawing.Size(949, 446);
            this.tpComplaints.TabIndex = 3;
            this.tpComplaints.Text = "Complaints";
            this.tpComplaints.UseVisualStyleBackColor = true;
            // 
            // complaintsFllpnl
            // 
            this.complaintsFllpnl.AutoScroll = true;
            this.complaintsFllpnl.Location = new System.Drawing.Point(16, 64);
            this.complaintsFllpnl.Name = "complaintsFllpnl";
            this.complaintsFllpnl.Size = new System.Drawing.Size(500, 361);
            this.complaintsFllpnl.TabIndex = 2;
            // 
            // newComplaintGb
            // 
            this.newComplaintGb.Controls.Add(this.fileComplaintBttn);
            this.newComplaintGb.Controls.Add(this.titleTbx);
            this.newComplaintGb.Controls.Add(this.descriptionTbx);
            this.newComplaintGb.Controls.Add(this.descriptionLbl);
            this.newComplaintGb.Controls.Add(this.titleLbl);
            this.newComplaintGb.Controls.Add(this.newComplaintLbl);
            this.newComplaintGb.Location = new System.Drawing.Point(531, 13);
            this.newComplaintGb.Name = "newComplaintGb";
            this.newComplaintGb.Size = new System.Drawing.Size(397, 412);
            this.newComplaintGb.TabIndex = 1;
            this.newComplaintGb.TabStop = false;
            // 
            // fileComplaintBttn
            // 
            this.fileComplaintBttn.BackColor = System.Drawing.Color.SpringGreen;
            this.fileComplaintBttn.Font = new System.Drawing.Font("Oswald", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileComplaintBttn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fileComplaintBttn.Location = new System.Drawing.Point(24, 343);
            this.fileComplaintBttn.Name = "fileComplaintBttn";
            this.fileComplaintBttn.Size = new System.Drawing.Size(347, 50);
            this.fileComplaintBttn.TabIndex = 3;
            this.fileComplaintBttn.Text = "File Complaint";
            this.fileComplaintBttn.UseVisualStyleBackColor = false;
            this.fileComplaintBttn.Click += new System.EventHandler(this.FileComplaintBttn_Click);
            // 
            // titleTbx
            // 
            this.titleTbx.Font = new System.Drawing.Font("Oswald", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleTbx.Location = new System.Drawing.Point(24, 122);
            this.titleTbx.Name = "titleTbx";
            this.titleTbx.Size = new System.Drawing.Size(347, 37);
            this.titleTbx.TabIndex = 1;
            // 
            // descriptionTbx
            // 
            this.descriptionTbx.Font = new System.Drawing.Font("Oswald", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionTbx.Location = new System.Drawing.Point(24, 212);
            this.descriptionTbx.Name = "descriptionTbx";
            this.descriptionTbx.Size = new System.Drawing.Size(347, 112);
            this.descriptionTbx.TabIndex = 2;
            this.descriptionTbx.Text = "";
            // 
            // descriptionLbl
            // 
            this.descriptionLbl.AutoSize = true;
            this.descriptionLbl.Font = new System.Drawing.Font("Oswald", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionLbl.Location = new System.Drawing.Point(17, 168);
            this.descriptionLbl.Name = "descriptionLbl";
            this.descriptionLbl.Size = new System.Drawing.Size(124, 41);
            this.descriptionLbl.TabIndex = 3;
            this.descriptionLbl.Text = "Description:";
            // 
            // titleLbl
            // 
            this.titleLbl.AutoSize = true;
            this.titleLbl.Font = new System.Drawing.Font("Oswald", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLbl.Location = new System.Drawing.Point(17, 78);
            this.titleLbl.Name = "titleLbl";
            this.titleLbl.Size = new System.Drawing.Size(62, 41);
            this.titleLbl.TabIndex = 1;
            this.titleLbl.Text = "Title:";
            // 
            // newComplaintLbl
            // 
            this.newComplaintLbl.AutoSize = true;
            this.newComplaintLbl.Font = new System.Drawing.Font("Oswald", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newComplaintLbl.Location = new System.Drawing.Point(16, 18);
            this.newComplaintLbl.Name = "newComplaintLbl";
            this.newComplaintLbl.Size = new System.Drawing.Size(175, 48);
            this.newComplaintLbl.TabIndex = 1;
            this.newComplaintLbl.Text = "New complaint:";
            // 
            // complaintsLbl
            // 
            this.complaintsLbl.AutoSize = true;
            this.complaintsLbl.Font = new System.Drawing.Font("Oswald", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.complaintsLbl.Location = new System.Drawing.Point(8, 13);
            this.complaintsLbl.Name = "complaintsLbl";
            this.complaintsLbl.Size = new System.Drawing.Size(138, 48);
            this.complaintsLbl.TabIndex = 0;
            this.complaintsLbl.Text = "Complaints:";
            // 
            // tsMain
            // 
            this.tsMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tsMain.AutoSize = false;
            this.tsMain.Dock = System.Windows.Forms.DockStyle.None;
            this.tsMain.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.tsMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnDashboard,
            this.tsBtnEvents,
            this.tsBtnExpenses,
            this.tsBtnComplaints});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Padding = new System.Windows.Forms.Padding(10);
            this.tsMain.Size = new System.Drawing.Size(953, 64);
            this.tsMain.TabIndex = 1;
            // 
            // tsBtnDashboard
            // 
            this.tsBtnDashboard.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnDashboard.Image")));
            this.tsBtnDashboard.ImageTransparentColor = System.Drawing.SystemColors.Window;
            this.tsBtnDashboard.Margin = new System.Windows.Forms.Padding(0);
            this.tsBtnDashboard.Name = "tsBtnDashboard";
            this.tsBtnDashboard.Padding = new System.Windows.Forms.Padding(5);
            this.tsBtnDashboard.Size = new System.Drawing.Size(142, 44);
            this.tsBtnDashboard.Text = "Dashboard";
            this.tsBtnDashboard.Click += new System.EventHandler(this.TsBtn_Click);
            // 
            // tsBtnEvents
            // 
            this.tsBtnEvents.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnEvents.Image")));
            this.tsBtnEvents.ImageTransparentColor = System.Drawing.SystemColors.Window;
            this.tsBtnEvents.Margin = new System.Windows.Forms.Padding(0);
            this.tsBtnEvents.Name = "tsBtnEvents";
            this.tsBtnEvents.Padding = new System.Windows.Forms.Padding(5);
            this.tsBtnEvents.Size = new System.Drawing.Size(102, 19);
            this.tsBtnEvents.Text = "Events";
            this.tsBtnEvents.Click += new System.EventHandler(this.TsBtn_Click);
            // 
            // tsBtnExpenses
            // 
            this.tsBtnExpenses.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnExpenses.Image")));
            this.tsBtnExpenses.ImageTransparentColor = System.Drawing.SystemColors.Window;
            this.tsBtnExpenses.Margin = new System.Windows.Forms.Padding(0);
            this.tsBtnExpenses.Name = "tsBtnExpenses";
            this.tsBtnExpenses.Padding = new System.Windows.Forms.Padding(5);
            this.tsBtnExpenses.Size = new System.Drawing.Size(124, 19);
            this.tsBtnExpenses.Text = "Expenses";
            this.tsBtnExpenses.Click += new System.EventHandler(this.TsBtn_Click);
            // 
            // tsBtnComplaints
            // 
            this.tsBtnComplaints.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnComplaints.Image")));
            this.tsBtnComplaints.ImageTransparentColor = System.Drawing.SystemColors.Window;
            this.tsBtnComplaints.Margin = new System.Windows.Forms.Padding(0);
            this.tsBtnComplaints.Name = "tsBtnComplaints";
            this.tsBtnComplaints.Padding = new System.Windows.Forms.Padding(5);
            this.tsBtnComplaints.Size = new System.Drawing.Size(145, 19);
            this.tsBtnComplaints.Text = "Complaints";
            this.tsBtnComplaints.Click += new System.EventHandler(this.TsBtn_Click);
            // 
            // timeNowTimer
            // 
            this.timeNowTimer.Interval = 1000;
            this.timeNowTimer.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // FormMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(944, 501);
            this.Controls.Add(this.tsMain);
            this.Controls.Add(this.tcMain);
            this.MinimumSize = new System.Drawing.Size(470, 540);
            this.Name = "FormMain";
            this.Text = "StudentWise";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.tcMain.ResumeLayout(false);
            this.tpDashboard.ResumeLayout(false);
            this.tpDashboard.PerformLayout();
            this.tpEvents.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanelToday.ResumeLayout(false);
            this.flowLayoutPanelTommorow.ResumeLayout(false);
            this.tpExpenses.ResumeLayout(false);
            this.tpComplaints.ResumeLayout(false);
            this.tpComplaints.PerformLayout();
            this.newComplaintGb.ResumeLayout(false);
            this.newComplaintGb.PerformLayout();
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tpDashboard;
        private System.Windows.Forms.TabPage tpExpenses;
        private System.Windows.Forms.TabPage tpComplaints;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton tsBtnDashboard;
        private System.Windows.Forms.ToolStripButton tsBtnEvents;
        private System.Windows.Forms.ToolStripButton tsBtnExpenses;
        private System.Windows.Forms.ToolStripButton tsBtnComplaints;
        private System.Windows.Forms.Label lblExpenses;
        private System.Windows.Forms.TabPage tpEvents;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelDay1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelDay2;
        private System.Windows.Forms.Button AddEventBtn;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelToday;
        private System.Windows.Forms.Label lblEvents;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelTommorow;
        private System.Windows.Forms.Label TommorowEventsLbl;
        private System.Windows.Forms.GroupBox newComplaintGb;
        private System.Windows.Forms.Label complaintsLbl;
        private System.Windows.Forms.Label newComplaintLbl;
        private System.Windows.Forms.Button fileComplaintBttn;
        private System.Windows.Forms.TextBox titleTbx;
        private System.Windows.Forms.RichTextBox descriptionTbx;
        private System.Windows.Forms.Label descriptionLbl;
        private System.Windows.Forms.Label titleLbl;
        private System.Windows.Forms.FlowLayoutPanel complaintsFllpnl;
        private System.Windows.Forms.Label timeNowLbl;
        private System.Windows.Forms.Timer timeNowTimer;
        private System.Windows.Forms.Label dashboardEventsLbl;
        private System.Windows.Forms.FlowLayoutPanel todaysEventsFllpnl;
        private System.Windows.Forms.Label balanceAmountLbl;
        private System.Windows.Forms.Label balanceLbl;
        private System.Windows.Forms.FlowLayoutPanel complaintsFllPanel;
        private System.Windows.Forms.Label dashboardComplaintsLbl;
    }
}

