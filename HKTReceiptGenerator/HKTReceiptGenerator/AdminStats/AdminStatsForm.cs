using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DomainModel.Ticket;

namespace HKTReceiptGenerator.AdminStats
{
    //TODO: completely overhaul this class to use ticket repository
    public partial class AdminStatsForm : Form
    {
        private const double taxRatePlusOne = 1.07;
        public AdminStatsForm()
        {
            InitializeComponent();
        }

        private void AdminStatsForm_Load(object sender, EventArgs e)
        {
            StartingDatePicker.Value = DateTime.Today;
            EndingDatePicker.Value = DateTime.Today;
        }

        private double getTotalBilled(String startDate, String endDate)
        {
            SQLiteDatabase db = new SQLiteDatabase();
            DataTable results = db.GetDataTable(string.Format(@"select price
                                                from Tickets tix
                                                join ticket_alterations ta
                                                on tix.ticket_id = ta.ticket_id
                                                AND date_in >= '{0}'
                                                AND date_in <= '{1}'", startDate, endDate));
            return getPriceTotalFromDatatable(results);
        }

        private double GetTotalRetail(String startDate, String endDate)
        {
            SQLiteDatabase db = new SQLiteDatabase();
            DataTable results = db.GetDataTable(string.Format(@"select price
                                                from Tickets tix
                                                join ticket_alterations ta
                                                on tix.ticket_id = ta.ticket_id
                                                AND date_in >= '{0}'
                                                AND date_in <= '{1}'
                                                AND taxable = 1
                                                AND status = 'd'", startDate, endDate));
            double total = getPriceTotalFromDatatable(results);
            return total * taxRatePlusOne;
        }
        private double GetTotalAlterations(String startDate, String endDate)
        {
            SQLiteDatabase db = new SQLiteDatabase();
            DataTable results = db.GetDataTable(string.Format(@"select price
                                                from Tickets tix
                                                join ticket_alterations ta
                                                on tix.ticket_id = ta.ticket_id
                                                AND date_in >= '{0}'
                                                AND date_in <= '{1}'
                                                AND taxable = 0
                                                AND status = 'd'", startDate, endDate));
            return getPriceTotalFromDatatable(results);
        }

        private double getPriceTotalFromDatatable(DataTable table)
        {
            double total = 0;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];
                total += (double)row["price"];
            }
            return total;
        }

        private void GetStatsButton_Click(object sender, EventArgs e)
        {
            String startDate = string.Format("{0:yyyy-MM-dd}", StartingDatePicker.Value);
            String endDate = string.Format("{0:yyyy-MM-dd}", EndingDatePicker.Value.AddDays(1)); //add 1 date possibly because of 00:00:00 time

            TotalBilledLabel.Text = String.Format("{0:C}",getTotalBilled(startDate, endDate));
            double totalRetail = GetTotalRetail(startDate, endDate);
            double totalAlterations = GetTotalAlterations(startDate, endDate);
            RetailLabel.Text = String.Format("{0:C}",totalRetail);
            AlterationsLabel.Text = String.Format("{0:C}", totalAlterations);
            TotalClosedLabel.Text = String.Format("{0:C}", totalRetail + totalAlterations);
        }

        private void GetEmailsButton_Click(object sender, EventArgs e)
        {
            TicketRepository ticketRepo = new TicketRepository();
            List<String> listOfEmails = ticketRepo.GetDistinctEmailAddressBetweenDates(StartingDatePicker.Value, EndingDatePicker.Value);

            String emailString = "";
            for (int i = 0; i < listOfEmails.Count; i++)
            {
                if (i == 0)
                {
                    emailString += listOfEmails[i];
                }
                else
                {
                    emailString += ", " + listOfEmails[i];
                }
            }

            EmailResultTextBox.Text = emailString;
        }

        private void CopyToClipboardButton_Click(object sender, EventArgs e)
        {
            if (EmailResultTextBox.Text != "" && EmailResultTextBox.Text != null)
            Clipboard.SetText(EmailResultTextBox.Text);
        }

        private void BackupButton_Click(object sender, EventArgs e)
        {
            Emailer.SendBackupToEmail();
        }
    }
}