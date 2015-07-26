namespace HKTReceiptGenerator.Customer
{
    partial class ChooseMeasurementModal
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
            this.BodyMeasurementButton = new CustomControls.HKTStandardButton();
            this.FinishMeasurementButton = new CustomControls.HKTStandardButton();
            this.SuspendLayout();
            // 
            // BodyMeasurementButton
            // 
            this.BodyMeasurementButton.BackColor = System.Drawing.Color.Maroon;
            this.BodyMeasurementButton.Font = new System.Drawing.Font("Trajan Pro", 14F);
            this.BodyMeasurementButton.ForeColor = System.Drawing.Color.White;
            this.BodyMeasurementButton.Location = new System.Drawing.Point(40, 62);
            this.BodyMeasurementButton.Name = "BodyMeasurementButton";
            this.BodyMeasurementButton.Size = new System.Drawing.Size(300, 152);
            this.BodyMeasurementButton.TabIndex = 0;
            this.BodyMeasurementButton.Text = "Body Measurements";
            this.BodyMeasurementButton.UseVisualStyleBackColor = false;
            this.BodyMeasurementButton.Click += new System.EventHandler(this.BodyMeasurementButton_Click);
            // 
            // FinishMeasurementButton
            // 
            this.FinishMeasurementButton.BackColor = System.Drawing.Color.Maroon;
            this.FinishMeasurementButton.Font = new System.Drawing.Font("Trajan Pro", 14F);
            this.FinishMeasurementButton.ForeColor = System.Drawing.Color.White;
            this.FinishMeasurementButton.Location = new System.Drawing.Point(403, 62);
            this.FinishMeasurementButton.Name = "FinishMeasurementButton";
            this.FinishMeasurementButton.Size = new System.Drawing.Size(300, 153);
            this.FinishMeasurementButton.TabIndex = 1;
            this.FinishMeasurementButton.Text = "Finish Measurements";
            this.FinishMeasurementButton.UseVisualStyleBackColor = false;
            this.FinishMeasurementButton.Click += new System.EventHandler(this.FinishMeasurementButton_Click);
            // 
            // ChooseMeasurementModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(736, 274);
            this.Controls.Add(this.FinishMeasurementButton);
            this.Controls.Add(this.BodyMeasurementButton);
            this.Name = "ChooseMeasurementModal";
            this.Text = "Choose Measurement Type";
            this.ResumeLayout(false);

        }

        #endregion

        private CustomControls.HKTStandardButton BodyMeasurementButton;
        private CustomControls.HKTStandardButton FinishMeasurementButton;
    }
}