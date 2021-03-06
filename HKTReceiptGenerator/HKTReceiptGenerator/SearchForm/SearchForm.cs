﻿using System;
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
using Microsoft.Office.Interop.Excel;

namespace HKTReceiptGenerator
{
    public partial class SearchForm : Form
    {
        //private List<String> firstNameSuggestions = new List<String>();
        //private List<String> lastNameSuggestions = new List<String>();

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
                if (StatusComboBox.Text == "Active")
                {
                    searchArguments.Add(TicketRepository.TicketProperty.Status, "a");
                }
                else if (StatusComboBox.Text == "Done")
                {
                    searchArguments.Add(TicketRepository.TicketProperty.Status, "d");
                }
                else if (StatusComboBox.Text == "Cancelled")
                {
                    searchArguments.Add(TicketRepository.TicketProperty.Status, "c");
                }
                else if (StatusComboBox.Text == "In Progress")
                {
                    searchArguments.Add(TicketRepository.TicketProperty.Status, "i");
                }
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
                        String status = "";
                        if (searchResults[i].Status == "a")
                        {
                            status = "Active";
                        }
                        else if (searchResults[i].Status == "d")
                        {
                            status = "Done";
                        }
                        else if (searchResults[i].Status == "c")
                        {
                            status = "Cancelled";
                        }
                        else if (searchResults[i].Status == "i")
                        {
                            status = "In Progress";
                        }
                        ResultGrid.Rows.Add(searchResults[i].TicketId, searchResults[i].FirstName, searchResults[i].LastName,searchResults[i].DateIn, searchResults[i].DateReady, status, searchResults[i].TailorName, String.Format("{0:C}", searchResults[i].TotalPrice), String.Format("{0:C}", searchResults[i].Deposit), String.Format("{0:C}",searchResults[i].TotalPrice - searchResults[i].Deposit));
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
                OrderIdTextBox.Text == "" &&
                TailorComboBox.Text == "")
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
            //this.Close();
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

            //GetFirstNamesForAutocomplete();
            //GetLastNamesForAutocomplete();
        }

        //TODO move querying into ticket REPO
        //private void GetFirstNamesForAutocomplete()
        //{
        //    FirstNameTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        //    FirstNameTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;

        //    List<String> names = new List<String>();
        //    try
        //    {
        //        String sql = "select distinct first_name from tickets";
        //        SQLiteDatabase db = new SQLiteDatabase();
        //        System.Data.DataTable searchResultTable = db.GetDataTable(sql);
        //        foreach (DataRow row in searchResultTable.Rows)
        //        {
        //            names.Add(row["first_name"].ToString());
        //        }
                
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("There was an error. Please contact Jay with this message: " + ex.Message);
        //    }

        //    firstNameSuggestions = names;

        //    //taken from change in text box event
        //    AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
        //    collection.AddRange(firstNameSuggestions.ToArray());
        //    FirstNameTextBox.AutoCompleteCustomSource = collection;
        //}

        //TODO move querying into ticket REPO
        //private void GetLastNamesForAutocomplete()
        //{
        //    LastNameTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        //    LastNameTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;

        //    List<String> names = new List<String>();
        //    try
        //    {
        //        String sql = "select distinct last_name from tickets";
        //        SQLiteDatabase db = new SQLiteDatabase();
        //        System.Data.DataTable searchResultTable = db.GetDataTable(sql);

        //        foreach (DataRow row in searchResultTable.Rows)
        //        {
        //            names.Add(row["last_name"].ToString());
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("There was an error. Please contact Jay with this message: " + ex.Message);
        //    }

        //    lastNameSuggestions = names;

        //    //taken from lastname text box change event
        //    AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
        //    collection.AddRange(lastNameSuggestions.ToArray());
        //    LastNameTextBox.AutoCompleteCustomSource = collection;
        //}

        private void EnableButtonsBasedOnGrid()
        {
            if (ResultGrid.RowCount == 0)
            {
                OpenTicketButton.Enabled = false;
                DeleteTicketButton.Enabled = false;
                MarkAsDonePaidPickedUpBttn.Enabled = false;
            }
            else
            {
                OpenTicketButton.Enabled = true;
                DeleteTicketButton.Enabled = true;
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
                row.Cells["StatusCol"].Value = "Done";
                row.Cells["DepositCol"].Value = row.Cells["TotalPriceCol"].Value;
                row.Cells["BalanceCol"].Value = String.Format("{0:C}", 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error. Please contact Jay with this message: " + ex.Message);
            }
            EnableButtonsBasedOnGrid();
        }

        private void ExportToExcelButton_Click(object sender, EventArgs e)
        {
            if (ResultGrid.Rows.Count == 0)
            {
                return;
            }
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            excelApp.Visible = true;

            _Workbook workbook = (_Workbook)(excelApp.Workbooks.Add(Type.Missing));
            _Worksheet worksheet = (_Worksheet)workbook.ActiveSheet;

            //generate header columns
            worksheet.Cells[1, "A"] = "Ticket ID";
            worksheet.Cells[1, "B"] = "First Name";
            worksheet.Cells[1, "C"] = "Last Name";
            worksheet.Cells[1, "D"] = "Date In";
            worksheet.Cells[1, "E"] = "Date Ready";
            worksheet.Cells[1, "F"] = "Status";
            worksheet.Cells[1, "G"] = "Tailor Name";
            worksheet.Cells[1, "H"] = "Total Price";
            worksheet.Cells[1, "I"] = "Deposit";
            worksheet.Cells[1, "J"] = "Balance";

            //row 1 is headers and excel starts on row 1
            for (int i = 1; i < ResultGrid.Rows.Count; i++)
            {
                int row = i + 1;
                worksheet.Cells[row, "A"] = Convert.ToString(ResultGrid.Rows[i].Cells["TicketIdCol"].Value);
                worksheet.Cells[row, "B"] = Convert.ToString(ResultGrid.Rows[i].Cells["FirstNameCol"].Value);
                worksheet.Cells[row, "C"] = Convert.ToString(ResultGrid.Rows[i].Cells["LastNameCol"].Value);
                worksheet.Cells[row, "D"] = Convert.ToString(ResultGrid.Rows[i].Cells["DateInCol"].Value);
                worksheet.Cells[row, "E"] = Convert.ToString(ResultGrid.Rows[i].Cells["DateReadyCol"].Value);
                worksheet.Cells[row, "F"] = Convert.ToString(ResultGrid.Rows[i].Cells["StatusCol"].Value);
                worksheet.Cells[row, "G"] = Convert.ToString(ResultGrid.Rows[i].Cells["TailorCol"].Value);
                worksheet.Cells[row, "H"] = Convert.ToString(ResultGrid.Rows[i].Cells["TotalPriceCol"].Value);
                worksheet.Cells[row, "I"] = Convert.ToString(ResultGrid.Rows[i].Cells["DepositCol"].Value);
                worksheet.Cells[row, "J"] = Convert.ToString(ResultGrid.Rows[i].Cells["BalanceCol"].Value);
            }

            worksheet.Columns["A:J"].AutoFit();
        }

        private void StatusComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
