namespace StudentWiseClient
{
    partial class EventComponentAddParticipant
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EventComponentAddParticipant));
            this.DeleteEventPbx = new System.Windows.Forms.PictureBox();
            this.EventCompletePbx = new System.Windows.Forms.PictureBox();
            this.EventDeadlineLbl = new System.Windows.Forms.Label();
            this.ImagePbx = new System.Windows.Forms.PictureBox();
            this.EventTypeLbl = new System.Windows.Forms.Label();
            this.EventTitleLbl = new System.Windows.Forms.Label();
            this.EventDescriptionLbl = new System.Windows.Forms.Label();
            this.ParticipantsCmb = new System.Windows.Forms.ComboBox();
            this.AddParticipantBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DeleteEventPbx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EventCompletePbx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImagePbx)).BeginInit();
            this.SuspendLayout();
            // 
            // DeleteEventPbx
            // 
            this.DeleteEventPbx.BackColor = System.Drawing.Color.Red;
            this.DeleteEventPbx.Image = ((System.Drawing.Image)(resources.GetObject("DeleteEventPbx.Image")));
            this.DeleteEventPbx.Location = new System.Drawing.Point(338, 240);
            this.DeleteEventPbx.Name = "DeleteEventPbx";
            this.DeleteEventPbx.Size = new System.Drawing.Size(109, 100);
            this.DeleteEventPbx.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.DeleteEventPbx.TabIndex = 10;
            this.DeleteEventPbx.TabStop = false;
            this.DeleteEventPbx.Click += new System.EventHandler(this.DeleteEventPbx_Click);
            // 
            // EventCompletePbx
            // 
            this.EventCompletePbx.BackColor = System.Drawing.Color.LawnGreen;
            this.EventCompletePbx.Image = global::StudentWiseClient.Properties.Resources.kisspng_check_mark_symbol_icon_black_checkmark_5a76d35a732948_8416047115177367944717;
            this.EventCompletePbx.Location = new System.Drawing.Point(453, 240);
            this.EventCompletePbx.Name = "EventCompletePbx";
            this.EventCompletePbx.Size = new System.Drawing.Size(108, 100);
            this.EventCompletePbx.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.EventCompletePbx.TabIndex = 11;
            this.EventCompletePbx.TabStop = false;
            this.EventCompletePbx.Click += new System.EventHandler(this.EventCompletePbx_Click);
            // 
            // EventDeadlineLbl
            // 
            this.EventDeadlineLbl.Font = new System.Drawing.Font("Oswald", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EventDeadlineLbl.Location = new System.Drawing.Point(355, 26);
            this.EventDeadlineLbl.Name = "EventDeadlineLbl";
            this.EventDeadlineLbl.Size = new System.Drawing.Size(206, 66);
            this.EventDeadlineLbl.TabIndex = 12;
            this.EventDeadlineLbl.Text = "Start Date and End Date";
            // 
            // ImagePbx
            // 
            this.ImagePbx.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ImagePbx.Location = new System.Drawing.Point(23, 26);
            this.ImagePbx.Name = "ImagePbx";
            this.ImagePbx.Size = new System.Drawing.Size(106, 102);
            this.ImagePbx.TabIndex = 13;
            this.ImagePbx.TabStop = false;
            // 
            // EventTypeLbl
            // 
            this.EventTypeLbl.AutoSize = true;
            this.EventTypeLbl.Font = new System.Drawing.Font("Oswald", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EventTypeLbl.Location = new System.Drawing.Point(146, 60);
            this.EventTypeLbl.Name = "EventTypeLbl";
            this.EventTypeLbl.Size = new System.Drawing.Size(87, 32);
            this.EventTypeLbl.TabIndex = 14;
            this.EventTypeLbl.Text = "Event Type";
            // 
            // EventTitleLbl
            // 
            this.EventTitleLbl.AutoSize = true;
            this.EventTitleLbl.Font = new System.Drawing.Font("Oswald", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EventTitleLbl.Location = new System.Drawing.Point(145, 87);
            this.EventTitleLbl.Name = "EventTitleLbl";
            this.EventTitleLbl.Size = new System.Drawing.Size(121, 41);
            this.EventTitleLbl.TabIndex = 15;
            this.EventTitleLbl.Text = "Event Title";
            // 
            // EventDescriptionLbl
            // 
            this.EventDescriptionLbl.Font = new System.Drawing.Font("Oswald", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EventDescriptionLbl.Location = new System.Drawing.Point(17, 153);
            this.EventDescriptionLbl.Name = "EventDescriptionLbl";
            this.EventDescriptionLbl.Size = new System.Drawing.Size(567, 65);
            this.EventDescriptionLbl.TabIndex = 16;
            this.EventDescriptionLbl.Text = "Event Description";
            // 
            // ParticipantsCmb
            // 
            this.ParticipantsCmb.Font = new System.Drawing.Font("Oswald", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ParticipantsCmb.FormattingEnabled = true;
            this.ParticipantsCmb.Location = new System.Drawing.Point(23, 240);
            this.ParticipantsCmb.Name = "ParticipantsCmb";
            this.ParticipantsCmb.Size = new System.Drawing.Size(243, 39);
            this.ParticipantsCmb.TabIndex = 17;
            // 
            // AddParticipantBtn
            // 
            this.AddParticipantBtn.Font = new System.Drawing.Font("Oswald", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddParticipantBtn.Location = new System.Drawing.Point(23, 285);
            this.AddParticipantBtn.Name = "AddParticipantBtn";
            this.AddParticipantBtn.Size = new System.Drawing.Size(243, 43);
            this.AddParticipantBtn.TabIndex = 18;
            this.AddParticipantBtn.Text = "Add Participant";
            this.AddParticipantBtn.UseVisualStyleBackColor = true;
            this.AddParticipantBtn.Click += new System.EventHandler(this.AddParticipantBtn_Click);
            // 
            // EventComponentAddParticipant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.AddParticipantBtn);
            this.Controls.Add(this.ParticipantsCmb);
            this.Controls.Add(this.EventDescriptionLbl);
            this.Controls.Add(this.EventTitleLbl);
            this.Controls.Add(this.EventTypeLbl);
            this.Controls.Add(this.ImagePbx);
            this.Controls.Add(this.EventDeadlineLbl);
            this.Controls.Add(this.EventCompletePbx);
            this.Controls.Add(this.DeleteEventPbx);
            this.Name = "EventComponentAddParticipant";
            this.Size = new System.Drawing.Size(579, 361);
            ((System.ComponentModel.ISupportInitialize)(this.DeleteEventPbx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EventCompletePbx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImagePbx)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox DeleteEventPbx;
        private System.Windows.Forms.PictureBox EventCompletePbx;
        private System.Windows.Forms.Label EventDeadlineLbl;
        private System.Windows.Forms.PictureBox ImagePbx;
        private System.Windows.Forms.Label EventTypeLbl;
        private System.Windows.Forms.Label EventTitleLbl;
        private System.Windows.Forms.Label EventDescriptionLbl;
        private System.Windows.Forms.ComboBox ParticipantsCmb;
        private System.Windows.Forms.Button AddParticipantBtn;
    }
}
