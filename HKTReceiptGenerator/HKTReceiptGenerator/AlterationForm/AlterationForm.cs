using System;
using System.Globalization;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.IO;
using System.Configuration;
using System.Net.Mail;
using System.Net;
using DomainModel;
using System.Drawing.Printing;
using HKTReceiptGenerator.AddAlterationModal;
using DomainModel.Ticket;
using DomainModel.TicketAlterations;
using DomainModel.Customer;
using HKTReceiptGenerator.Customer;

namespace HKTReceiptGenerator
{
    public partial class AlterationForm : Form
    {
        private bool isNewAlteration;
        private const double taxPercentage = 1.07;
        private int ticketID;
        private String previousStatus;
        private CustomerResource customer;
        private int customerId = 0;
        private IEnumerable<AlterationToatalForDay> alterationToatalForDays;
        private double maxAlterations; 

        public delegate void ClothingSelectedCallback(TypeOfClothing choice);
        public delegate void ArticleSelectedCallback(AlterationModalCallbackArguments args);
        public delegate void CustomerProfileDidFinishEditing(CustomerResource customer);

        private String stringToPrint;

        public enum TypeOfClothing
        {
            Jacket,
            Shirt,
            Pants,
            Vest,
            Miscellaneous,
            Other
        }

        public AlterationForm(CustomerResource customer)
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            maxAlterations = Convert.ToDouble(configuration.AppSettings.Settings["maxAlterations"].Value);
            TicketRepository ticketRepo = new TicketRepository();
            alterationToatalForDays = ticketRepo.GetAlterationToatalForDays();
            SetupForm();
            this.customer = customer;
            customerId = customer.CustomerId;
            isNewAlteration = true;
            TicketNumberLabel.Hide();
            DateInPicker.Value = DateTime.Today;
            var readyDate = GetNextValidDateNotOverMaxAlterations(DateTime.Today.AddDays(7));
            DateReadyPicker.Value = readyDate;
            previousStatus = "a";
            NewTicketWithCustomerBttn.Enabled = false;

            TitleComboBox.Text = customer.Title;
            FirstNameTextBox.Text = customer.FirstName;
            MiddleNameTextBox.Text = customer.MiddleName;
            LastNameTextBox.Text = customer.LastName;
            AddressTextBox.Text = customer.Address;
            CityTextBox.Text = customer.City;
            StateTextBox.Text = customer.State;
            ZipTextBox.Text = customer.Zip;
            PhoneTextBox.Text = customer.Telephone;
            EmailTextBox.Text = customer.Email; 

        }

        private DateTime GetNextValidDateNotOverMaxAlterations(DateTime date)
        {
            var test = alterationToatalForDays.Where(x => x.Date == date).FirstOrDefault();
            if (date.DayOfWeek == DayOfWeek.Sunday)
            {
                return GetNextValidDateNotOverMaxAlterations(date.AddDays(1));
            }

            if (test == null)
            {
                return date;
            }
            else if (test.TotalPrice > maxAlterations)
            {
                return GetNextValidDateNotOverMaxAlterations(date.AddDays(1));
            }

            return date;
        }

