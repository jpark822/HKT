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
    public partial class CustomerSearch : Form
    {
        private List<CustomerResource> searchResults;
        public CustomerSearch()
        {
            InitializeComponent();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm() == false)
            {
                MessageBox.Show("Please enter at least 1 search criteria.");
                return;
            }

            ResultGrid.Rows.Clear();

            Dictionary<CustomerRepository.CustomerProperty, object> searchArguments = new Dictionary<CustomerRepository.CustomerProperty, object>();

            if (FirstNameTextBox.Text != "")
            {
                searchArguments.Add(CustomerRepository.CustomerProperty.FirstName, FirstNameTextBox.Text);
            }
            if (MiddleNameTextBox.Text != "")
            {
                searchArguments.Add(CustomerRepository.CustomerProperty.MiddleName, MiddleNameTextBox.Text);
            }
            if (LastNameTextBox.Text != "")
            {
                searchArguments.Add(CustomerRepository.CustomerProperty.LastName, LastNameTextBox.Text);
            }
            if (AddressTextBox.Text != "")
            {
                searchArguments.Add(CustomerRepository.CustomerProperty.Address, AddressTextBox.Text);
            }
            if (CityTextBox.Text != "")
            {
                searchArguments.Add(CustomerRepository.CustomerProperty.City, CityTextBox.Text);
            }
            if (StateTextBox.Text != "")
            {
                searchArguments.Add(CustomerRepository.CustomerProperty.State, StateTextBox.Text);
            }
            if (ZipTextBox.Text != "")
            {
                searchArguments.Add(CustomerRepository.CustomerProperty.Zip, ZipTextBox.Text);
            }
            if (TelephoneTextBox.Text != "")
            {
                searchArguments.Add(CustomerRepository.CustomerProperty.Telephone, TelephoneTextBox.Text);
            }
            if (EmailTextBox.Text != "")
            {
                searchArguments.Add(CustomerRepository.CustomerProperty.Email, EmailTextBox.Text);
            }
            

            try
            {
                CustomerRepository repo = new CustomerRepository();
                searchResults = repo.GetCustomersByArguments(searchArguments);

                if (searchResults.Count == 0)
                {
                    MessageBox.Show("I couldn't find any matching csutomers. Please check the search criteria and try again.");
                }
                else
                {
                    for (int i = 0; i < searchResults.Count; i++)
                    {
                        ResultGrid.Rows.Add(searchResults[i].FirstName, searchResults[i].LastName, searchResults[i].Email, searchResults[i].Telephone);
                    }
                }
                enableSelectCustomerButton();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error. Please contact Jay with this message: " + ex.Message);
            }
            
        }

        private void enableSelectCustomerButton()
        {
            if (searchResults == null || searchResults.Count == 0)
            {
                SelectCustomerButton.Enabled = false;
            }
            else
            {
                SelectCustomerButton.Enabled = true;
            }
        }

        private Boolean ValidateForm()
        {
            if (FirstNameTextBox.Text == "" &&
                MiddleNameTextBox.Text == "" &&
                LastNameTextBox.Text == "" &&
                AddressTextBox.Text == "" &&
                CityTextBox.Text == "" &&
                StateTextBox.Text == "" &&
                ZipTextBox.Text == "" &&
                TelephoneTextBox.Text == "" &&
                EmailTextBox.Text == "")
            {
                return false;
            }

            return true;
        }

        private void SelectCustomerButton_Click(object sender, EventArgs e)
        {
            int selectedIndex = ResultGrid.CurrentCell.RowIndex;

            CustomerResource customer = searchResults[selectedIndex];

            Customer.CustomerProfile profile = new Customer.CustomerProfile(customer);
            profile.Show();

            //TODO get Neil's feedback on what behavior he prefers
            //EnableButtonsBasedOnGrid();
            this.Close();
        }

        private void NewCustomerButton_Click(object sender, EventArgs e)
        {
            AddCustomerForm addCustomer = new AddCustomerForm();
            addCustomer.Show();
            this.Close();
        }
    }
}
