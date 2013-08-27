using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DomainModel.TicketAlterations;
using DomainModel.Ticket;

namespace HKTReceiptGenerator
{
    public partial class SearchForm : Form
    {
        private List<String> firstNameSuggestions = new List<String>();
        private List<String> lastNameSuggestions = new List<String>();

        public SearchForm()
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

            Dictionary<TicketRepository.TicketProperty, object> searchArguments = new Dictionary<TicketRepository.TicketProperty, object>();
            if (TicketIdTextBox.Text != "")
            {
                searchArguments.Add(TicketRepository.TicketProperty.TicketId, TicketIdTextBox.Text);
            }
            if (FirstNameTextBox.Text != "")
            {
                searchArguments.Add(TicketRepository.TicketProperty.FirstName, FirstNameTextBox.Text);
            }
            if (MiddleNameTextBox.Text != "")
            {
                searchArguments.Add(TicketRepository.TicketProperty.MiddleName, MiddleNameTextBox.Text);
            }
            if (LastNameTextBox.Text != "")
            {
                searchArguments.Add(TicketRepository.TicketProperty.LastName, LastNameTextBox.Text);
            }
            if (AddressTextBox.Text != "")
            {
                searchArguments.Add(TicketRepository.TicketProperty.Address, AddressTextBox.Text);
            }
            if (CityTextBox.Text != "")
            {
                searchArguments.Add(TicketRepository.TicketProperty.City, CityTextBox.Text);
            }
            if (StateTextBox.Text != "")
            {
                searchArguments.Add(TicketRepository.TicketProperty.State, StateTextBox.Text);
            }
            if (ZipTextBox.Text != "")
            {
                searchArguments.Add(TicketRepository.TicketProperty.Zip, ZipTextBox.Text);
            }
            if (TelephoneTextBox.Text != "")
            {
                searchArguments.Add(TicketRepository.TicketProperty.Telephone, TelephoneTextBox.Text);
            }
            if (EmailTextBox.Text != "")
            {
                searchArguments.Add(TicketRepository.TicketProperty.Email, EmailTextBox.Text);
            }
            if (PickedUpComboBox.Text != "")
            {
                searchArguments.Add(TicketRepository.TicketProperty.PickedUp, PickedUpComboBox.Text);
            }
            if (StatusComboBox.Text != "")
            {
               searchArguments.Add(TicketRepository.TicketProperty.Status, StatusComboBox.Text);
            }
            if (TailorComboBox.Text != "")
            {
                searchArguments.Add(TicketRepository.TicketProperty.TailorName, TailorComboBox.Text);
            }
            if (OrderIdTextBox.Text != "")
            {
                searchArguments.Add(TicketRepository.TicketProperty.OrderId, OrderIdTextBox.Text);
            }

