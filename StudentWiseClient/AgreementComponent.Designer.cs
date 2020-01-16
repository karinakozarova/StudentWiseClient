namespace StudentWiseClient
{
    partial class AgreementComponent
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
            this.timestampLbl = new System.Windows.Forms.Label();
            this.descriptionLbl = new System.Windows.Forms.Label();
            this.titleLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timestampLbl
            // 
            this.timestampLbl.AutoSize = true;
            this.timestampLbl.Font = new System.Drawing.Font("Oswald", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timestampLbl.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.timestampLbl.Location = new System.Drawing.Point(352, 32);
            this.timestampLbl.Name = "timestampLbl";
            this.timestampLbl.Size = new System.Drawing.Size(108, 24);
            this.timestampLbl.TabIndex = 6;
            this.timestampLbl.Text = "12th October 2020";
            // 
            // descriptionLbl
            // 
            this.descriptionLbl.AutoSize = true;
            this.descriptionLbl.Font = new System.Drawing.Font("Oswald", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionLbl.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.descriptionLbl.Location = new System.Drawing.Point(27, 89);
            this.descriptionLbl.Name = "descriptionLbl";
            this.descriptionLbl.Size = new System.Drawing.Size(318, 29);
            this.descriptionLbl.TabIndex = 5;
            this.descriptionLbl.Text = "Here comes the cool description of the agreement";
            // 
            // titleLbl
            // 
            this.titleLbl.AutoSize = true;
            this.titleLbl.Font = new System.Drawing.Font("Oswald", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLbl.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.titleLbl.Location = new System.Drawing.Point(26, 32);
            this.titleLbl.Name = "titleLbl";
            this.titleLbl.Size = new System.Drawing.Size(177, 35);
            this.titleLbl.TabIndex = 4;
            this.titleLbl.Text = "Title of the agreement";
            // 
            // AgreementComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.timestampLbl);
            this.Controls.Add(this.descriptionLbl);
            this.Controls.Add(this.titleLbl);
            this.Name = "AgreementComponent";
            this.Size = new System.Drawing.Size(486, 150);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label timestampLbl;
        private System.Windows.Forms.Label descriptionLbl;
        private System.Windows.Forms.Label titleLbl;
    }
}
