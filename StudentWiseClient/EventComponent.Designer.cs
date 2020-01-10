namespace StudentWiseClient
{
    partial class EventComponent
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
            this.EventTypeLbl = new System.Windows.Forms.Label();
            this.EventTitleLbl = new System.Windows.Forms.Label();
            this.EventDescriptionLbl = new System.Windows.Forms.Label();
            this.EventDeadlineLbl = new System.Windows.Forms.Label();
            this.CompleteEventBtn = new System.Windows.Forms.Button();
            this.EventPointsLbl = new System.Windows.Forms.Label();
            this.ImagePbx = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ImagePbx)).BeginInit();
            this.SuspendLayout();
            // 
            // EventTypeLbl
            // 
            this.EventTypeLbl.AutoSize = true;
            this.EventTypeLbl.Font = new System.Drawing.Font("Oswald", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EventTypeLbl.Location = new System.Drawing.Point(129, 48);
            this.EventTypeLbl.Name = "EventTypeLbl";
            this.EventTypeLbl.Size = new System.Drawing.Size(87, 32);
            this.EventTypeLbl.TabIndex = 1;
            this.EventTypeLbl.Text = "Event Type";
            // 
            // EventTitleLbl
            // 
            this.EventTitleLbl.AutoSize = true;
            this.EventTitleLbl.Font = new System.Drawing.Font("Oswald", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EventTitleLbl.Location = new System.Drawing.Point(128, 80);
            this.EventTitleLbl.Name = "EventTitleLbl";
            this.EventTitleLbl.Size = new System.Drawing.Size(121, 41);
            this.EventTitleLbl.TabIndex = 2;
            this.EventTitleLbl.Text = "Event Title";
            // 
            // EventDescriptionLbl
            // 
            this.EventDescriptionLbl.Font = new System.Drawing.Font("Oswald", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EventDescriptionLbl.Location = new System.Drawing.Point(11, 145);
            this.EventDescriptionLbl.Name = "EventDescriptionLbl";
            this.EventDescriptionLbl.Size = new System.Drawing.Size(419, 80);
            this.EventDescriptionLbl.TabIndex = 3;
            this.EventDescriptionLbl.Text = "Event Description";
            // 
            // EventDeadlineLbl
            // 
            this.EventDeadlineLbl.Font = new System.Drawing.Font("Oswald", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EventDeadlineLbl.Location = new System.Drawing.Point(267, 19);
            this.EventDeadlineLbl.Name = "EventDeadlineLbl";
            this.EventDeadlineLbl.Size = new System.Drawing.Size(163, 66);
            this.EventDeadlineLbl.TabIndex = 4;
            this.EventDeadlineLbl.Text = "Start Date and End Date";
            // 
            // CompleteEventBtn
            // 
            this.CompleteEventBtn.BackColor = System.Drawing.Color.LawnGreen;
            this.CompleteEventBtn.Font = new System.Drawing.Font("Oswald", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CompleteEventBtn.Location = new System.Drawing.Point(190, 239);
            this.CompleteEventBtn.Name = "CompleteEventBtn";
            this.CompleteEventBtn.Size = new System.Drawing.Size(240, 73);
            this.CompleteEventBtn.TabIndex = 5;
            this.CompleteEventBtn.Text = "Complete";
            this.CompleteEventBtn.UseVisualStyleBackColor = false;
            this.CompleteEventBtn.Click += new System.EventHandler(this.CompleteEventBtn_Click);
            // 
            // EventPointsLbl
            // 
            this.EventPointsLbl.Font = new System.Drawing.Font("Oswald", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EventPointsLbl.Location = new System.Drawing.Point(19, 240);
            this.EventPointsLbl.Name = "EventPointsLbl";
            this.EventPointsLbl.Size = new System.Drawing.Size(165, 73);
            this.EventPointsLbl.TabIndex = 6;
            this.EventPointsLbl.Text = "Event Points";
            this.EventPointsLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ImagePbx
            // 
            this.ImagePbx.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ImagePbx.Location = new System.Drawing.Point(17, 19);
            this.ImagePbx.Name = "ImagePbx";
            this.ImagePbx.Size = new System.Drawing.Size(106, 102);
            this.ImagePbx.TabIndex = 0;
            this.ImagePbx.TabStop = false;
            // 
            // EventComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.EventPointsLbl);
            this.Controls.Add(this.CompleteEventBtn);
            this.Controls.Add(this.EventDeadlineLbl);
            this.Controls.Add(this.EventDescriptionLbl);
            this.Controls.Add(this.EventTitleLbl);
            this.Controls.Add(this.EventTypeLbl);
            this.Controls.Add(this.ImagePbx);
            this.Font = new System.Drawing.Font("Oswald", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.Name = "EventComponent";
            this.Size = new System.Drawing.Size(445, 321);
            ((System.ComponentModel.ISupportInitialize)(this.ImagePbx)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ImagePbx;
        private System.Windows.Forms.Label EventTypeLbl;
        private System.Windows.Forms.Label EventTitleLbl;
        private System.Windows.Forms.Label EventDescriptionLbl;
        private System.Windows.Forms.Label EventDeadlineLbl;
        private System.Windows.Forms.Button CompleteEventBtn;
        private System.Windows.Forms.Label EventPointsLbl;
    }
}
