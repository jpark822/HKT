using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SQLite;
using DomainModel.TicketAlterations;

namespace DomainModel.AdminStatsRepo
{
    public class AdminStatsRepo
    {
        private const double taxRatePlusOne = 1.07;
        private const String shortDateFormatString = "{0:yyyy-MM-dd}";

        public double getTotalBilled(DateTime startDate, DateTime endDate, Boolean isOrder)
        {
            String convertedStartDate = string.Format(shortDateFormatString, startDate);
            String convertedEndDate = string.Format(shortDateFormatString, endDate.AddDays(1));

            String sqlToAdd = "";
            if (isOrder)
            {
                sqlToAdd = @"AND order_id != ''
                             AND order_id NOT NULL";
            }
            else
            {
                sqlToAdd = @"AND (order_id = ''
                            or order_id IS NULL)";
            }

            SQLiteDatabase db = new SQLiteDatabase();
            String sql = string.Format(@"select price, taxable
                                                from Tickets tix
                                                join ticket_alterations ta
                                                on tix.ticket_id = ta.ticket_id
                                                AND date_in >= '{0}'
                                                AND date_in <= '{1}' " + sqlToAdd, convertedStartDate, convertedEndDate);
            DataTable results = db.GetDataTable(sql);
            return getPriceTotalFromDatatable(results);
        }

        public double GetTotalPaidOrdersBetweenDates(DateTime startDate, DateTime endDate, Boolean taxable)
        {
            String convertedStartDate = string.Format(shortDateFormatString, startDate);
            String convertedEndDate = string.Format(shortDateFormatString, endDate.AddDays(1));

            int taxableInt = taxable == true ? 1 : 0;

            SQLiteDatabase db = new SQLiteDatabase();
            string sql = String.Format(@"select price, taxable
                                            from Tickets tix
                                            join ticket_alterations ta
                                            on tix.ticket_id = ta.ticket_id
                                            AND julianday(completed_date) >= julianday('{0}')
                                            AND julianday(completed_date) <= julianday('{1}')
                                            AND taxable = {2}
                                            AND status = 'd'
                                            AND order_id != '' 
                                            AND order_id NOT NULL", convertedStartDate, convertedEndDate, taxableInt);
            DataTable resultTicketTable = db.GetDataTable(sql);

            return getPriceTotalFromDatatable(resultTicketTable);
        }
      
        public double GetTotalPaidNonOrdersBetweenDates(DateTime startDate, DateTime endDate, Boolean taxable)
        {
            String convertedStartDate = string.Format(shortDateFormatString, startDate);
            String convertedEndDate = string.Format(shortDateFormatString, endDate.AddDays(1)); 

            int taxableInt = taxable == true ? 1 : 0;

            SQLiteDatabase db = new SQLiteDatabase();
            string sql = String.Format(@"select price, taxable
                                            from Tickets tix
                                            join ticket_alterations ta
                                            on tix.ticket_id = ta.ticket_id
                                            AND julianday(completed_date) >= julianday('{0}')
                                            AND julianday(completed_date) <= julianday('{1}')
                                            AND taxable = {2}
                                            AND status = 'd'
                                            AND (order_id = '' 
                                            or order_id IS NULL)", convertedStartDate, convertedEndDate, taxableInt);
            DataTable resultTicketTable = db.GetDataTable(sql);

            return getPriceTotalFromDatatable(resultTicketTable);
        }

        private double getPriceTotalFromDatatable(DataTable table)
        {
            double total = 0;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];
                total += Convert.ToInt32(row["taxable"]) == 0 ? (double)row["price"] : (double)row["price"] * 1.07;
            }
            return total;
        }
    }
}
