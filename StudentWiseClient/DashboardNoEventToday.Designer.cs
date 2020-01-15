namespace StudentWiseClient
{
    partial class DashboardNoEventToday
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.sorryLbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.AddEventBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // sorryLbl
            // 
            this.sorryLbl.AutoSize = true;
            this.sorryLbl.Font = new System.Drawing.Font("Oswald", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sorryLbl.Location = new System.Drawing.Point(89, 20);
            this.sorryLbl.Name = "sorryLbl";
            this.sorryLbl.Size = new System.Drawing.Size(171, 102);
            this.sorryLbl.TabIndex = 1;
            this.sorryLbl.Text = "Sorry!";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Oswald", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(358, 51);
            this.label1.TabIndex = 2;
            this.label1.Text = "You don\'t have an event today. ";
            // 
            // AddEventBtn
            // 
            this.AddEventBtn.AllowDrop = true;
            this.AddEventBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AddEventBtn.AutoEllipsis = true;
            this.AddEventBtn.BackColor = System.Drawing.Color.LawnGreen;
            this.AddEventBtn.Font = new System.Drawing.Font("Oswald SemiBold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddEventBtn.Location = new System.Drawing.Point(53, 211);
            this.AddEventBtn.Name = "AddEventBtn";
            this.AddEventBtn.Size = new System.Drawing.Size(255, 68);
            this.AddEventBtn.TabIndex = 5;
            this.AddEventBtn.Text = "Add";
            this.AddEventBtn.UseVisualStyleBackColor = false;
            this.AddEventBtn.Click += new System.EventHandler(this.AddEventBtn_Click_1);
            // 
            // DashboardNoEventToday
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.AddEventBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sorryLbl);
            this.Name = "DashboardNoEventToday";
            this.Size = new System.Drawing.Size(388, 354);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label sorryLbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button AddEventBtn;
    }
}
