namespace HKTReceiptGenerator.AddAlterationModal
{
    partial class AddShirtModal
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
            this.TaperSidesButton = new CustomControls.HKTStandardButton();
            this.ShortenSleevesButton = new CustomControls.HKTStandardButton();
            this.ShortenLengthButton = new CustomControls.HKTStandardButton();
            this.DartsButton = new CustomControls.HKTStandardButton();
            this.CloseButton = new CustomControls.HKTStandardButton();
            this.SuspendLayout();
            // 
            // TaperSidesButton
            // 
            this.TaperSidesButton.BackColor = System.Drawing.Color.Maroon;
            this.TaperSidesButton.Font = new System.Drawing.Font("Trajan Pro", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaperSidesButton.ForeColor = System.Drawing.Color.White;
            this.TaperSidesButton.Location = new System.Drawing.Point(17, 21);
            this.TaperSidesButton.Name = "TaperSidesButton";
            this.TaperSidesButton.Size = new System.Drawing.Size(246, 130);
            this.TaperSidesButton.TabIndex = 0;
            this.TaperSidesButton.Text = "Taper Sides";
            this.TaperSidesButton.UseVisualStyleBackColor = false;
            this.TaperSidesButton.Click += new System.EventHandler(this.TaperSidesButton_Click);
            // 
            // ShortenSleevesButton
            // 
            this.ShortenSleevesButton.BackColor = System.Drawing.Color.Maroon;
            this.ShortenSleevesButton.Font = new System.Drawing.Font("Trajan Pro", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShortenSleevesButton.ForeColor = System.Drawing.Color.White;
            this.ShortenSleevesButton.Location = new System.Drawing.Point(17, 157);
            this.ShortenSleevesButton.Name = "ShortenSleevesButton";
            this.ShortenSleevesButton.Size = new System.Drawing.Size(246, 130);
            this.ShortenSleevesButton.TabIndex = 1;
            this.ShortenSleevesButton.Text = "Shorten Sleeves";
            this.ShortenSleevesButton.UseVisualStyleBackColor = false;
            this.ShortenSleevesButton.Click += new System.EventHandler(this.ShortenSleevesButton_Click);
            // 
            // ShortenLengthButton
            // 
            this.ShortenLengthButton.BackColor = System.Drawing.Color.Maroon;
            this.ShortenLengthButton.Font = new System.Drawing.Font("Trajan Pro", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShortenLengthButton.ForeColor = System.Drawing.Color.White;
            this.ShortenLengthButton.Location = new System.Drawing.Point(17, 293);
            this.ShortenLengthButton.Name = "ShortenLengthButton";
            this.ShortenLengthButton.Size = new System.Drawing.Size(246, 130);
            this.ShortenLengthButton.TabIndex = 2;
            this.ShortenLengthButton.Text = "Shorten Length";
            this.ShortenLengthButton.UseVisualStyleBackColor = false;
            this.ShortenLengthButton.Click += new System.EventHandler(this.ShortenLengthButton_Click);
            // 
            // DartsButton
            // 
            this.DartsButton.BackColor = System.Drawing.Color.Maroon;
            this.DartsButton.Font = new System.Drawing.Font("Trajan Pro", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DartsButton.ForeColor = System.Drawing.Color.White;
            this.DartsButton.Location = new System.Drawing.Point(17, 429);
            this.DartsButton.Name = "DartsButton";
            this.DartsButton.Size = new System.Drawing.Size(246, 130);
            this.DartsButton.TabIndex = 3;
            this.DartsButton.Text = "Darts";
            this.DartsButton.UseVisualStyleBackColor = false;
            this.DartsButton.Click += new System.EventHandler(this.DartsButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.BackColor = System.Drawing.Color.Maroon;
            this.CloseButton.Font = new System.Drawing.Font("Trajan Pro", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseButton.ForeColor = System.Drawing.Color.White;
            this.CloseButton.Location = new System.Drawing.Point(283, 429);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(246, 130);
            this.CloseButton.TabIndex = 18;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // AddShirtModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(549, 586);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.DartsButton);
            this.Controls.Add(this.ShortenLengthButton);
            this.Controls.Add(this.ShortenSleevesButton);
            this.Controls.Add(this.TaperSidesButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AddShirtModal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Shirt Alterations";
            this.Load += new System.EventHandler(this.AddShirtModal_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CustomControls.HKTStandardButton TaperSidesButton;
        private CustomControls.HKTStandardButton ShortenSleevesButton;
        private CustomControls.HKTStandardButton ShortenLengthButton;
        private CustomControls.HKTStandardButton DartsButton;
        private CustomControls.HKTStandardButton CloseButton;
    }
}