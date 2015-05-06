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
    public partial class CustomerMeasurementsForm : Form
    {
        private CustomerResource customer;
        public CustomerMeasurementsForm(CustomerResource customer)
        {
            InitializeComponent();
            this.customer = customer;

            Dictionary<String, String> measurements = new Dictionary<String, String>(); //web request for measurements
            string result;

            measurements.TryGetValue("body_chest", out result);
            ChestTextBox.Text = result ?? "";
            measurements.TryGetValue("body_waist", out result);
            WaistTextBox.Text = result ?? "";
            measurements.TryGetValue("body_hips", out result);
            HipsTextBox.Text = result ?? "";
            measurements.TryGetValue("body_shoulders", out result);
            ShouldersTextBox.Text = result ?? "";
            measurements.TryGetValue("body_seat", out result);
            SeatTextBox.Text = result ?? "";
            measurements.TryGetValue("body_crotch", out result);
            CrotchTextBox.Text = result ?? "";
            measurements.TryGetValue("body_actual_thigh", out result);
            ActualThighTextBox.Text = result ?? "";
            measurements.TryGetValue("body_outseam", out result);
            OutseamTextBox.Text = result ?? "";
            measurements.TryGetValue("body_inseam", out result);
            InseamTextBox.Text = result ?? "";
            measurements.TryGetValue("body_sleeve_length", out result);
            SleeveLengthTextBox.Text = result ?? "";
            measurements.TryGetValue("body_shirt_length", out result);
            LengthOfShirtTextBox.Text = result ?? "";
            measurements.TryGetValue("body_wrist", out result);
            WristTextBox.Text = result ?? "";
            measurements.TryGetValue("body_neck", out result);
            NeckSizeTextBox.Text = result ?? "";
            measurements.TryGetValue("body_jacket_length", out result);
            LengthOfJacketTextBox.Text = result ?? "";
            measurements.TryGetValue("body_bicep", out result);
            BicepTextBox.Text = result ?? "";
            measurements.TryGetValue("body_arm_hole", out result);
            ArmHoleTextBox.Text = result ?? "";
            measurements.TryGetValue("body_belly", out result);
            BellyTextBox.Text = result ?? "";

            measurements.TryGetValue("shirt_chest", out result);
            ShirtChestTextBox.Text = result ?? "";
            measurements.TryGetValue("shirt_waist", out result);
            ShirtWaistTextBox.Text = result ?? "";
            measurements.TryGetValue("shirt_hips", out result);
            ShirtHipsTextBox.Text = result ?? "";
            measurements.TryGetValue("shirt_shoulders", out result);
            ShirtShouldersTextBox.Text = result ?? "";
            measurements.TryGetValue("shirt_sleeve_length", out result);
            ShirtSleeveLengthTextBox.Text = result ?? "";
            measurements.TryGetValue("shirt_shirt_length", out result);
            ShirtLengthOfShirtTextBox.Text = result ?? "";
            measurements.TryGetValue("shirt_cuff", out result);
            ShirtCuffTextBox.Text = result ?? "";
            measurements.TryGetValue("shirt_neck", out result);
            ShirtNeckTextBox.Text = result ?? "";
            measurements.TryGetValue("shirt_sleeve_6_below", out result);
            ShirtWidth6TextBox.Text = result ?? "";
            measurements.TryGetValue("shirt_sleeve_12_below", out result);
            ShirtWidth12TextBox.Text = result ?? "";

            measurements.TryGetValue("pants_waist", out result);
            PantsWaistTextBox.Text = result ?? "";
            measurements.TryGetValue("pants_seat", out result);
            PantsSeatTextBox.Text = result ?? "";
            measurements.TryGetValue("pants_crotch", out result);
            PantsCrotchTextBox.Text = result ?? "";
            measurements.TryGetValue("pants_1623_below", out result);
            Pants1623TextBox.Text = result ?? "";
            measurements.TryGetValue("pants_bottom_cuff", out result);
            PantsBottomCuffTextBox.Text = result ?? "";
            measurements.TryGetValue("pants_inseam", out result);
            PantsInseamTextBox.Text = result ?? "";
            measurements.TryGetValue("pants_outseam", out result);
            PantsOutseamTextBox.Text = result ?? "";

            measurements.TryGetValue("jacket_chest", out result);
            JacketChestTextBox.Text = result ?? "";
            measurements.TryGetValue("jacket_waist", out result);
            JacketWaistTextBox.Text = result ?? "";
            measurements.TryGetValue("jacket_hips", out result);
            JacketHipsTextBox.Text = result ?? "";
            measurements.TryGetValue("jacket_shoulders", out result);
            JacketShouldersTextBox.Text = result ?? "";
            measurements.TryGetValue("jacket_sleeve_length", out result);
            JacketSleeveLengthTextBox.Text = result ?? "";
            measurements.TryGetValue("jacket_jacket_length", out result);
            JacketLengthOfJacketTextBox.Text = result ?? "";
            measurements.TryGetValue("jacket_half_shoulder", out result);
            JacketHalfShoulderTextBox.Text = result ?? "";
            measurements.TryGetValue("jacket_sleeve_width", out result);
            JacketSleeveWidthTextBox.Text = result ?? "";

            measurements.TryGetValue("vest_front_length", out result);
            VestFrontTextBox.Text = result ?? "";
            measurements.TryGetValue("vest_back_length", out result);
            VestBackTextBox.Text = result ?? "";
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveAndCloseButton_Click(object sender, EventArgs e)
        {
            Dictionary<String, String> measurements = new Dictionary<String, String>();
            measurements.Add("body_chest", ChestTextBox.Text);
            measurements.Add("body_waist", WaistTextBox.Text);
            measurements.Add("body_hips", HipsTextBox.Text);
            measurements.Add("body_shoulders", ShouldersTextBox.Text);
            measurements.Add("body_seat", SeatTextBox.Text);
            measurements.Add("body_crotch", CrotchTextBox.Text);
            measurements.Add("body_actual_thigh", ActualThighTextBox.Text);
            measurements.Add("body_outseam", OutseamTextBox.Text);
            measurements.Add("body_inseam", InseamTextBox.Text);
            measurements.Add("body_sleeve_length", SleeveLengthTextBox.Text);
            measurements.Add("body_shirt_length", LengthOfShirtTextBox.Text);
            measurements.Add("body_wrist", WristTextBox.Text);
            measurements.Add("body_neck", NeckSizeTextBox.Text);
            measurements.Add("body_jacket_length", LengthOfJacketTextBox.Text);
            measurements.Add("body_bicep", BicepTextBox.Text);
            measurements.Add("body_arm_hole", ArmHoleTextBox.Text);
            measurements.Add("body_belly", BellyTextBox.Text);

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

            //TODO make web request
        }
    }
}
