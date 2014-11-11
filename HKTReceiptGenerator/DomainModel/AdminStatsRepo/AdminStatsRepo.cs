using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SQLite;
using DomainModel.TicketAlterations;
using MySql.Data.MySqlClient;

namespace DomainModel.AdminStatsRepo
{
    public class AdminStatsRepo : BaseRepository
    {
        private const double taxRatePlusOne = 1.07;
        private const String shortDateFormatString = "{0:yyyy-MM-dd}";

        public double getTotalBilled(DateTime startDate, DateTime endDate, Boolean isOrder)
        {
            DBConnector connector = new DBConnector();
            MySqlCommand getBilledCommand = new MySqlCommand();
            getBilledCommand.Connection = connector.connection;
            
            string sql = @"SELECT price, taxable
                                                from Tickets tix
                                                join Ticket_Alterations ta
                                                on tix.ticket_id = ta.ticket_id
                                                AND date_in >= @start_date
                                                AND date_in <= @end_date ";

            if (isOrder)
            {
                sql += @"AND order_id != ''
                             AND order_id IS NOT NULL";
            }
            else
            {
                sql += @"AND (order_id = ''
                            or order_id IS NULL)";
            }

            getBilledCommand.CommandText = sql;
            getBilledCommand.Parameters.AddWithValue("@start_date", ConvertDateTimeToUTCString(startDate));
            getBilledCommand.Parameters.AddWithValue("@end_date", ConvertDateTimeToUTCString(endDate));

            try
            {
                MySqlDataReader reader = getBilledCommand.ExecuteReader();
                double total = getPriceTotalFromReader(reader);
                reader.Close();
                connector.CloseConnection();
                return total;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("There was an error. Contact Jay with this message: " + ex.Message + " error code: " + ex.Number);
            }
            return 0;
        }

        public double GetTotalPaidOrdersBetweenDates(DateTime startDate, DateTime endDate, Boolean taxable)
        {
            DBConnector connector = new DBConnector();
            MySqlCommand getPaidCommand = new MySqlCommand();
            getPaidCommand.Connection = connector.connection;
            getPaidCommand.CommandText = @"select price, taxable
                                            from Tickets tix
                                            join Ticket_Alterations ta
                                            on tix.ticket_id = ta.ticket_id
                                            AND completed_date >= @start_date
                                            AND completed_date <= @end_date
                                            AND taxable = @taxable
                                            AND status = 'd'
                                            AND order_id != '' 
                                            AND order_id IS NOT NULL";
            getPaidCommand.Parameters.AddWithValue("@start_date", ConvertDateTimeToUTCString(startDate));
            getPaidCommand.Parameters.AddWithValue("@end_date", ConvertDateTimeToUTCString(endDate));
            int taxableInt = taxable == true ? 1 : 0;
            getPaidCommand.Parameters.AddWithValue("@taxable", taxableInt);

            try
            {
                MySqlDataReader reader = getPaidCommand.ExecuteReader();
                double total = getPriceTotalFromReader(reader);
                reader.Close();
                connector.CloseConnection();
                return total;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("There was an error. Contact Jay with this message: " + ex.Message + " error code: " + ex.Number);
            }
            return 0;
        }
      
        public double GetTotalPaidNonOrdersBetweenDates(DateTime startDate, DateTime endDate, Boolean taxable)
        {
            DBConnector connector = new DBConnector();
            MySqlCommand getPaidCommand = new MySqlCommand();
            getPaidCommand.Connection = connector.connection;
            getPaidCommand.CommandText = @"select price, taxable
                                            from Tickets tix
                                            join Ticket_Alterations ta
                                            on tix.ticket_id = ta.ticket_id
                                            AND completed_date >= @start_date
                                            AND completed_date <= @end_date
                                            AND taxable = @taxable
                                            AND status = 'd'
                                            AND (order_id = '' 
                                            or order_id IS NULL)";
            getPaidCommand.Parameters.AddWithValue("@start_date", ConvertDateTimeToUTCString(startDate));
            getPaidCommand.Parameters.AddWithValue("@end_date", ConvertDateTimeToUTCString(endDate));
            int taxableInt = taxable == true ? 1 : 0;
            getPaidCommand.Parameters.AddWithValue("@taxable", taxableInt);

            try
            {
                MySqlDataReader reader = getPaidCommand.ExecuteReader();
                double total = getPriceTotalFromReader(reader);
                reader.Close();
                connector.CloseConnection();
                return total;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("There was an error. Contact Jay with this message: " + ex.Message + " error code: " + ex.Number);
            }
            return 0;
        }

        private double getPriceTotalFromReader(MySqlDataReader reader)
        {
            double total = 0;
            while (reader.Read())
            {
                total += Convert.ToInt32(reader["taxable"]) == 0 ? Convert.ToDouble(reader["price"]) : Convert.ToDouble(reader["price"]) * 1.07;
            }
            return total;
        }
    }
}
