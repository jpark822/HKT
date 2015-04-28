namespace HKTReceiptGenerator
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.CustomerButton = new CustomControls.HKTStandardButton();
            this.SearchButton = new CustomControls.HKTStandardButton();
            this.AdminStatsButton = new CustomControls.HKTStandardButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // CustomerButton
            // 
            this.CustomerButton.BackColor = System.Drawing.Color.Maroon;
            this.CustomerButton.Font = new System.Drawing.Font("Trajan Pro", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomerButton.ForeColor = System.Drawing.Color.White;
            this.CustomerButton.Location = new System.Drawing.Point(45, 445);
            this.CustomerButton.Name = "CustomerButton";
            this.CustomerButton.Size = new System.Drawing.Size(197, 100);
            this.CustomerButton.TabIndex = 0;
            this.CustomerButton.Text = "Customers";
            this.CustomerButton.UseVisualStyleBackColor = false;
            this.CustomerButton.Click += new System.EventHandler(this.NewTicketBttn_Click);
            // 
            // SearchButton
            // 
            this.SearchButton.BackColor = System.Drawing.Color.Maroon;
            this.SearchButton.Font = new System.Drawing.Font("Trajan Pro", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchButton.ForeColor = System.Drawing.Color.White;
            this.SearchButton.Location = new System.Drawing.Point(302, 445);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(197, 100);
            this.SearchButton.TabIndex = 1;
            this.SearchButton.Text = "Ticket Search";
            this.SearchButton.UseVisualStyleBackColor = false;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // AdminStatsButton
            // 
            this.AdminStatsButton.BackColor = System.Drawing.Color.Maroon;
            this.AdminStatsButton.Font = new System.Drawing.Font("Trajan Pro", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AdminStatsButton.ForeColor = System.Drawing.Color.White;
            this.AdminStatsButton.Location = new System.Drawing.Point(556, 445);
            this.AdminStatsButton.Name = "AdminStatsButton";
            this.AdminStatsButton.Size = new System.Drawing.Size(197, 100);
            this.AdminStatsButton.TabIndex = 2;
            this.AdminStatsButton.Text = "Admin Stats";
            this.AdminStatsButton.UseVisualStyleBackColor = false;
            this.AdminStatsButton.Click += new System.EventHandler(this.AdminStatsButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-137, 150);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(800, 571);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(797, 571);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.AdminStatsButton);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.CustomerButton);
            this.Controls.Add(this.pictureBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomControls.HKTStandardButton CustomerButton;
        private CustomControls.HKTStandardButton SearchButton;
        private CustomControls.HKTStandardButton AdminStatsButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}