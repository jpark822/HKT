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
    public partial class ChooseMeasurementModal : Form
    {
        private CustomerResource customer;

        public ChooseMeasurementModal(CustomerResource customer)
        {
            this.customer = customer;
            InitializeComponent();
        }

        private void BodyMeasurementButton_Click(object sender, EventArgs e)
        {
            //make web request
            CustomerMeasurementsForm bodyForm = new CustomerMeasurementsForm(customer);
        }

        private void FinishMeasurementButton_Click(object sender, EventArgs e)
        {
            CustomerFinishMeasurementsForm finishForm = new CustomerFinishMeasurementsForm(customer);
        }
    }
}