        private void DateReadyPickerValidate(object sender, EventArgs e)
        {
            var alterationToatalForDay = alterationToatalForDays.Where(x => x.Date == DateReadyPicker.Value).Select(x => x.TotalPrice).DefaultIfEmpty(0).First();
            if (alterationToatalForDay > maxAlterations)
            {
                var readyDate = GetNextValidDateNotOverMaxAlterations(DateReadyPicker.Value);
                DialogResult dr = MessageBox.Show("The total aletrations for " +
                DateReadyPicker.Value.ToLongDateString() + " exceeds the day maximum. Would you like the next avaiable date " +
                readyDate.ToLongDateString() + "?",
                "Confirm Date Change", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (dr == DialogResult.Yes)
                {
                    DateReadyPicker.Value = readyDate;
                }
            }
            else if (alterationToatalForDay > (maxAlterations * 0.75))
            {
                var readyDate = GetNextValidDateNotOverMaxAlterations(DateReadyPicker.Value);
                DialogResult dr = MessageBox.Show("The total aletrations for " +
                DateReadyPicker.Value.ToLongDateString() + " is aproching the day maximum",
                "Confirm Date Change", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public AlterationForm(TicketResource ticketResource)
        {
            SetupForm();
            if (ticketResource.TicketId == 0)
            {
                isNewAlteration = true;
                TicketNumberLabel.Hide();
                previousStatus = "a";
                NewTicketWithCustomerBttn.Enabled = false;
            }
            else
            {
                isNewAlteration = false;
                ticketID = ticketResource.TicketId;
                TicketNumberLabel.Text = ticketResource.TicketId.ToString();
                previousStatus = ticketResource.Status ?? "a";
            }

            customerId = ticketResource.CustomerID;

            TitleComboBox.Text = ticketResource.Title ?? "";
            FirstNameTextBox.Text = ticketResource.FirstName ?? "";
            MiddleNameTextBox.Text = ticketResource.MiddleName ?? "";
            LastNameTextBox.Text = ticketResource.LastName ?? "";
            AddressTextBox.Text = ticketResource.Address ?? "";
            CityTextBox.Text = ticketResource.City ?? "";
            StateTextBox.Text = ticketResource.State ?? "";
            ZipTextBox.Text = ticketResource.Zip ?? "";
            PhoneTextBox.Text = ticketResource.Telephone ?? "";
            EmailTextBox.Text = ticketResource.Email ?? "";
            CommentBox.Text = ticketResource.Comments ?? "";
            if (ticketResource.Status == "a")
            {
                StatusComboBox.Text = "Active";
            }
            else if (ticketResource.Status == "d")
            {
                StatusComboBox.Text = "Done";
            }
            else if (ticketResource.Status == "c")
            {
                StatusComboBox.Text = "Cancelled";
            }
            else if (ticketResource.Status == "i")
            {
                StatusComboBox.Text = "In Progress";
            }
            else
            {
                StatusComboBox.Text = "";
            }

            PickedUpComboBox.Text = ticketResource.PickedUp ?? "n/a";
            DateInPicker.Value = ticketResource.DateIn;
            DateReadyPicker.Value = ticketResource.DateReady;
            OrderIdTextBox.Text = ticketResource.OrderId ?? "";

            if (isNewAlteration)
            {
                //cant add this above because it will just get overwritten down here, and it looks messy it the if logic is added below
                DateReadyPicker.Value = DateTime.Today.AddDays(7);
            }
            DepositTextBox.Text = ticketResource.Deposit.ToString();
            TailorComboBox.Text = ticketResource.TailorName == "" ? "In House" : ticketResource.TailorName;
        }

        public AlterationForm(TicketResource ticketResource, TicketAlterationResource alterationResource) : this(ticketResource)
        {
            List<TicketAlterationResourceItem> gridItems = alterationResource.Alterations;
            for (int i = 0; i < gridItems.Count; i++)
            {
                String quantity = gridItems[i].Quantity == 0 ? "" : gridItems[i].Quantity.ToString();
                String description = gridItems[i].Description;
                String price = gridItems[i].Price == 0 ? "" : gridItems[i].Price.ToString();
                AlterationGrid.Rows.Add(quantity, description, price, gridItems[i].Taxable);
            }

            UpdateTotalDepositAndBalance();
        }

        private void SetupForm()
        {
            InitializeComponent();
            AlterationGrid.CellValueChanged += AlterationGridCellChanged;
            AlterationGrid.CellValidating += AlterationGrid_CellValidating;
            foreach (DataGridViewColumn column in AlterationGrid.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void AlterationGrid_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //if its not the quantity column, we dont care
            if (e.ColumnIndex != 0)
            {
                return;
            }
            //UpdateTotalDepositAndBalance();
            
            //Boolean isInEditMode = false;
            //int oldMasterQuantity;
            //int newMasterQuantity;
            //double rateOfChange;
            //for (int i = 0; i < AlterationGrid.Rows.Count; i++)
            //{
            //    String description = Convert.ToString(AlterationGrid["descriptionCol", i].Value);
            //    int quantity = Convert.ToString(AlterationGrid[e.ColumnIndex, e.RowIndex].Value) == "" ? 1 : Convert.ToInt32(AlterationGrid[e.ColumnIndex, e.RowIndex].Value);
            //    if (description.Length != 0 && description.Substring(0,1) != " ")
            //    {
            //        isInEditMode = true;
            //        oldMasterQuantity = Convert.ToString(AlterationGrid[e.ColumnIndex, e.RowIndex].Value) == "" ? 1 : Convert.ToInt32(AlterationGrid[e.ColumnIndex, e.RowIndex].Value);
            //        newMasterQuantity = Convert.ToString(e.FormattedValue == "" ? 1 : Convert.ToInt32(e.FormattedValue);
            //        rateOfChange = newMasterQuantity / oldMasterQuantity;
            //    }

            //    if (isInEditMode == true)
            //    {

            //    }
            //}

            var oldValue = AlterationGrid[e.ColumnIndex, e.RowIndex].Value;
            var newValue = e.FormattedValue;
        }


        void AlterationGridCellChanged(object sender, DataGridViewCellEventArgs e)
        {
            UpdateTotalDepositAndBalance();
        }

        //validates cells are in proper formats and updates num items, deposit, and balance, and removes empty rows
        private void UpdateTotalDepositAndBalance()
        {
            double total = 0;
            double subtotal = 0;
            double tax = 0;
            //remove empty rows
            for (int i = AlterationGrid.Rows.Count - 2; i >=0 ; i--)
            {
                if ((AlterationGrid["PriceCol",i].Value == null || Convert.ToString(AlterationGrid["PriceCol",i].Value).Trim() == "")
                    && (AlterationGrid["QuantityCol", i].Value == null || Convert.ToString(AlterationGrid["QuantityCol", i].Value).Trim() == "")
                    && (AlterationGrid["DescriptionCol", i].Value == null || Convert.ToString(AlterationGrid["DescriptionCol", i].Value).Trim() == ""))
                {
                    AlterationGrid.Rows.RemoveAt(i);
                }
            }
            //check if prices are valid values and add tax if taxable is clicked
            int numItems = 0;
            for (int i = 0; i < AlterationGrid.Rows.Count - 1; i++)
            {
                try
                {
                    double price = Convert.ToString(AlterationGrid["PriceCol", i].Value) == "" ? 0 : Convert.ToDouble(AlterationGrid["PriceCol", i].Value);
                    if (Convert.ToBoolean(AlterationGrid["TaxableCol", i].Value) == true)
                    {
                        total += price * taxPercentage;
                        subtotal += price;
                        tax += price * .07;
                    }
                    else
                    {
                        total += price;
                        subtotal += price;
                    }
                }
                catch
                {
                    MessageBox.Show("You must have a dollar amount for the price.");
                    AlterationGrid["PriceCol", i].Value = "";
                }
                //check if quantities are valid values
                try
                {
                    int quantity = Convert.ToString(AlterationGrid["QuantityCol", i].Value) == "" ? 0 : Convert.ToInt32(AlterationGrid["QuantityCol", i].Value);
                    numItems += quantity;
                }
                catch
                {
                    MessageBox.Show("You must have a number value for item quantity.");
                    AlterationGrid["QuantityCol", i].Value = "";
                }
            }

            double deposit = 0;
            try
            {
                if (DepositTextBox.Text.Trim() == "")
                {
                    deposit = 0;
                }
                else
                {
                    deposit = Convert.ToDouble(DepositTextBox.Text);
                }
            }
            catch
            {
                MessageBox.Show("You must enter a valid number for the deposit.");
                DepositTextBox.Text = "";
            }

            //update all labels
            double balance = total - deposit;
            subtotalLabel.Text = String.Format("{0:C}", subtotal);
            taxLabel.Text = String.Format("{0:C}", tax);
            TotalPriceLabel.Text = String.Format("{0:C}", total);
            BalanceLabel.Text = String.Format("{0:C}", balance);
            NumItemsLabel.Text = numItems.ToString();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (!validateForm())
            {
                return;
            }
            Boolean didUpdateOrInsertCorrectly = false;

            if (isNewAlteration)
            {
                didUpdateOrInsertCorrectly = InsertAlterationIntoDatabase();
            }
            else if (!isNewAlteration)
            {
                didUpdateOrInsertCorrectly = UpdateAlterationInDatabase();
            }

            if (didUpdateOrInsertCorrectly)
            {
                String text = ReceiptStringBulder.BuildStringFromArgs(CollectDataForReceiptPrinting(true), true, true);
                Emailer.SendEmailWithBodyAsync(text, EmailTextBox.Text);
            }
        }

        private void NewTicketWithCustomerBttn_Click(object sender, EventArgs e)
        {
            if (ticketID == 0)
            {
                MessageBox.Show("You need to save this ticket before you can create a new ticket with this customer!");
                return;
            }
            CustomerRepository repo = new CustomerRepository();
            CustomerResource resource = repo.getCustomerById(customerId);
            AlterationForm form = new AlterationForm(resource);
            form.Show();
        }



        private void SaveBttn_Click(object sender, EventArgs e)
        {
            if (!validateForm())
            {
                return;
            }

            if (isNewAlteration)
            {
                InsertAlterationIntoDatabase();
            }
            else if (!isNewAlteration)
            {
                UpdateAlterationInDatabase();
            }

            this.Close();
        }

        //@return true if successful save
        private Boolean UpdateAlterationInDatabase()
        {
            try
            {
                TicketResource ticketResource = CollectFormDataForTicketResource();
                TicketRepository ticketRepo = new TicketRepository();
                ticketRepo.UpdateTicket(ticketResource);

                TicketAlterationResource alterationResource = CollectAlterationGridDataForAlterationResource();
                TicketAlterationRepository alterationRepo = new TicketAlterationRepository();
                alterationRepo.DeleteAndReinsertAlterations(alterationResource, ticketID);

                MessageBox.Show("Your alteration was successfully Updated.");
                NewTicketWithCustomerBttn.Enabled = true;

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error saving to the database. Please contact Jay with this message: " + ex.Message);
                return false;
            }
        }

        
        //@return true if successful save
        private Boolean InsertAlterationIntoDatabase()
        {
            try
            {
                TicketResource ticketResource = CollectFormDataForTicketResource();
                TicketRepository ticketRepo = new TicketRepository();
                ticketID = ticketRepo.InsertNewTicket(ticketResource);

                TicketAlterationResource alterationResource = CollectAlterationGridDataForAlterationResource();
                TicketAlterationRepository alterationRepo = new TicketAlterationRepository();
                alterationRepo.InsertAlterations(alterationResource);

                TicketNumberLabel.Text = ticketID.ToString();
                TicketNumberLabel.Show();
                MessageBox.Show("Your alteration was successfully saved. The ticket ID is " + ticketID.ToString());
                isNewAlteration = false;
                NewTicketWithCustomerBttn.Enabled = true;

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error saving to the database. Please contact Jay with this message: " + ex.Message);
                return false;
            }
        }

        /*
        private Dictionary<String, object> CollectCustomerFormData()
        {
            Dictionary<String, object> customerData = new Dictionary<string, object>();
            customerData.Add("name_title", TitleComboBox.Text);
            customerData.Add("first_name", FirstNameTextBox.Text);
            customerData.Add("middle_name", MiddleNameTextBox.Text);
            customerData.Add("last_name", LastNameTextBox.Text);
            customerData.Add("address", AddressTextBox.Text);
            customerData.Add("city", CityTextBox.Text);
            customerData.Add("state", StateTextBox.Text);
            customerData.Add("zip", ZipTextBox.Text);
            customerData.Add("telephone", PhoneTextBox.Text);
            customerData.Add("email", EmailTextBox.Text);
            customerData.Add("date_in", string.Format("{0:yyyy-MM-dd HH:mm:ss}", DateInPicker.Value));
            customerData.Add("date_ready", string.Format("{0:yyyy-MM-dd HH:mm:ss}", DateReadyPicker.Value));
            customerData.Add("last_modified_timestamp", string.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Now));
            customerData.Add("status", StatusComboBox.Text);
            customerData.Add("comments", CommentBox.Text);
            customerData.Add("tailor_name", TailorComboBox.Text);
            customerData.Add("total_price", double.Parse(TotalPriceLabel.Text, NumberStyles.Currency));
            customerData.Add("picked_up", PickedUpComboBox.Text);
            customerData.Add("deposit", Convert.ToDouble(DepositTextBox.Text == "" ? 0 : Convert.ToDouble(DepositTextBox.Text)));
            return customerData;
        }
         */

        private TicketResource CollectFormDataForTicketResource()
        {
            String title = TitleComboBox.Text;
            String firstName = FirstNameTextBox.Text;
            String lastname = LastNameTextBox.Text;
            String middleName = MiddleNameTextBox.Text;
            String address = AddressTextBox.Text;
            String city = CityTextBox.Text;
            String state = StateTextBox.Text;
            String zip = ZipTextBox.Text;
            String telephone = PhoneTextBox.Text;
            String email = EmailTextBox.Text;
            DateTime dateReady = DateReadyPicker.Value;
            DateTime dateIn = DateInPicker.Value;
            String status = "";
            if (StatusComboBox.Text == "Active")
            {
                status = "a";
            }
            else if (StatusComboBox.Text == "Done")
            {
                status = "d";
            }
            else if (StatusComboBox.Text == "Cancelled")
            {
                status = "c";
            }
            else if (StatusComboBox.Text == "In Progress")
            {
                status = "i";
            }

            String comments = CommentBox.Text;
            String tailorName = TailorComboBox.Text;
            double totalPrice = double.Parse(TotalPriceLabel.Text, NumberStyles.Currency);
            String pickedUp = PickedUpComboBox.Text;
            double deposit = Convert.ToDouble(DepositTextBox.Text == "" ? 0 : Convert.ToDouble(DepositTextBox.Text));
            String orderId = OrderIdTextBox.Text;
            DateTime? completedDate = null;
            if (status == "d" && previousStatus != "d")
            {
                completedDate = DateTime.Now;
            }

            return TicketFactory.CreateTicket(ticketID, status, title, firstName, lastname, middleName, address, city, state, zip, telephone, email, comments, pickedUp, dateIn, dateReady, totalPrice, deposit, tailorName, orderId, completedDate, customerId);
        }

        private List<Dictionary<String, object>> CollectAlterationGridData()
        {
            List<Dictionary<String, object>> alterationGridItemDataList = new List<Dictionary<String, object>>();
            for (int i = 0; i < AlterationGrid.Rows.Count - 1; i++)
            {
                float price = (float)(Convert.ToString(AlterationGrid["PriceCol", i].Value) == "" ? 0 : Convert.ToDouble(AlterationGrid["PriceCol", i].Value));
                int quantity = Convert.ToString(AlterationGrid["quantityCol", i].Value) == "" ? 0 : Convert.ToInt32(AlterationGrid["quantityCol", i].Value);
                String description = Convert.ToString(AlterationGrid["descriptionCol", i].Value ?? "");
                int taxable = Convert.ToBoolean(AlterationGrid["taxableCol", i].Value) == true ? 1 : 0;

                Dictionary<String, object> alterationGridItemData = new Dictionary<string, object>();
                alterationGridItemData.Add("price", price);
                alterationGridItemData.Add("quantity", quantity);
                alterationGridItemData.Add("description", description);
                alterationGridItemData.Add("taxable", taxable);

                alterationGridItemDataList.Add(alterationGridItemData);
            }
            return alterationGridItemDataList;
        }

        private TicketAlterationResource CollectAlterationGridDataForAlterationResource()
        {
            List<TicketAlterationResourceItem> alterationList = new List<TicketAlterationResourceItem>();
            for (int i = 0; i < AlterationGrid.Rows.Count - 1; i++)
            {
                float price = (float)(Convert.ToString(AlterationGrid["PriceCol", i].Value) == "" ? 0 : Convert.ToDouble(AlterationGrid["PriceCol", i].Value));
                int quantity = Convert.ToString(AlterationGrid["quantityCol", i].Value) == "" ? 0 : Convert.ToInt32(AlterationGrid["quantityCol", i].Value);
                String description = Convert.ToString(AlterationGrid["descriptionCol", i].Value ?? "");
                int taxable = Convert.ToBoolean(AlterationGrid["taxableCol", i].Value) == true ? 1 : 0;

                TicketAlterationResourceItem singleAlteration = new TicketAlterationResourceItem
                {
                    TicketId = ticketID,
                    Price = price,
                    Quantity = quantity,
                    Description = description,
                    Taxable = taxable
                };
                alterationList.Add(singleAlteration);
            }

            return TicketAlterationFactory.CreateTicketAlterationResource(alterationList);
        }

        private bool validateForm()
        {
            //if (FirstNameTextBox.Text == "")
            //{
            //    MessageBox.Show("You didn't specify a first name! Please enter one and try again");
            //    return false;
            //}
            //else if (LastNameTextBox.Text == "")
            //{
            //    MessageBox.Show("You didn't specify a last name! Please enter one and try again");
            //    return false;
            //}
            //else if (EmailTextBox.Text == "")
            //{
            //    MessageBox.Show("You didn't specify an email address! Please enter one and try again");
            //    return false;
            //}
            return true;
        }

        private void PrintCustomerBttn_Click(object sender, EventArgs e)
        {
            if (!validateForm())
            {
                return;
            }
            if (isNewAlteration)
            {
                InsertAlterationIntoDatabase();
            }
            else
            {
                UpdateAlterationInDatabase();
            }
            try
            {
                printTextReceipt(true);
                MessageBox.Show("Customer ticket sent to printer.");
            }
            catch
            {
                MessageBox.Show("There was an error printing. Make sure there is a printer connected");
            }
        }     

        private void ClothingSelected(TypeOfClothing type)
        {
            switch (type)
            {
                case TypeOfClothing.Jacket:
                    AddJacketModal jacketModal = new AddJacketModal(ArticleSelected);
                    jacketModal.Show();
                    break;
                case TypeOfClothing.Shirt:
                    AddShirtModal shirtModal = new AddShirtModal(ArticleSelected);
                    shirtModal.Show();
                    break;
                case TypeOfClothing.Pants:
                    AddPantsModal pantsModal = new AddPantsModal(ArticleSelected);
                    pantsModal.Show();
                    break;
                case TypeOfClothing.Vest:
                    AddVestModal vestModal = new AddVestModal(ArticleSelected);
                    vestModal.Show();
                    break;
                case TypeOfClothing.Miscellaneous:
                    AddMiscModal miscModal = new AddMiscModal(ArticleSelected);
                    miscModal.Show();
                    break;
                case TypeOfClothing.Other:
                    AddOtherModal otherModal = new AddOtherModal(ArticleSelected);
                    otherModal.Show();
                    break;
            }

        }

        private void ArticleSelected(AlterationModalCallbackArguments args)
        {
            int currentRow = AlterationGrid.CurrentCell.RowIndex;
            if(AlterationGrid.CurrentCell != null && AlterationGrid.CurrentCell.RowIndex != -1)
            {
                if (AlterationGrid.CurrentCell.RowIndex == AlterationGrid.Rows.Count - 1)
                {
                    AlterationGrid.Rows.Add("", "           " + args.Description, args.Price, false);
                }
                else
                {
                    AlterationGrid.Rows.Insert(currentRow + 1, "", "           " + args.Description, args.Price, false);
                }
            }
            AlterationGridCellChanged(null, null);
        }

        private void DisplayAddAlterationModalButton_Click(object sender, EventArgs e)
        {
            if(AlterationGrid.CurrentCell == null || AlterationGrid.CurrentCell.RowIndex == -1)
            {
                MessageBox.Show("Please enter and select an article of clothing before adding sub alterations.");
                return;
            }
            AddAlterationBaseForm alterationModal = new AddAlterationBaseForm(ClothingSelected);
            alterationModal.Show();
        }

        private void PrintEmployeeBttn_Click(object sender, EventArgs e)
        {
            if (!validateForm())
            {
                return;
            }
            if (isNewAlteration)
            {
                InsertAlterationIntoDatabase();
            }
            else
            {
                UpdateAlterationInDatabase();
            }
            try
            {
                printTextReceipt(false);
                MessageBox.Show("Employee ticket sent to printer.");
            }
            catch
            {
                MessageBox.Show("There was an error printing. Make sure there is a printer connected");
            }
        }

        private void printTextReceipt(Boolean isCustomerCopy)
        {
            PrintDocumentElement.PrintPage += printDoc_PrintPage;
            ReceiptStringBuilderArguments args = CollectDataForReceiptPrinting(isCustomerCopy);
            stringToPrint = ReceiptStringBulder.BuildStringFromArgs(args, isCustomerCopy, false);
            //string filePath = ReceiptWriter.WriteToFile(receiptText, DateInPicker.Value, FirstNameTextBox.Text);

            //string docName = "testPage.txt";
            //string docPath = filePath;
            //PrintDocumentElement.DocumentName = docName;
            //using (FileStream stream = new FileStream(docPath, FileMode.Open))
            //using (StreamReader reader = new StreamReader(stream))
            //{
            //    stringToPrint = reader.ReadToEnd();
            //}
            PrintDocumentElement.Print();
        }

        //TODO: create a separate class for printing
        void printDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            //e.PageSettings.PaperSize = new PaperSize("yeah", 500, 500); sets page size, but maybe its easier to do it through bounds below (both in measure string and drawstring. 72 pixel res?
            int charactersOnPage = 0;
            int linesPerPage = 0;

            Font myFont = new Font("Times New Roman", 13.0f, FontStyle.Regular);
            // Sets the value of charactersOnPage to the number of characters  
            // of stringToPrint that will fit within the bounds of the page.
            Rectangle boundsForString = new Rectangle(0, 0, e.MarginBounds.Width, e.MarginBounds.Height); 
            e.Graphics.MeasureString(stringToPrint, myFont, e.MarginBounds.Size, StringFormat.GenericTypographic, out charactersOnPage, out linesPerPage);

            // Draws the string within the bounds of the page
            Rectangle OnPageBounds = new Rectangle(33, 30, e.MarginBounds.Width, e.MarginBounds.Height); 
            e.Graphics.DrawString(stringToPrint, myFont, Brushes.Black, OnPageBounds, StringFormat.GenericTypographic);

            // Remove the portion of the string that has been printed.
            stringToPrint = stringToPrint.Substring(charactersOnPage);

            // Check to see if more pages are to be printed.
            e.HasMorePages = (stringToPrint.Length > 0);
        }

        private ReceiptStringBuilderArguments CollectDataForReceiptPrinting(Boolean isCustomerCopy)
        {
            ReceiptStringBuilderArguments args = new ReceiptStringBuilderArguments
            {
                TicketId = Convert.ToInt16(TicketNumberLabel.Text),
                Title = TitleComboBox.Text,
                FirstName = FirstNameTextBox.Text ?? "",
                LastName = LastNameTextBox.Text ?? "",
                MiddleName = MiddleNameTextBox.Text ?? "",
                DateIn = DateInPicker.Value,
                DateReady = DateReadyPicker.Value,
                TotalPrice = TotalPriceLabel.Text == "" ? 0 : double.Parse(TotalPriceLabel.Text, NumberStyles.Currency),
                Deposit = DepositTextBox.Text == "" ? 0 : Convert.ToDouble(DepositTextBox.Text),
                TailorName = TailorComboBox.Text,
                Telephone = PhoneTextBox.Text,
                isCustomerCopy = isCustomerCopy
            };

            if (isCustomerCopy)
            {
                args.Comments = "";
            }
            else
            {
                args.Comments = CommentBox.Text;
            }

            List<AlterationGridItem> gridItems = new List<AlterationGridItem>();
            for (int i = 0; i < AlterationGrid.Rows.Count - 1; i++)
            {
                double price = Convert.ToString(AlterationGrid["PriceCol", i].Value) == "" ? 0 : Convert.ToDouble(AlterationGrid["PriceCol", i].Value);
                int quantity = Convert.ToString(AlterationGrid["quantityCol", i].Value) == "" ? 0 : Convert.ToInt32(AlterationGrid["quantityCol", i].Value);
                String description = AlterationGrid["descriptionCol", i].Value.ToString();
                bool taxable = Convert.ToBoolean(AlterationGrid["taxableCol", i].Value);
                AlterationGridItem item = new AlterationGridItem(price, quantity, description, taxable);
                gridItems.Add(item);
            }
            args.GridItems = gridItems;

            return args;
        }

        private void DepositTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateTotalDepositAndBalance();
        }

        private void AlterationForm_Load(object sender, EventArgs e)
        {
            this.Top = 0;
        }

        #region trimming and grooming text boxes
        private void PhoneTextBox_TextChanged(object sender, EventArgs e)
        {
            String number = PhoneTextBox.Text;

            number = number.Replace("-", "");

            if (number.Length > 3)
            {
                number = number.Insert(3, "-");
            }
            if (number.Length > 7)
            {
                number = number.Insert(7, "-");
            }

            PhoneTextBox.Text = number;
            PhoneTextBox.Select(PhoneTextBox.Text.Length, 0);
        }
        #endregion

        private void FirstNameTextBox_OnLeave(object sender, EventArgs e)
        {
            FirstNameTextBox.Text = FirstNameTextBox.Text.Trim();
        }
        private void MiddleNameTextBox_OnLeave(object sender, EventArgs e)
        {
            MiddleNameTextBox.Text = MiddleNameTextBox.Text.Trim();
        }
        private void LastNameTextBox_OnLeave(object sender, EventArgs e)
        {
            LastNameTextBox.Text = LastNameTextBox.Text.Trim();
        }
        private void AddressTextBox_OnLeave(object sender, EventArgs e)
        {
            AddressTextBox.Text = AddressTextBox.Text.Trim();
        }
        private void CityTextBox_OnLeave(object sender, EventArgs e)
        {
            CityTextBox.Text = CityTextBox.Text.Trim();
        }
        private void StateTextBox_OnLeave(object sender, EventArgs e)
        {
            StateTextBox.Text = StateTextBox.Text.Trim();
        }
        private void ZipTextBox_OnLeave(object sender, EventArgs e)
        {
            ZipTextBox.Text = ZipTextBox.Text.Trim();
        }
        private void TelephoneTextBox_OnLeave(object sender, EventArgs e)
        {
            PhoneTextBox.Text = PhoneTextBox.Text.Trim();
        }
        private void EmailTextBox_OnLeave(object sender, EventArgs e)
        {
            EmailTextBox.Text = EmailTextBox.Text.Trim();
        }

        private void OrderIdTextBox_OnLeave(object sender, EventArgs e)
        {
            OrderIdTextBox.Text = OrderIdTextBox.Text.Trim();
        }

        private void EditCustomerButton_Click(object sender, EventArgs e)
        {
            CustomerRepository repo = new CustomerRepository();
            CustomerResource resource = repo.getCustomerById(customerId);
            CustomerProfile profile = new CustomerProfile(resource, CustomerProfileFinishedEditing);
            profile.Show();
        }

        private void CustomerProfileFinishedEditing(CustomerResource customerResource)
        {
            TitleComboBox.Text = customerResource.Title;
            FirstNameTextBox.Text = customerResource.FirstName;
            MiddleNameTextBox.Text = customerResource.MiddleName;
            LastNameTextBox.Text = customerResource.LastName;
            AddressTextBox.Text = customerResource.Address;
            CityTextBox.Text = customerResource.City;
            StateTextBox.Text = customerResource.State;
            ZipTextBox.Text = customerResource.Zip;
            PhoneTextBox.Text = customerResource.Telephone;
            EmailTextBox.Text = customerResource.Email; 
        }

        private void hktStandardButton1_Click(object sender, EventArgs e)
        {
            if (!validateForm())
            {
                return;
            }

            if (isNewAlteration)
            {
                InsertAlterationIntoDatabase();
            }
            else if (!isNewAlteration)
            {
                UpdateAlterationInDatabase();
            }
        }

        void Form_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (isNewAlteration)
                {

                    DialogResult dr = MessageBox.Show("Are you sure you want to close without saving?",
                    "Confirm Close", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                    if (dr == DialogResult.Yes)
                    {
                        this.Close();
                    }
                    e.Cancel = true;
                }

            }

        }
        
    }
}
