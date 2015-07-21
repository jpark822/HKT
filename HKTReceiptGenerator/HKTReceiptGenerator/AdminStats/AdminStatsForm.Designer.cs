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
            this.TotalTaxableLabel = new System.Windows.Forms.Label();
            this.TotalNonTaxableLabel = new System.Windows.Forms.Label();
            this.StartingDatePicker = new System.Windows.Forms.DateTimePicker();
            this.EndingDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.GetStatsButton = new CustomControls.HKTStandardButton();
            this.GetEmailsButton = new CustomControls.HKTStandardButton();
            this.EmailResultTextBox = new System.Windows.Forms.TextBox();
            this.CopyToClipboardButton = new CustomControls.HKTStandardButton();
            this.TotalPaidTaxableFromOrdersLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TotalPaidNonTaxableFromOrdersLabel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.TotalOrdersBilledLabel = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.TotalTicketsBilledLabel = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.AlterationsLabel = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.RetailLabel = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.AlterationsPlusRetailLabel = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.TaxablePlusNonTaxableOrdersLabel = new System.Windows.Forms.Label();
            this.getMailingAddressesButton = new CustomControls.HKTStandardButton();
            this.GetTicketsForDateButton = new CustomControls.HKTStandardButton();
            this.TicketsForDatePicker = new System.Windows.Forms.DateTimePicker();
            this.Save = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.CustomOrderDatePickerStart = new System.Windows.Forms.DateTimePicker();
            this.CustomOrderDatePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.GetCustomOrdersButton = new CustomControls.HKTStandardButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(265, 453);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total Billed:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(284, 513);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Total Paid:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(255, 473);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Total Taxable:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(207, 493);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Total Non-Taxable:";
            // 
            // TotalBilledLabel
            // 
            this.TotalBilledLabel.AutoSize = true;
            this.TotalBilledLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalBilledLabel.Location = new System.Drawing.Point(398, 453);
            this.TotalBilledLabel.Name = "TotalBilledLabel";
            this.TotalBilledLabel.Size = new System.Drawing.Size(49, 20);
            this.TotalBilledLabel.TabIndex = 6;
            this.TotalBilledLabel.Text = "$0.00";
            // 
            // TotalClosedLabel
            // 
            this.TotalClosedLabel.AutoSize = true;
            this.TotalClosedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalClosedLabel.Location = new System.Drawing.Point(398, 513);
            this.TotalClosedLabel.Name = "TotalClosedLabel";
            this.TotalClosedLabel.Size = new System.Drawing.Size(49, 20);
            this.TotalClosedLabel.TabIndex = 7;
            this.TotalClosedLabel.Text = "$0.00";
            // 
            // TotalTaxableLabel
            // 
            this.TotalTaxableLabel.AutoSize = true;
            this.TotalTaxableLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalTaxableLabel.Location = new System.Drawing.Point(399, 473);
            this.TotalTaxableLabel.Name = "TotalTaxableLabel";
            this.TotalTaxableLabel.Size = new System.Drawing.Size(49, 20);
            this.TotalTaxableLabel.TabIndex = 8;
            this.TotalTaxableLabel.Text = "$0.00";
            // 
            // TotalNonTaxableLabel
            // 
            this.TotalNonTaxableLabel.AutoSize = true;
            this.TotalNonTaxableLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalNonTaxableLabel.Location = new System.Drawing.Point(398, 493);
            this.TotalNonTaxableLabel.Name = "TotalNonTaxableLabel";
            this.TotalNonTaxableLabel.Size = new System.Drawing.Size(49, 20);
            this.TotalNonTaxableLabel.TabIndex = 11;
            this.TotalNonTaxableLabel.Text = "$0.00";
            // 
            // StartingDatePicker
            // 
            this.StartingDatePicker.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartingDatePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartingDatePicker.Location = new System.Drawing.Point(79, 67);
            this.StartingDatePicker.Name = "StartingDatePicker";
            this.StartingDatePicker.Size = new System.Drawing.Size(452, 35);
            this.StartingDatePicker.TabIndex = 12;
            this.StartingDatePicker.Value = new System.DateTime(2013, 5, 6, 0, 0, 0, 0);
            // 
            // EndingDatePicker
            // 
            this.EndingDatePicker.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EndingDatePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EndingDatePicker.Location = new System.Drawing.Point(538, 67);
            this.EndingDatePicker.Name = "EndingDatePicker";
            this.EndingDatePicker.Size = new System.Drawing.Size(452, 35);
            this.EndingDatePicker.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(216, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(151, 29);
            this.label7.TabIndex = 14;
            this.label7.Text = "Starting Date";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(683, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(145, 29);
            this.label8.TabIndex = 15;
            this.label8.Text = "Ending Date";
            // 
            // GetStatsButton
            // 
            this.GetStatsButton.BackColor = System.Drawing.Color.Maroon;
            this.GetStatsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.GetEmailsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GetEmailsButton.ForeColor = System.Drawing.Color.White;
            this.GetEmailsButton.Location = new System.Drawing.Point(538, 127);
            this.GetEmailsButton.Name = "GetEmailsButton";
            this.GetEmailsButton.Size = new System.Drawing.Size(402, 80);
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
            this.EmailResultTextBox.Size = new System.Drawing.Size(743, 227);
            this.EmailResultTextBox.TabIndex = 20;
            // 
            // CopyToClipboardButton
            // 
            this.CopyToClipboardButton.BackColor = System.Drawing.Color.Maroon;
            this.CopyToClipboardButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CopyToClipboardButton.ForeColor = System.Drawing.Color.White;
            this.CopyToClipboardButton.Location = new System.Drawing.Point(538, 462);
            this.CopyToClipboardButton.Name = "CopyToClipboardButton";
            this.CopyToClipboardButton.Size = new System.Drawing.Size(743, 80);
            this.CopyToClipboardButton.TabIndex = 21;
            this.CopyToClipboardButton.Text = "Export List To Excel";
            this.CopyToClipboardButton.UseVisualStyleBackColor = false;
            this.CopyToClipboardButton.Click += new System.EventHandler(this.CopyToClipboardButton_Click);
            // 
            // TotalPaidTaxableFromOrdersLabel
            // 
            this.TotalPaidTaxableFromOrdersLabel.AutoSize = true;
            this.TotalPaidTaxableFromOrdersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalPaidTaxableFromOrdersLabel.Location = new System.Drawing.Point(399, 367);
            this.TotalPaidTaxableFromOrdersLabel.Name = "TotalPaidTaxableFromOrdersLabel";
            this.TotalPaidTaxableFromOrdersLabel.Size = new System.Drawing.Size(49, 20);
            this.TotalPaidTaxableFromOrdersLabel.TabIndex = 23;
            this.TotalPaidTaxableFromOrdersLabel.Text = "$0.00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(198, 367);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(155, 20);
            this.label5.TabIndex = 24;
            this.label5.Text = "Taxable Orders Paid:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(151, 387);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(189, 20);
            this.label6.TabIndex = 26;
            this.label6.Text = "Non-Taxable Orders Paid:";
            // 
            // TotalPaidNonTaxableFromOrdersLabel
            // 
            this.TotalPaidNonTaxableFromOrdersLabel.AutoSize = true;
            this.TotalPaidNonTaxableFromOrdersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalPaidNonTaxableFromOrdersLabel.Location = new System.Drawing.Point(399, 387);
            this.TotalPaidNonTaxableFromOrdersLabel.Name = "TotalPaidNonTaxableFromOrdersLabel";
            this.TotalPaidNonTaxableFromOrdersLabel.Size = new System.Drawing.Size(49, 20);
            this.TotalPaidNonTaxableFromOrdersLabel.TabIndex = 25;
            this.TotalPaidNonTaxableFromOrdersLabel.Text = "$0.00";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(194, 347);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(142, 20);
            this.label9.TabIndex = 28;
            this.label9.Text = "Total Orders Billed:";
            // 
            // TotalOrdersBilledLabel
            // 
            this.TotalOrdersBilledLabel.AutoSize = true;
            this.TotalOrdersBilledLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalOrdersBilledLabel.Location = new System.Drawing.Point(399, 347);
            this.TotalOrdersBilledLabel.Name = "TotalOrdersBilledLabel";
            this.TotalOrdersBilledLabel.Size = new System.Drawing.Size(49, 20);
            this.TotalOrdersBilledLabel.TabIndex = 27;
            this.TotalOrdersBilledLabel.Text = "$0.00";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(194, 222);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(144, 20);
            this.label10.TabIndex = 34;
            this.label10.Text = "Total Tickets Billed:";
            // 
            // TotalTicketsBilledLabel
            // 
            this.TotalTicketsBilledLabel.AutoSize = true;
            this.TotalTicketsBilledLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalTicketsBilledLabel.Location = new System.Drawing.Point(398, 222);
            this.TotalTicketsBilledLabel.Name = "TotalTicketsBilledLabel";
            this.TotalTicketsBilledLabel.Size = new System.Drawing.Size(49, 20);
            this.TotalTicketsBilledLabel.TabIndex = 33;
            this.TotalTicketsBilledLabel.Text = "$0.00";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(228, 262);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(124, 20);
            this.label12.TabIndex = 32;
            this.label12.Text = "Alterations Paid:";
            // 
            // AlterationsLabel
            // 
            this.AlterationsLabel.AutoSize = true;
            this.AlterationsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AlterationsLabel.Location = new System.Drawing.Point(398, 262);
            this.AlterationsLabel.Name = "AlterationsLabel";
            this.AlterationsLabel.Size = new System.Drawing.Size(49, 20);
            this.AlterationsLabel.TabIndex = 31;
            this.AlterationsLabel.Text = "$0.00";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(281, 242);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(89, 20);
            this.label14.TabIndex = 30;
            this.label14.Text = "Retail Paid:";
            // 
            // RetailLabel
            // 
            this.RetailLabel.AutoSize = true;
            this.RetailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RetailLabel.Location = new System.Drawing.Point(398, 242);
            this.RetailLabel.Name = "RetailLabel";
            this.RetailLabel.Size = new System.Drawing.Size(49, 20);
            this.RetailLabel.TabIndex = 29;
            this.RetailLabel.Text = "$0.00";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(155, 282);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(182, 20);
            this.label11.TabIndex = 36;
            this.label11.Text = "Alterations + Retail Paid:";
            // 
            // AlterationsPlusRetailLabel
            // 
            this.AlterationsPlusRetailLabel.AutoSize = true;
            this.AlterationsPlusRetailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AlterationsPlusRetailLabel.Location = new System.Drawing.Point(398, 282);
            this.AlterationsPlusRetailLabel.Name = "AlterationsPlusRetailLabel";
            this.AlterationsPlusRetailLabel.Size = new System.Drawing.Size(49, 20);
            this.AlterationsPlusRetailLabel.TabIndex = 35;
            this.AlterationsPlusRetailLabel.Text = "$0.00";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(179, 407);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(174, 20);
            this.label13.TabIndex = 38;
            this.label13.Text = "Taxable + Non-Taxable:";
            // 
            // TaxablePlusNonTaxableOrdersLabel
            // 
            this.TaxablePlusNonTaxableOrdersLabel.AutoSize = true;
            this.TaxablePlusNonTaxableOrdersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaxablePlusNonTaxableOrdersLabel.Location = new System.Drawing.Point(398, 407);
            this.TaxablePlusNonTaxableOrdersLabel.Name = "TaxablePlusNonTaxableOrdersLabel";
            this.TaxablePlusNonTaxableOrdersLabel.Size = new System.Drawing.Size(49, 20);
            this.TaxablePlusNonTaxableOrdersLabel.TabIndex = 37;
            this.TaxablePlusNonTaxableOrdersLabel.Text = "$0.00";
            // 
            // getMailingAddressesButton
            // 
            this.getMailingAddressesButton.BackColor = System.Drawing.Color.Maroon;
            this.getMailingAddressesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.getMailingAddressesButton.ForeColor = System.Drawing.Color.White;
            this.getMailingAddressesButton.Location = new System.Drawing.Point(946, 127);
            this.getMailingAddressesButton.Name = "getMailingAddressesButton";
            this.getMailingAddressesButton.Size = new System.Drawing.Size(335, 80);
            this.getMailingAddressesButton.TabIndex = 39;
            this.getMailingAddressesButton.Text = "Get Mailing Addresses";
            this.getMailingAddressesButton.UseVisualStyleBackColor = false;
            this.getMailingAddressesButton.Click += new System.EventHandler(this.getMailingAddressesButton_Click);
            // 
            // GetTicketsForDateButton
            // 
            this.GetTicketsForDateButton.BackColor = System.Drawing.Color.Maroon;
            this.GetTicketsForDateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.GetTicketsForDateButton.ForeColor = System.Drawing.Color.White;
            this.GetTicketsForDateButton.Location = new System.Drawing.Point(80, 634);
            this.GetTicketsForDateButton.Name = "GetTicketsForDateButton";
            this.GetTicketsForDateButton.Size = new System.Drawing.Size(453, 83);
            this.GetTicketsForDateButton.TabIndex = 40;
            this.GetTicketsForDateButton.Text = "Get Tickets For Date";
            this.GetTicketsForDateButton.UseVisualStyleBackColor = false;
            this.GetTicketsForDateButton.Click += new System.EventHandler(this.GetTicketsForDateButton_Click);
            // 
            // TicketsForDatePicker
            // 
            this.TicketsForDatePicker.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TicketsForDatePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TicketsForDatePicker.Location = new System.Drawing.Point(80, 590);
            this.TicketsForDatePicker.Name = "TicketsForDatePicker";
            this.TicketsForDatePicker.Size = new System.Drawing.Size(452, 35);
            this.TicketsForDatePicker.TabIndex = 41;
            this.TicketsForDatePicker.Value = new System.DateTime(2013, 5, 6, 0, 0, 0, 0);
            // 
            // Save
            // 
            this.Save.BackColor = System.Drawing.Color.Maroon;
            this.Save.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Save.ForeColor = System.Drawing.Color.White;
            this.Save.Location = new System.Drawing.Point(298, 787);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(128, 44);
            this.Save.TabIndex = 42;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = false;
            this.Save.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(155, 790);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(137, 35);
            this.textBox1.TabIndex = 43;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label15.Location = new System.Drawing.Point(110, 752);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(374, 29);
            this.label15.TabIndex = 44;
            this.label15.Text = "Max Alerations Per Day in Dollars ";
            // 
            // CustomOrderDatePickerStart
            // 
            this.CustomOrderDatePickerStart.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomOrderDatePickerStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomOrderDatePickerStart.Location = new System.Drawing.Point(610, 590);
            this.CustomOrderDatePickerStart.Name = "CustomOrderDatePickerStart";
            this.CustomOrderDatePickerStart.Size = new System.Drawing.Size(319, 29);
            this.CustomOrderDatePickerStart.TabIndex = 45;
            // 
            // CustomOrderDatePickerEnd
            // 
            this.CustomOrderDatePickerEnd.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomOrderDatePickerEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomOrderDatePickerEnd.Location = new System.Drawing.Point(935, 590);
            this.CustomOrderDatePickerEnd.Name = "CustomOrderDatePickerEnd";
            this.CustomOrderDatePickerEnd.Size = new System.Drawing.Size(319, 29);
            this.CustomOrderDatePickerEnd.TabIndex = 46;
            // 
            // GetCustomOrdersButton
            // 
            this.GetCustomOrdersButton.BackColor = System.Drawing.Color.Maroon;
            this.GetCustomOrdersButton.Font = new System.Drawing.Font("Trajan Pro", 14F);
            this.GetCustomOrdersButton.ForeColor = System.Drawing.Color.White;
            this.GetCustomOrdersButton.Location = new System.Drawing.Point(610, 634);
            this.GetCustomOrdersButton.Name = "GetCustomOrdersButton";
            this.GetCustomOrdersButton.Size = new System.Drawing.Size(644, 83);
            this.GetCustomOrdersButton.TabIndex = 47;
            this.GetCustomOrdersButton.Text = "Get Custom Orders Between Dates";
            this.GetCustomOrdersButton.UseVisualStyleBackColor = false;
            this.GetCustomOrdersButton.Click += new System.EventHandler(this.GetCustomOrdersButton_Click);
            // 
            // AdminStatsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1309, 855);
            this.Controls.Add(this.GetCustomOrdersButton);
            this.Controls.Add(this.CustomOrderDatePickerEnd);
            this.Controls.Add(this.CustomOrderDatePickerStart);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.TicketsForDatePicker);
            this.Controls.Add(this.GetTicketsForDateButton);
            this.Controls.Add(this.getMailingAddressesButton);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.TaxablePlusNonTaxableOrdersLabel);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.AlterationsPlusRetailLabel);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.TotalTicketsBilledLabel);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.AlterationsLabel);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.RetailLabel);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.TotalOrdersBilledLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TotalPaidNonTaxableFromOrdersLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TotalPaidTaxableFromOrdersLabel);
            this.Controls.Add(this.CopyToClipboardButton);
            this.Controls.Add(this.EmailResultTextBox);
            this.Controls.Add(this.GetEmailsButton);
            this.Controls.Add(this.GetStatsButton);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.EndingDatePicker);
            this.Controls.Add(this.StartingDatePicker);
            this.Controls.Add(this.TotalNonTaxableLabel);
            this.Controls.Add(this.TotalTaxableLabel);
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
        private System.Windows.Forms.Label TotalTaxableLabel;
        private System.Windows.Forms.Label TotalNonTaxableLabel;
        private System.Windows.Forms.DateTimePicker StartingDatePicker;
        private System.Windows.Forms.DateTimePicker EndingDatePicker;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private CustomControls.HKTStandardButton GetStatsButton;
        private CustomControls.HKTStandardButton GetEmailsButton;
        private System.Windows.Forms.TextBox EmailResultTextBox;
        private CustomControls.HKTStandardButton CopyToClipboardButton;
        private System.Windows.Forms.Label TotalPaidTaxableFromOrdersLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label TotalPaidNonTaxableFromOrdersLabel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label TotalOrdersBilledLabel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label TotalTicketsBilledLabel;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label AlterationsLabel;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label RetailLabel;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label AlterationsPlusRetailLabel;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label TaxablePlusNonTaxableOrdersLabel;
        private CustomControls.HKTStandardButton getMailingAddressesButton;
        private CustomControls.HKTStandardButton GetTicketsForDateButton;
        private System.Windows.Forms.DateTimePicker TicketsForDatePicker;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker CustomOrderDatePickerStart;
        private System.Windows.Forms.DateTimePicker CustomOrderDatePickerEnd;
        private CustomControls.HKTStandardButton GetCustomOrdersButton;
    }
}