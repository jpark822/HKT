using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DomainModel.Customer;

namespace HKTReceiptGenerator.Customer
{
    public partial class CustomerFinishMeasurementsForm : Form
    {
        private CustomerResource customer;

        public CustomerFinishMeasurementsForm(CustomerResource customer)
        {
            this.customer = customer;
            InitializeComponent();
        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            Dictionary<String, String> measurements = new Dictionary<String, String>();

            measurements.Add("shirt_chest", ShirtChestTextBox.Text);
            measurements.Add("shirt_waist", ShirtWaistTextBox.Text);
            measurements.Add("shirt_hips", ShirtHipsTextBox.Text);
            measurements.Add("shirt_shoulders", ShirtShouldersTextBox.Text);
            measurements.Add("shirt_sleeve_length", ShirtSleeveLengthTextBox.Text);
            measurements.Add("shirt_shirt_length", ShirtLengthOfShirtTextBox.Text);
            measurements.Add("shirt_cuff", ShirtCuffTextBox.Text);
            measurements.Add("shirt_neck", ShirtNeckTextBox.Text);
            measurements.Add("shirt_sleeve_6_below", ShirtWidth6TextBox.Text);
            measurements.Add("shirt_sleeve_12_below", ShirtWidth12TextBox.Text);

            measurements.Add("pants_waist", PantsWaistTextBox.Text);
            measurements.Add("pants_seat", PantsSeatTextBox.Text);
            measurements.Add("pants_crotch", PantsCrotchTextBox.Text);
            measurements.Add("pants_1623_below", Pants1623TextBox.Text);
            measurements.Add("pants_bottom_cuff", PantsBottomCuffTextBox.Text);
            measurements.Add("pants_inseam", PantsInseamTextBox.Text);
            measurements.Add("pants_outseam", PantsOutseamTextBox.Text);

            measurements.Add("jacket_chest", JacketChestTextBox.Text);
            measurements.Add("jacket_waist", JacketWaistTextBox.Text);
            measurements.Add("jacket_hips", JacketHipsTextBox.Text);
            measurements.Add("jacket_shoulders", JacketShouldersTextBox.Text);
            measurements.Add("jacket_sleeve_length", JacketSleeveLengthTextBox.Text);
            measurements.Add("jacket_jacket_length", JacketLengthOfJacketTextBox.Text);
            measurements.Add("jacket_half_shoulder", JacketHalfShoulderTextBox.Text);
            measurements.Add("jacket_sleeve_width", JacketSleeveWidthTextBox.Text);

            measurements.Add("vest_front_length", VestFrontTextBox.Text);
            measurements.Add("vest_back_length", VestBackTextBox.Text);
        }
    }
}
