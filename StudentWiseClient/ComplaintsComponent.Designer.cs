namespace StudentWiseClient
{
    partial class ComplaintsComponent
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
            this.statusLbl = new System.Windows.Forms.Label();
            this.titleLbl = new System.Windows.Forms.Label();
            this.descriptionLbl = new System.Windows.Forms.Label();
            this.timestampLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // statusLbl
            // 
            this.statusLbl.AutoSize = true;
            this.statusLbl.Font = new System.Drawing.Font("Oswald", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLbl.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.statusLbl.Location = new System.Drawing.Point(24, 22);
            this.statusLbl.Name = "statusLbl";
            this.statusLbl.Size = new System.Drawing.Size(74, 22);
            this.statusLbl.TabIndex = 0;
            this.statusLbl.Text = "IN PROGRESS";
            // 
            // titleLbl
            // 
            this.titleLbl.AutoSize = true;
            this.titleLbl.Font = new System.Drawing.Font("Oswald", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLbl.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.titleLbl.Location = new System.Drawing.Point(22, 44);
            this.titleLbl.Name = "titleLbl";
            this.titleLbl.Size = new System.Drawing.Size(174, 35);
            this.titleLbl.TabIndex = 1;
            this.titleLbl.Text = "Title of the complaint";
            // 
            // descriptionLbl
            // 
            this.descriptionLbl.AutoSize = true;
            this.descriptionLbl.Font = new System.Drawing.Font("Oswald", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionLbl.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.descriptionLbl.Location = new System.Drawing.Point(23, 79);
            this.descriptionLbl.Name = "descriptionLbl";
            this.descriptionLbl.Size = new System.Drawing.Size(315, 29);
            this.descriptionLbl.TabIndex = 2;
            this.descriptionLbl.Text = "Here comes the cool description of the complaint";
            // 
            // timestampLbl
            // 
            this.timestampLbl.AutoSize = true;
            this.timestampLbl.Font = new System.Drawing.Font("Oswald", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timestampLbl.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.timestampLbl.Location = new System.Drawing.Point(348, 22);
            this.timestampLbl.Name = "timestampLbl";
            this.timestampLbl.Size = new System.Drawing.Size(100, 22);
            this.timestampLbl.TabIndex = 3;
            this.timestampLbl.Text = "12th October 2020";
            // 
            // ComplaintsComponent
            // 
            this.Controls.Add(this.timestampLbl);
            this.Controls.Add(this.descriptionLbl);
            this.Controls.Add(this.titleLbl);
            this.Controls.Add(this.statusLbl);
            this.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.Name = "ComplaintsComponent";
            this.Size = new System.Drawing.Size(454, 133);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label statusLbl;
        private System.Windows.Forms.Label titleLbl;
        private System.Windows.Forms.Label descriptionLbl;
        private System.Windows.Forms.Label timestampLbl;
    }
}
