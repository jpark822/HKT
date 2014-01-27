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
using DomainModel.AdminStatsRepo;
using Microsoft.Office.Interop.Excel;

namespace HKTReceiptGenerator.AdminStats
{
    //TODO: completely overhaul this class to use ticket repository
    public partial class AdminStatsForm : Form
    {
        
        public AdminStatsForm()
        {
            InitializeComponent();
        }

        private void AdminStatsForm_Load(object sender, EventArgs e)
        {
            StartingDatePicker.Value = DateTime.Today;
            EndingDatePicker.Value = DateTime.Today;
        }

        

        private double getPriceTotalFromDatatable(System.Data.DataTable table)
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
            DateTime startDate = StartingDatePicker.Value;
            DateTime endDate = EndingDatePicker.Value;

            AdminStatsRepo repo = new AdminStatsRepo();

            //Non-Orders
            double billedNonOrders = repo.getTotalBilled(startDate, endDate, false);
            double paidAlterations = repo.GetTotalPaidNonOrdersBetweenDates(startDate, endDate, false);
            double paidRetail = repo.GetTotalPaidNonOrdersBetweenDates(startDate, endDate, true);
            TotalTicketsBilledLabel.Text = String.Format("{0:C}", billedNonOrders);
            AlterationsLabel.Text = String.Format("{0:C}", paidAlterations);
            RetailLabel.Text = String.Format("{0:C}", paidRetail);
            AlterationsPlusRetailLabel.Text = String.Format("{0:C}", paidAlterations + paidRetail);

            //Orders
            double totalPaidTaxableFromOrders = repo.GetTotalPaidOrdersBetweenDates(startDate, endDate, true);
            double totalPaidNonTaxableFromOrders = repo.GetTotalPaidOrdersBetweenDates(startDate, endDate, false);
            double billedOrders = repo.getTotalBilled(startDate, endDate, true);
            TotalPaidTaxableFromOrdersLabel.Text = String.Format("{0:C}", totalPaidTaxableFromOrders);
            TotalPaidNonTaxableFromOrdersLabel.Text = String.Format("{0:C}",totalPaidNonTaxableFromOrders);
            TotalOrdersBilledLabel.Text = String.Format("{0:C}", billedOrders);
            TaxablePlusNonTaxableOrdersLabel.Text = String.Format("{0:C}", totalPaidTaxableFromOrders + totalPaidNonTaxableFromOrders);

            //totals
            TotalBilledLabel.Text = String.Format("{0:C}", billedOrders + billedNonOrders);
            double totalRetail = paidRetail + totalPaidTaxableFromOrders;
            double totalAlterations = paidAlterations + totalPaidNonTaxableFromOrders;
            TotalTaxableLabel.Text = String.Format("{0:C}", totalRetail);
            TotalNonTaxableLabel.Text = String.Format("{0:C}", totalAlterations);
            TotalClosedLabel.Text = String.Format("{0:C}", totalRetail + totalAlterations);
        }

        private void GetEmailsButton_Click(object sender, EventArgs e)
        {
            TicketRepository ticketRepo = new TicketRepository();
            List<TicketResource> listOfTickets = ticketRepo.GetDistinctEmailAddressBetweenDates(StartingDatePicker.Value, EndingDatePicker.Value);

            String emailString = "";
            for (int i = 0; i < listOfTickets.Count; i++)
            {
                TicketResource ticket = listOfTickets[i];
                if (i == 0)
                {
                    emailString += ticket.Email;
                }
                else
                {
                    emailString += ", " + ticket.Email;
                }
            }

            EmailResultTextBox.Text = emailString;
        }

        private void CopyToClipboardButton_Click(object sender, EventArgs e)
        {
            if (EmailResultTextBox.Text.Length == 0)
            {
                return;
            }
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            excelApp.Visible = true;

            _Workbook workbook = (_Workbook)(excelApp.Workbooks.Add(Type.Missing));
            _Worksheet worksheet = (_Worksheet)workbook.ActiveSheet;

            TicketRepository ticketRepo = new TicketRepository();
            List<TicketResource> listOfTickets = ticketRepo.GetDistinctEmailAddressBetweenDates(StartingDatePicker.Value, EndingDatePicker.Value);

            for (int i = 0; i < listOfTickets.Count; i++)
            {
                TicketResource ticket = listOfTickets[i];
                int row = i + 1;
                worksheet.Cells[row, "A"] = ticket.LastName;
                worksheet.Cells[row, "B"] = ticket.FirstName;
                worksheet.Cells[row, "C"] = ticket.Email;
            }
            worksheet.Columns["A:C"].AutoFit();
        }

        private void BackupButton_Click(object sender, EventArgs e)
        {
            Emailer.SendBackupToEmail();
        }

        private void getMailingAddressesButton_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            excelApp.Visible = true;

            _Workbook workbook = (_Workbook)(excelApp.Workbooks.Add(Type.Missing));
            _Worksheet worksheet = (_Worksheet)workbook.ActiveSheet;

            TicketRepository ticketRepo = new TicketRepository();
            List<TicketResource> listOfTickets = ticketRepo.GetDistinctMailingAddressBetweenDates(StartingDatePicker.Value, EndingDatePicker.Value);

            //change the getDistintMailing to not accept "" as a unique address. then we can remove this row checking
            int row = 1;
            for (int i = 0; i < listOfTickets.Count; i++)
            {
                TicketResource ticket = listOfTickets[i];
                if (ticket.Address == "")
                {
                    continue;
                }
                worksheet.Cells[row, "A"] = ticket.LastName;
                worksheet.Cells[row, "B"] = ticket.FirstName;
                worksheet.Cells[row, "C"] = ticket.Address;
                worksheet.Cells[row, "D"] = ticket.City;
                worksheet.Cells[row, "E"] = ticket.State;
                worksheet.Cells[row, "F"] = ticket.Zip;
                row++;
            }
            worksheet.Columns["A:F"].AutoFit();
        }
    }
}