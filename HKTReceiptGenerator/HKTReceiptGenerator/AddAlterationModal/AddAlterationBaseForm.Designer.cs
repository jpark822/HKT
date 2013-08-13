using CustomControls;
namespace HKTReceiptGenerator.AddAlterationModal
{
    partial class AddAlterationBaseForm
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
            this.JacketButton = new CustomControls.HKTStandardButton();
            this.ShirtButton = new CustomControls.HKTStandardButton();
            this.PantsButton = new CustomControls.HKTStandardButton();
            this.VestBttn = new CustomControls.HKTStandardButton();
            this.MiscellaneousBttn = new CustomControls.HKTStandardButton();
            this.AddOtherAlterationButton = new CustomControls.HKTStandardButton();
            this.SuspendLayout();
            // 
            // JacketButton
            // 
            this.JacketButton.BackColor = System.Drawing.Color.Maroon;
            this.JacketButton.Font = new System.Drawing.Font("Trajan Pro", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JacketButton.ForeColor = System.Drawing.Color.White;
            this.JacketButton.Location = new System.Drawing.Point(44, 42);
            this.JacketButton.Name = "JacketButton";
            this.JacketButton.Size = new System.Drawing.Size(317, 184);
            this.JacketButton.TabIndex = 0;
            this.JacketButton.Text = "Jacket";
            this.JacketButton.UseVisualStyleBackColor = false;
            this.JacketButton.Click += new System.EventHandler(this.JacketButton_Click);
            // 
            // ShirtButton
            // 
            this.ShirtButton.BackColor = System.Drawing.Color.Maroon;
            this.ShirtButton.Font = new System.Drawing.Font("Trajan Pro", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShirtButton.ForeColor = System.Drawing.Color.White;
            this.ShirtButton.Location = new System.Drawing.Point(391, 37);
            this.ShirtButton.Name = "ShirtButton";
            this.ShirtButton.Size = new System.Drawing.Size(317, 195);
            this.ShirtButton.TabIndex = 1;
            this.ShirtButton.Text = "Shirt";
            this.ShirtButton.UseVisualStyleBackColor = false;
            this.ShirtButton.Click += new System.EventHandler(this.ShirtButton_Click);
            // 
            // PantsButton
            // 
            this.PantsButton.BackColor = System.Drawing.Color.Maroon;
            this.PantsButton.Font = new System.Drawing.Font("Trajan Pro", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PantsButton.ForeColor = System.Drawing.Color.White;
            this.PantsButton.Location = new System.Drawing.Point(44, 245);
            this.PantsButton.Name = "PantsButton";
            this.PantsButton.Size = new System.Drawing.Size(317, 193);
            this.PantsButton.TabIndex = 2;
            this.PantsButton.Text = "Pants";
            this.PantsButton.UseVisualStyleBackColor = false;
            this.PantsButton.Click += new System.EventHandler(this.PantsButton_Click);
            // 
            // VestBttn
            // 
            this.VestBttn.BackColor = System.Drawing.Color.Maroon;
            this.VestBttn.Font = new System.Drawing.Font("Trajan Pro", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VestBttn.ForeColor = System.Drawing.Color.White;
            this.VestBttn.Location = new System.Drawing.Point(391, 245);
            this.VestBttn.Name = "VestBttn";
            this.VestBttn.Size = new System.Drawing.Size(317, 193);
            this.VestBttn.TabIndex = 3;
            this.VestBttn.Text = "Vest";
            this.VestBttn.UseVisualStyleBackColor = false;
            this.VestBttn.Click += new System.EventHandler(this.VestBttn_Click);
            // 
            // MiscellaneousBttn
            // 
            this.MiscellaneousBttn.BackColor = System.Drawing.Color.Maroon;
            this.MiscellaneousBttn.Font = new System.Drawing.Font("Trajan Pro", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MiscellaneousBttn.ForeColor = System.Drawing.Color.White;
            this.MiscellaneousBttn.Location = new System.Drawing.Point(44, 455);
            this.MiscellaneousBttn.Name = "MiscellaneousBttn";
            this.MiscellaneousBttn.Size = new System.Drawing.Size(317, 193);
            this.MiscellaneousBttn.TabIndex = 4;
            this.MiscellaneousBttn.Text = "Miscellaneous";
            this.MiscellaneousBttn.UseVisualStyleBackColor = false;
            this.MiscellaneousBttn.Click += new System.EventHandler(this.MiscellaneousBttn_Click);
            // 
            // AddOtherAlterationButton
            // 
            this.AddOtherAlterationButton.BackColor = System.Drawing.Color.Maroon;
            this.AddOtherAlterationButton.Font = new System.Drawing.Font("Trajan Pro", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddOtherAlterationButton.ForeColor = System.Drawing.Color.White;
            this.AddOtherAlterationButton.Location = new System.Drawing.Point(391, 455);
            this.AddOtherAlterationButton.Name = "AddOtherAlterationButton";
            this.AddOtherAlterationButton.Size = new System.Drawing.Size(317, 193);
            this.AddOtherAlterationButton.TabIndex = 5;
            this.AddOtherAlterationButton.Text = "Add Other";
            this.AddOtherAlterationButton.UseVisualStyleBackColor = false;
            this.AddOtherAlterationButton.Click += new System.EventHandler(this.AddOtherAlterationButton_Click);
            // 
            // AddAlterationBaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 688);
            this.Controls.Add(this.AddOtherAlterationButton);
            this.Controls.Add(this.MiscellaneousBttn);
            this.Controls.Add(this.VestBttn);
            this.Controls.Add(this.PantsButton);
            this.Controls.Add(this.ShirtButton);
            this.Controls.Add(this.JacketButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AddAlterationBaseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add an Alteration";
            this.Load += new System.EventHandler(this.AddAlterationBaseForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private CustomControls.HKTStandardButton JacketButton;
        private CustomControls.HKTStandardButton ShirtButton;
        private CustomControls.HKTStandardButton PantsButton;
        private CustomControls.HKTStandardButton VestBttn;
        private CustomControls.HKTStandardButton MiscellaneousBttn;
        private CustomControls.HKTStandardButton AddOtherAlterationButton;
    }
}