            try
            {
                TicketRepository ticketRepo = new TicketRepository();
                List<TicketResource> searchResults = ticketRepo.GetTicketsByArguments(searchArguments);

                if (searchResults.Count == 0)
                {
                    MessageBox.Show("I couldn't find any matching tickets. Please check the search criteria and try again.");
                }
                else
                {
                    for(int i=0; i<searchResults.Count; i++)
                    {
                        ResultGrid.Rows.Add(searchResults[i].TicketId, searchResults[i].FirstName, searchResults[i].LastName,searchResults[i].DateIn.ToShortDateString(), searchResults[i].DateReady.ToShortDateString(), searchResults[i].Status, searchResults[i].TailorName, String.Format("{0:C}", searchResults[i].TotalPrice), String.Format("{0:C}", searchResults[i].Deposit), String.Format("{0:C}",searchResults[i].TotalPrice - searchResults[i].Deposit));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error. Please contact Jay with this message: " + ex.Message);
            }
            EnableButtonsBasedOnGrid();
        }

        private Boolean ValidateForm()
        {
            if (TicketIdTextBox.Text == "" &&
                FirstNameTextBox.Text == "" &&
                MiddleNameTextBox.Text == "" &&
                LastNameTextBox.Text == "" &&
                AddressTextBox.Text == "" &&
                CityTextBox.Text == "" &&
                StateTextBox.Text == "" &&
                ZipTextBox.Text == "" &&
                TelephoneTextBox.Text == "" &&
                EmailTextBox.Text == "" &&
                PickedUpComboBox.Text == "" &&
                StatusComboBox.Text == "" &&
                OrderIdTextBox.Text == "")
            {
                return false;
            }

            return true;
        }

        private void OpenTicketButton_Click(object sender, EventArgs e)
        {
            int selectedIndex = ResultGrid.CurrentCell.RowIndex;

            int ticketId = Convert.ToInt32(ResultGrid.Rows[selectedIndex].Cells["TicketIdCol"].Value);
            try
            {
                TicketRepository ticketRepo = new TicketRepository();
                TicketResource ticketRes = ticketRepo.GetTicketByTicketID(ticketId);

                TicketAlterationRepository alterationRepo = new TicketAlterationRepository();
                TicketAlterationResource alterationRes = alterationRepo.GetAlterationsByTicketId(ticketId);

                AlterationForm alterationForm = new AlterationForm(ticketRes, alterationRes);
                alterationForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error. Please contact Jay with this message: " + ex.Message);
            }

            //TODO get Neil's feedback on what behavior he prefers
            //EnableButtonsBasedOnGrid();
            this.Close();
         }

        private void DeleteTicketButton_Click(object sender, EventArgs e)
        {
            int selectedIndex = ResultGrid.CurrentCell.RowIndex;
            int ticketId = Convert.ToInt32(ResultGrid.Rows[selectedIndex].Cells["TicketIdCol"].Value);

            if (MessageBox.Show("This will delete ticket #" + ticketId + ". Are you sure?", "Delete Ticket", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    TicketRepository ticketRepo = new TicketRepository();
                    ticketRepo.DeleteTicketByTicketID(ticketId);

                    TicketAlterationRepository alterationRepo = new TicketAlterationRepository();
                    alterationRepo.DeleteAlterationsByTicketID(ticketId);
                    ResultGrid.Rows.RemoveAt(selectedIndex);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was an error. Please contact Jay with this message: " + ex.Message);
                }
                EnableButtonsBasedOnGrid();
            }
        }

        private void SearchForm_Load(object sender, EventArgs e)
        {
            StatusComboBox.SelectedIndex = 1;
            EnableButtonsBasedOnGrid();

            GetFirstNamesForAutocomplete();
            GetLastNamesForAutocomplete();
        }

        //TODO move querying into ticket REPO
        private void GetFirstNamesForAutocomplete()
        {
            FirstNameTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            FirstNameTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;

            List<String> names = new List<String>();
            try
            {
                String sql = "select distinct first_name from tickets";
                SQLiteDatabase db = new SQLiteDatabase();
                DataTable searchResultTable = db.GetDataTable(sql);
                foreach (DataRow row in searchResultTable.Rows)
                {
                    names.Add(row["first_name"].ToString());
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error. Please contact Jay with this message: " + ex.Message);
            }

            firstNameSuggestions = names;

            //taken from change in text box event
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            collection.AddRange(firstNameSuggestions.ToArray());
            FirstNameTextBox.AutoCompleteCustomSource = collection;
        }

        //TODO move querying into ticket REPO
        private void GetLastNamesForAutocomplete()
        {
            LastNameTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            LastNameTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;

            List<String> names = new List<String>();
            try
            {
                String sql = "select distinct last_name from tickets";
                SQLiteDatabase db = new SQLiteDatabase();
                DataTable searchResultTable = db.GetDataTable(sql);

                foreach (DataRow row in searchResultTable.Rows)
                {
                    names.Add(row["last_name"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error. Please contact Jay with this message: " + ex.Message);
            }

            lastNameSuggestions = names;

            //taken from lastname text box change event
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            collection.AddRange(lastNameSuggestions.ToArray());
            LastNameTextBox.AutoCompleteCustomSource = collection;
        }

        private void EnableButtonsBasedOnGrid()
        {
            if (ResultGrid.RowCount == 0)
            {
                OpenTicketButton.Enabled = false;
                DeleteTicketButton.Enabled = false;
                CreateTicketWithUserBttn.Enabled = false;
                MarkAsDonePaidPickedUpBttn.Enabled = false;
            }
            else
            {
                OpenTicketButton.Enabled = true;
                DeleteTicketButton.Enabled = true;
                CreateTicketWithUserBttn.Enabled = true;
                MarkAsDonePaidPickedUpBttn.Enabled = true;
            }
        }

        private void CreateTicketWithUserBttn_Click(object sender, EventArgs e)
        {
            int selectedIndex = ResultGrid.CurrentCell.RowIndex;

            int ticketId = Convert.ToInt32(ResultGrid.Rows[selectedIndex].Cells["TicketIdCol"].Value);
            try
            {
                TicketRepository ticketRepo = new TicketRepository();
                TicketResource ticketRes = ticketRepo.GetCustomerInfoBasedOnTicketId(ticketId);

                AlterationForm alterationForm = new AlterationForm(ticketRes);
                alterationForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error. Please contact Jay with this message: " + ex.Message);
            }
            //TODO ask neil which behavior he prefers
            //EnableButtonsBasedOnGrid();
            this.Close();
        }

        private void MarkAsDonePaidPickedUpBttn_Click(object sender, EventArgs e)
        {
            int index = ResultGrid.CurrentCell.RowIndex;
            int ticketId = Convert.ToInt32(ResultGrid.Rows[index].Cells["TicketIdCol"].Value);

            try
            {
                TicketRepository ticketRepo = new TicketRepository();
                ticketRepo.MarkTicketAsDonePaidAndPickedUp(ticketId);

                DataGridViewRow row = ResultGrid.Rows[index];
                row.Cells["StatusCol"].Value = "d";
                row.Cells["DepositCol"].Value = row.Cells["TotalPriceCol"].Value;
                row.Cells["BalanceCol"].Value = String.Format("{0:C}", 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error. Please contact Jay with this message: " + ex.Message);
            }
            EnableButtonsBasedOnGrid();
        }
    }
}
