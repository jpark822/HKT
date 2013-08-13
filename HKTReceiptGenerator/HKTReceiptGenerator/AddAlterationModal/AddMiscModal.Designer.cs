namespace HKTReceiptGenerator.AddAlterationModal
{
    partial class AddMiscModal
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
            this.PatchBttn = new CustomControls.HKTStandardButton();
            this.CDCBttn = new CustomControls.HKTStandardButton();
            this.TieExtendShortenBttn = new CustomControls.HKTStandardButton();
            this.TieNarrowingBttn = new CustomControls.HKTStandardButton();
            this.CloseButton = new CustomControls.HKTStandardButton();
            this.SuspendLayout();
            // 
            // PatchBttn
            // 
            this.PatchBttn.BackColor = System.Drawing.Color.Maroon;
            this.PatchBttn.Font = new System.Drawing.Font("Trajan Pro", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PatchBttn.ForeColor = System.Drawing.Color.White;
            this.PatchBttn.Location = new System.Drawing.Point(20, 19);
            this.PatchBttn.Name = "PatchBttn";
            this.PatchBttn.Size = new System.Drawing.Size(246, 130);
            this.PatchBttn.TabIndex = 0;
            this.PatchBttn.Text = "Patch";
            this.PatchBttn.UseVisualStyleBackColor = false;
            this.PatchBttn.Click += new System.EventHandler(this.PatchBttn_Click);
            // 
            // CDCBttn
            // 
            this.CDCBttn.BackColor = System.Drawing.Color.Maroon;
            this.CDCBttn.Font = new System.Drawing.Font("Trajan Pro", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CDCBttn.ForeColor = System.Drawing.Color.White;
            this.CDCBttn.Location = new System.Drawing.Point(20, 155);
            this.CDCBttn.Name = "CDCBttn";
            this.CDCBttn.Size = new System.Drawing.Size(246, 130);
            this.CDCBttn.TabIndex = 1;
            this.CDCBttn.Text = "Public Health Service Braids On Sleeves";
            this.CDCBttn.UseVisualStyleBackColor = false;
            this.CDCBttn.Click += new System.EventHandler(this.CDCBttn_Click);
            // 
            // TieExtendShortenBttn
            // 
            this.TieExtendShortenBttn.BackColor = System.Drawing.Color.Maroon;
            this.TieExtendShortenBttn.Font = new System.Drawing.Font("Trajan Pro", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TieExtendShortenBttn.ForeColor = System.Drawing.Color.White;
            this.TieExtendShortenBttn.Location = new System.Drawing.Point(20, 291);
            this.TieExtendShortenBttn.Name = "TieExtendShortenBttn";
            this.TieExtendShortenBttn.Size = new System.Drawing.Size(246, 130);
            this.TieExtendShortenBttn.TabIndex = 2;
            this.TieExtendShortenBttn.Text = "Tie Extension / Shortening";
            this.TieExtendShortenBttn.UseVisualStyleBackColor = false;
            this.TieExtendShortenBttn.Click += new System.EventHandler(this.TieExtendShortenBttn_Click);
            // 
            // TieNarrowingBttn
            // 
            this.TieNarrowingBttn.BackColor = System.Drawing.Color.Maroon;
            this.TieNarrowingBttn.Font = new System.Drawing.Font("Trajan Pro", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TieNarrowingBttn.ForeColor = System.Drawing.Color.White;
            this.TieNarrowingBttn.Location = new System.Drawing.Point(20, 427);
            this.TieNarrowingBttn.Name = "TieNarrowingBttn";
            this.TieNarrowingBttn.Size = new System.Drawing.Size(246, 130);
            this.TieNarrowingBttn.TabIndex = 3;
            this.TieNarrowingBttn.Text = "Tie Narrowing";
            this.TieNarrowingBttn.UseVisualStyleBackColor = false;
            this.TieNarrowingBttn.Click += new System.EventHandler(this.TieNarrowingBttn_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.BackColor = System.Drawing.Color.Maroon;
            this.CloseButton.Font = new System.Drawing.Font("Trajan Pro", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseButton.ForeColor = System.Drawing.Color.White;
            this.CloseButton.Location = new System.Drawing.Point(294, 427);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(246, 130);
            this.CloseButton.TabIndex = 18;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // AddMiscModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(565, 578);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.TieNarrowingBttn);
            this.Controls.Add(this.TieExtendShortenBttn);
            this.Controls.Add(this.CDCBttn);
            this.Controls.Add(this.PatchBttn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddMiscModal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Miscellaneous Alterations";
            this.Load += new System.EventHandler(this.AddMiscModal_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CustomControls.HKTStandardButton PatchBttn;
        private CustomControls.HKTStandardButton CDCBttn;
        private CustomControls.HKTStandardButton TieExtendShortenBttn;
        private CustomControls.HKTStandardButton TieNarrowingBttn;
        private CustomControls.HKTStandardButton CloseButton;
    }
}