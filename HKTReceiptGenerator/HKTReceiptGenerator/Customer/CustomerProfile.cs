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
    public partial class CustomerProfile : Form
    {
        private AlterationForm.CustomerProfileDidFinishEditing alterationFormCallback;
        private CustomerResource customer;

        public CustomerProfile(CustomerResource customer)
        {
            InitializeComponent();
            this.customer = customer;
            TitleComboBox.Text = customer.Title;
            FirstNameTextBox.Text = customer.FirstName;
            MiddleNameTextBox.Text = customer.MiddleName;
            LastNameTextBox.Text = customer.LastName;
            AddressTextBox.Text = customer.Address;
            Address2TextBox.Text = customer.Address2;
            CityTextBox.Text = customer.City;
            StateTextBox.Text = customer.State;
            ZipTextBox.Text = customer.Zip;
            PhoneTextBox.Text = customer.Telephone;
            EmailTextBox.Text = customer.Email;
        }

        public CustomerProfile(CustomerResource customer, AlterationForm.CustomerProfileDidFinishEditing alterationCallback) : this(customer)
        {
            alterationFormCallback = alterationCallback;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            CustomerResource customer = new CustomerResource();
            customer.CustomerId = this.customer.CustomerId;
            customer.Title = TitleComboBox.Text;
            customer.FirstName = FirstNameTextBox.Text;
            customer.MiddleName = MiddleNameTextBox.Text;
            customer.LastName = LastNameTextBox.Text;
            customer.Address = AddressTextBox.Text;
            customer.Address2 = Address2TextBox.Text;
            customer.City = CityTextBox.Text;
            customer.State = StateTextBox.Text;
            customer.Zip = ZipTextBox.Text;
            customer.Telephone = PhoneTextBox.Text;
            customer.Email = EmailTextBox.Text;

            CustomerRepository repo = new CustomerRepository();
            try
            {
                repo.UpdateCustomer(customer);
                if (alterationFormCallback != null)
                {
                    alterationFormCallback(customer);
                }
                this.Close();
            }
            catch
            {
                MessageBox.Show("There was an error saving the customer. Please check the fields and try again");
            }
        }

        private void CreateTicketButton_Click(object sender, EventArgs e)
        {
            AlterationForm form = new AlterationForm(customer);
            form.Show();
            this.Close();

        }

        private void MeasurementsButton_Click(object sender, EventArgs e)
        {
            CustomerMeasurementsForm measurements = new CustomerMeasurementsForm(customer);
            measurements.Show();
        }
    }
}
