namespace HKTReceiptGenerator.AddAlterationModal
{
    partial class AddVestModal
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
            this.TaperBttn = new CustomControls.HKTStandardButton();
            this.BackPanelBttn = new CustomControls.HKTStandardButton();
            this.ShortenBttn = new CustomControls.HKTStandardButton();
            this.CloseButton = new CustomControls.HKTStandardButton();
            this.SuspendLayout();
            // 
            // TaperBttn
            // 
            this.TaperBttn.BackColor = System.Drawing.Color.Maroon;
            this.TaperBttn.Font = new System.Drawing.Font("Trajan Pro", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaperBttn.ForeColor = System.Drawing.Color.White;
            this.TaperBttn.Location = new System.Drawing.Point(19, 22);
            this.TaperBttn.Name = "TaperBttn";
            this.TaperBttn.Size = new System.Drawing.Size(246, 130);
            this.TaperBttn.TabIndex = 0;
            this.TaperBttn.Text = "Taper Sides";
            this.TaperBttn.UseVisualStyleBackColor = false;
            this.TaperBttn.Click += new System.EventHandler(this.TaperBttn_Click);
            // 
            // BackPanelBttn
            // 
            this.BackPanelBttn.BackColor = System.Drawing.Color.Maroon;
            this.BackPanelBttn.Font = new System.Drawing.Font("Trajan Pro", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackPanelBttn.ForeColor = System.Drawing.Color.White;
            this.BackPanelBttn.Location = new System.Drawing.Point(19, 158);
            this.BackPanelBttn.Name = "BackPanelBttn";
            this.BackPanelBttn.Size = new System.Drawing.Size(246, 130);
            this.BackPanelBttn.TabIndex = 1;
            this.BackPanelBttn.Text = "New Back Panel";
            this.BackPanelBttn.UseVisualStyleBackColor = false;
            this.BackPanelBttn.Click += new System.EventHandler(this.BackPanelBttn_Click);
            // 
            // ShortenBttn
            // 
            this.ShortenBttn.BackColor = System.Drawing.Color.Maroon;
            this.ShortenBttn.Font = new System.Drawing.Font("Trajan Pro", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShortenBttn.ForeColor = System.Drawing.Color.White;
            this.ShortenBttn.Location = new System.Drawing.Point(19, 294);
            this.ShortenBttn.Name = "ShortenBttn";
            this.ShortenBttn.Size = new System.Drawing.Size(246, 130);
            this.ShortenBttn.TabIndex = 2;
            this.ShortenBttn.Text = "Shorten Length";
            this.ShortenBttn.UseVisualStyleBackColor = false;
            this.ShortenBttn.Click += new System.EventHandler(this.ShortenBttn_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.BackColor = System.Drawing.Color.Maroon;
            this.CloseButton.Font = new System.Drawing.Font("Trajan Pro", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseButton.ForeColor = System.Drawing.Color.White;
            this.CloseButton.Location = new System.Drawing.Point(286, 294);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(246, 130);
            this.CloseButton.TabIndex = 3;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // AddVestModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(554, 453);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.ShortenBttn);
            this.Controls.Add(this.BackPanelBttn);
            this.Controls.Add(this.TaperBttn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddVestModal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Vest Alterations";
            this.Load += new System.EventHandler(this.AddVestModal_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CustomControls.HKTStandardButton TaperBttn;
        private CustomControls.HKTStandardButton BackPanelBttn;
        private CustomControls.HKTStandardButton ShortenBttn;
        private CustomControls.HKTStandardButton CloseButton;
    }
}