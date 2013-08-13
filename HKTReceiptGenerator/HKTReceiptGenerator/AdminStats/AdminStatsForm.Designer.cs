namespace HKTReceiptGenerator.AdminStats
{
    partial class AdminStatsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TotalBilledLabel = new System.Windows.Forms.Label();
            this.TotalClosedLabel = new System.Windows.Forms.Label();
            this.RetailLabel = new System.Windows.Forms.Label();
            this.AlterationsLabel = new System.Windows.Forms.Label();
            this.StartingDatePicker = new System.Windows.Forms.DateTimePicker();
            this.EndingDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.GetStatsButton = new CustomControls.HKTStandardButton();
            this.GetEmailsButton = new CustomControls.HKTStandardButton();
            this.EmailResultTextBox = new System.Windows.Forms.TextBox();
            this.CopyToClipboardButton = new CustomControls.HKTStandardButton();
            this.BackupButton = new CustomControls.HKTStandardButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trajan Pro", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(264, 225);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total Billed:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trajan Pro", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(85, 292);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(306, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Total Paid (Alterations + Retail):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Trajan Pro", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(323, 247);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Retail:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Trajan Pro", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(270, 270);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Alterations:";
            // 
            // TotalBilledLabel
            // 
            this.TotalBilledLabel.AutoSize = true;
            this.TotalBilledLabel.Font = new System.Drawing.Font("Trajan Pro", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalBilledLabel.Location = new System.Drawing.Point(397, 225);
            this.TotalBilledLabel.Name = "TotalBilledLabel";
            this.TotalBilledLabel.Size = new System.Drawing.Size(49, 20);
            this.TotalBilledLabel.TabIndex = 6;
            this.TotalBilledLabel.Text = "$0.00";
            // 
            // TotalClosedLabel
            // 
            this.TotalClosedLabel.AutoSize = true;
            this.TotalClosedLabel.Font = new System.Drawing.Font("Trajan Pro", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalClosedLabel.Location = new System.Drawing.Point(397, 292);
            this.TotalClosedLabel.Name = "TotalClosedLabel";
            this.TotalClosedLabel.Size = new System.Drawing.Size(49, 20);
            this.TotalClosedLabel.TabIndex = 7;
            this.TotalClosedLabel.Text = "$0.00";
            // 
            // RetailLabel
            // 
            this.RetailLabel.AutoSize = true;
            this.RetailLabel.Font = new System.Drawing.Font("Trajan Pro", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RetailLabel.Location = new System.Drawing.Point(397, 247);
            this.RetailLabel.Name = "RetailLabel";
            this.RetailLabel.Size = new System.Drawing.Size(49, 20);
            this.RetailLabel.TabIndex = 8;
            this.RetailLabel.Text = "$0.00";
            // 
            // AlterationsLabel
            // 
            this.AlterationsLabel.AutoSize = true;
            this.AlterationsLabel.Font = new System.Drawing.Font("Trajan Pro", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AlterationsLabel.Location = new System.Drawing.Point(397, 270);
            this.AlterationsLabel.Name = "AlterationsLabel";
            this.AlterationsLabel.Size = new System.Drawing.Size(49, 20);
            this.AlterationsLabel.TabIndex = 11;
            this.AlterationsLabel.Text = "$0.00";
            // 
            // StartingDatePicker
            // 
            this.StartingDatePicker.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartingDatePicker.Font = new System.Drawing.Font("Trajan Pro", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartingDatePicker.Location = new System.Drawing.Point(79, 67);
            this.StartingDatePicker.Name = "StartingDatePicker";
            this.StartingDatePicker.Size = new System.Drawing.Size(452, 38);
            this.StartingDatePicker.TabIndex = 12;
            this.StartingDatePicker.Value = new System.DateTime(2013, 5, 6, 0, 0, 0, 0);
            // 
            // EndingDatePicker
            // 
            this.EndingDatePicker.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EndingDatePicker.Font = new System.Drawing.Font("Trajan Pro", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EndingDatePicker.Location = new System.Drawing.Point(538, 67);
            this.EndingDatePicker.Name = "EndingDatePicker";
            this.EndingDatePicker.Size = new System.Drawing.Size(452, 38);
            this.EndingDatePicker.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Trajan Pro", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(216, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(204, 30);
            this.label7.TabIndex = 14;
            this.label7.Text = "Starting Date";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Trajan Pro", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(683, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(185, 30);
            this.label8.TabIndex = 15;
            this.label8.Text = "Ending Date";
            // 
            // GetStatsButton
            // 
            this.GetStatsButton.BackColor = System.Drawing.Color.Maroon;
            this.GetStatsButton.Font = new System.Drawing.Font("Trajan Pro", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GetStatsButton.ForeColor = System.Drawing.Color.White;
            this.GetStatsButton.Location = new System.Drawing.Point(80, 127);
            this.GetStatsButton.Name = "GetStatsButton";
            this.GetStatsButton.Size = new System.Drawing.Size(452, 80);
            this.GetStatsButton.TabIndex = 16;
            this.GetStatsButton.Text = "Get Stats";
            this.GetStatsButton.UseVisualStyleBackColor = false;
            this.GetStatsButton.Click += new System.EventHandler(this.GetStatsButton_Click);
            // 
            // GetEmailsButton
            // 
            this.GetEmailsButton.BackColor = System.Drawing.Color.Maroon;
            this.GetEmailsButton.Font = new System.Drawing.Font("Trajan Pro", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GetEmailsButton.ForeColor = System.Drawing.Color.White;
            this.GetEmailsButton.Location = new System.Drawing.Point(538, 127);
            this.GetEmailsButton.Name = "GetEmailsButton";
            this.GetEmailsButton.Size = new System.Drawing.Size(452, 80);
            this.GetEmailsButton.TabIndex = 19;
            this.GetEmailsButton.Text = "Get Email Addresses";
            this.GetEmailsButton.UseVisualStyleBackColor = false;
            this.GetEmailsButton.Click += new System.EventHandler(this.GetEmailsButton_Click);
            // 
            // EmailResultTextBox
            // 
            this.EmailResultTextBox.Location = new System.Drawing.Point(538, 222);
            this.EmailResultTextBox.Multiline = true;
            this.EmailResultTextBox.Name = "EmailResultTextBox";
            this.EmailResultTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.EmailResultTextBox.Size = new System.Drawing.Size(452, 227);
            this.EmailResultTextBox.TabIndex = 20;
            // 
            // CopyToClipboardButton
            // 
            this.CopyToClipboardButton.BackColor = System.Drawing.Color.Maroon;
            this.CopyToClipboardButton.Font = new System.Drawing.Font("Trajan Pro", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CopyToClipboardButton.ForeColor = System.Drawing.Color.White;
            this.CopyToClipboardButton.Location = new System.Drawing.Point(538, 467);
            this.CopyToClipboardButton.Name = "CopyToClipboardButton";
            this.CopyToClipboardButton.Size = new System.Drawing.Size(452, 80);
            this.CopyToClipboardButton.TabIndex = 21;
            this.CopyToClipboardButton.Text = "Copy Addresses to Clipboard";
            this.CopyToClipboardButton.UseVisualStyleBackColor = false;
            this.CopyToClipboardButton.Click += new System.EventHandler(this.CopyToClipboardButton_Click);
            // 
            // BackupButton
            // 
            this.BackupButton.BackColor = System.Drawing.Color.Maroon;
            this.BackupButton.Font = new System.Drawing.Font("Trajan Pro", 14F);
            this.BackupButton.ForeColor = System.Drawing.Color.White;
            this.BackupButton.Location = new System.Drawing.Point(1036, 467);
            this.BackupButton.Name = "BackupButton";
            this.BackupButton.Size = new System.Drawing.Size(245, 80);
            this.BackupButton.TabIndex = 22;
            this.BackupButton.Text = "Backup Database";
            this.BackupButton.UseVisualStyleBackColor = false;
            this.BackupButton.Click += new System.EventHandler(this.BackupButton_Click);
            // 
            // AdminStatsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1309, 606);
            this.Controls.Add(this.BackupButton);
            this.Controls.Add(this.CopyToClipboardButton);
            this.Controls.Add(this.EmailResultTextBox);
            this.Controls.Add(this.GetEmailsButton);
            this.Controls.Add(this.GetStatsButton);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.EndingDatePicker);
            this.Controls.Add(this.StartingDatePicker);
            this.Controls.Add(this.AlterationsLabel);
            this.Controls.Add(this.RetailLabel);
            this.Controls.Add(this.TotalClosedLabel);
            this.Controls.Add(this.TotalBilledLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AdminStatsForm";
            this.Text = "AdminStatsForm";
            this.Load += new System.EventHandler(this.AdminStatsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label TotalBilledLabel;
        private System.Windows.Forms.Label TotalClosedLabel;
        private System.Windows.Forms.Label RetailLabel;
        private System.Windows.Forms.Label AlterationsLabel;
        private System.Windows.Forms.DateTimePicker StartingDatePicker;
        private System.Windows.Forms.DateTimePicker EndingDatePicker;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private CustomControls.HKTStandardButton GetStatsButton;
        private CustomControls.HKTStandardButton GetEmailsButton;
        private System.Windows.Forms.TextBox EmailResultTextBox;
        private CustomControls.HKTStandardButton CopyToClipboardButton;
        private CustomControls.HKTStandardButton BackupButton;
    }
}