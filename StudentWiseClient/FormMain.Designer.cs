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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tpDashboard = new System.Windows.Forms.TabPage();
            this.lblDashboard = new System.Windows.Forms.Label();
            this.tpEvents = new System.Windows.Forms.TabPage();
            this.lblEvents = new System.Windows.Forms.Label();
            this.tpExpenses = new System.Windows.Forms.TabPage();
            this.lblExpenses = new System.Windows.Forms.Label();
            this.tpComplaints = new System.Windows.Forms.TabPage();
            this.lblComplaints = new System.Windows.Forms.Label();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.tsBtnDashboard = new System.Windows.Forms.ToolStripButton();
            this.tsBtnEvents = new System.Windows.Forms.ToolStripButton();
            this.tsBtnExpenses = new System.Windows.Forms.ToolStripButton();
            this.tsBtnComplaints = new System.Windows.Forms.ToolStripButton();
            this.tcMain.SuspendLayout();
            this.tpDashboard.SuspendLayout();
            this.tpEvents.SuspendLayout();
            this.tpExpenses.SuspendLayout();
            this.tpComplaints.SuspendLayout();
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
            this.tcMain.Size = new System.Drawing.Size(946, 465);
            this.tcMain.TabIndex = 0;
            // 
            // tpDashboard
            // 
            this.tpDashboard.Controls.Add(this.lblDashboard);
            this.tpDashboard.Location = new System.Drawing.Point(4, 25);
            this.tpDashboard.Margin = new System.Windows.Forms.Padding(0);
            this.tpDashboard.Name = "tpDashboard";
            this.tpDashboard.Size = new System.Drawing.Size(938, 436);
            this.tpDashboard.TabIndex = 0;
            this.tpDashboard.Text = "Dashboard";
            this.tpDashboard.UseVisualStyleBackColor = true;
            // 
            // lblDashboard
            // 
            this.lblDashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDashboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDashboard.Location = new System.Drawing.Point(0, 0);
            this.lblDashboard.Margin = new System.Windows.Forms.Padding(0);
            this.lblDashboard.Name = "lblDashboard";
            this.lblDashboard.Padding = new System.Windows.Forms.Padding(0, 20, 0, 20);
            this.lblDashboard.Size = new System.Drawing.Size(938, 66);
            this.lblDashboard.TabIndex = 0;
            this.lblDashboard.Text = "Dashboard";
            this.lblDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tpEvents
            // 
            this.tpEvents.Controls.Add(this.lblEvents);
            this.tpEvents.Location = new System.Drawing.Point(4, 25);
            this.tpEvents.Margin = new System.Windows.Forms.Padding(0);
            this.tpEvents.Name = "tpEvents";
            this.tpEvents.Size = new System.Drawing.Size(938, 436);
            this.tpEvents.TabIndex = 1;
            this.tpEvents.Text = "Events";
            this.tpEvents.UseVisualStyleBackColor = true;
            // 
            // lblEvents
            // 
            this.lblEvents.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblEvents.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEvents.Location = new System.Drawing.Point(0, 0);
            this.lblEvents.Margin = new System.Windows.Forms.Padding(0);
            this.lblEvents.Name = "lblEvents";
            this.lblEvents.Padding = new System.Windows.Forms.Padding(0, 20, 0, 20);
            this.lblEvents.Size = new System.Drawing.Size(938, 66);
            this.lblEvents.TabIndex = 1;
            this.lblEvents.Text = "Events";
            this.lblEvents.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tpExpenses
            // 
            this.tpExpenses.Controls.Add(this.lblExpenses);
            this.tpExpenses.Location = new System.Drawing.Point(4, 25);
            this.tpExpenses.Margin = new System.Windows.Forms.Padding(0);
            this.tpExpenses.Name = "tpExpenses";
            this.tpExpenses.Size = new System.Drawing.Size(938, 436);
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
            this.lblExpenses.Size = new System.Drawing.Size(938, 66);
            this.lblExpenses.TabIndex = 2;
            this.lblExpenses.Text = "Expenses";
            this.lblExpenses.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tpComplaints
            // 
            this.tpComplaints.Controls.Add(this.lblComplaints);
            this.tpComplaints.Location = new System.Drawing.Point(4, 25);
            this.tpComplaints.Margin = new System.Windows.Forms.Padding(0);
            this.tpComplaints.Name = "tpComplaints";
            this.tpComplaints.Size = new System.Drawing.Size(938, 436);
            this.tpComplaints.TabIndex = 3;
            this.tpComplaints.Text = "Complaints";
            this.tpComplaints.UseVisualStyleBackColor = true;
            // 
            // lblComplaints
            // 
            this.lblComplaints.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblComplaints.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComplaints.Location = new System.Drawing.Point(0, 0);
            this.lblComplaints.Margin = new System.Windows.Forms.Padding(0);
            this.lblComplaints.Name = "lblComplaints";
            this.lblComplaints.Padding = new System.Windows.Forms.Padding(0, 20, 0, 20);
            this.lblComplaints.Size = new System.Drawing.Size(938, 66);
            this.lblComplaints.TabIndex = 3;
            this.lblComplaints.Text = "Complaints";
            this.lblComplaints.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.tsMain.Size = new System.Drawing.Size(946, 60);
            this.tsMain.TabIndex = 1;
            // 
            // tsBtnDashboard
            // 
            this.tsBtnDashboard.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnDashboard.Image")));
            this.tsBtnDashboard.ImageTransparentColor = System.Drawing.SystemColors.Window;
            this.tsBtnDashboard.Margin = new System.Windows.Forms.Padding(0);
            this.tsBtnDashboard.Name = "tsBtnDashboard";
            this.tsBtnDashboard.Padding = new System.Windows.Forms.Padding(5);
            this.tsBtnDashboard.Size = new System.Drawing.Size(142, 40);
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
            this.tsBtnEvents.Size = new System.Drawing.Size(102, 40);
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
            this.tsBtnExpenses.Size = new System.Drawing.Size(124, 40);
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
            this.tsBtnComplaints.Size = new System.Drawing.Size(145, 40);
            this.tsBtnComplaints.Text = "Complaints";
            this.tsBtnComplaints.Click += new System.EventHandler(this.TsBtn_Click);
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
            this.tcMain.ResumeLayout(false);
            this.tpDashboard.ResumeLayout(false);
            this.tpEvents.ResumeLayout(false);
            this.tpExpenses.ResumeLayout(false);
            this.tpComplaints.ResumeLayout(false);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tpDashboard;
        private System.Windows.Forms.TabPage tpEvents;
        private System.Windows.Forms.TabPage tpExpenses;
        private System.Windows.Forms.TabPage tpComplaints;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton tsBtnDashboard;
        private System.Windows.Forms.ToolStripButton tsBtnEvents;
        private System.Windows.Forms.ToolStripButton tsBtnExpenses;
        private System.Windows.Forms.ToolStripButton tsBtnComplaints;
        private System.Windows.Forms.Label lblDashboard;
        private System.Windows.Forms.Label lblEvents;
        private System.Windows.Forms.Label lblExpenses;
        private System.Windows.Forms.Label lblComplaints;
    }
}

