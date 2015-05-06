using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DomainModel;
using DomainModel.Customer;

namespace HKTReceiptGenerator.Customer
{
    public partial class AddCustomerForm : Form
    {
        public AddCustomerForm()
        {
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddCustomerButton_Click(object sender, EventArgs e)
        {
            if (!validateForm())
            {
                return;
            }
            CustomerResource customer = new CustomerResource();
            customer.Title = TitleComboBox.Text ?? "";
            customer.FirstName = FirstNameTextBox.Text ?? "";
            customer.MiddleName = MiddleNameTextBox.Text ?? "";
            customer.LastName = LastNameTextBox.Text ?? "";
            customer.Address = AddressTextBox.Text ?? "";
            customer.Address2 = Address2TextBox.Text ?? "";
            customer.City = CityTextBox.Text ?? "";
            customer.State = StateTextBox.Text ?? "";
            customer.Zip = ZipTextBox.Text;
            customer.Telephone = PhoneTextBox.Text ?? "";
            customer.Email = EmailTextBox.Text ?? "";

            CustomerRepository repo = new CustomerRepository();
            try
            {
                int custId = repo.InsertCustomer(customer);
                customer.CustomerId = custId;
                CustomerProfile profile = new CustomerProfile(customer);
                profile.Show();
                this.Close();
            }
            catch
            {
                MessageBox.Show("There was an error saving the customer. Please check the fields and try again");
            }
        }

        private bool validateForm()
        {
            if (FirstNameTextBox.Text == "")
            {
                MessageBox.Show("You didn't specify a first name! Please enter one and try again");
                return false;
            }
            else if (LastNameTextBox.Text == "")
            {
                MessageBox.Show("You didn't specify a last name! Please enter one and try again");
                return false;
            }
            return true;
        }


    }
}
