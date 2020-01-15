namespace StudentWiseClient
{
    partial class NoComplaints
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
            this.label1 = new System.Windows.Forms.Label();
            this.sorryLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Oswald", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(354, 51);
            this.label1.TabIndex = 3;
            this.label1.Text = "You don\'t have any complaints.";
            // 
            // sorryLbl
            // 
            this.sorryLbl.AutoSize = true;
            this.sorryLbl.Font = new System.Drawing.Font("Oswald", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sorryLbl.Location = new System.Drawing.Point(100, 55);
            this.sorryLbl.Name = "sorryLbl";
            this.sorryLbl.Size = new System.Drawing.Size(171, 102);
            this.sorryLbl.TabIndex = 2;
            this.sorryLbl.Text = "Sorry!";
            // 
            // NoComplaints
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sorryLbl);
            this.Name = "NoComplaints";
            this.Size = new System.Drawing.Size(429, 247);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label sorryLbl;
    }
}
