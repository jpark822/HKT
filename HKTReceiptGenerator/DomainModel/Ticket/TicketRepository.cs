using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SQLite;
using DomainModel.TicketAlterations;

namespace DomainModel.Ticket
{
    //TODO use mapping library (probably NHibernate) to pipe in values from the database.
    public class TicketRepository
    {
        public enum TicketProperty
        {
            TicketId,
            Status,
            FirstName,
            MiddleName,
            LastName,
            Address,
            City ,
            State ,
            Zip,
            Telephone,
            Email,
            Comments,
            PickedUp,
            LastModifiedTimestamp,
            DateIn ,
            DateReady ,
            TotalPrice ,
            Deposit ,
            TailorName,
            OrderId
        };

        /* @return the generated ticketID of the new ticket */
        public int InsertNewTicket(TicketResource ticket)
        {
            Dictionary<String, object> itemsToInsert = ConvertTicketIntoDictionary(ticket);

            SQLiteDatabase db = new SQLiteDatabase();
            db.Insert("Tickets", itemsToInsert);
            DataRow lastRow = db.GetLastRowInTable("Tickets");

            return Convert.ToInt32(lastRow["ticket_id"]);
        }


        public void UpdateTicket(TicketResource ticket)
        {
            Dictionary<String, object> itemsToInsert = ConvertTicketIntoDictionary(ticket);

            SQLiteDatabase db = new SQLiteDatabase();
            db.Update("Tickets", itemsToInsert, "ticket_id = " + ticket.TicketId.ToString());
        }

        public void MarkTicketAsDone(int ticketId)
        {
            SQLiteDatabase db = new SQLiteDatabase();
            Dictionary<String, object> arguments = new Dictionary<String, object>();
            arguments.Add("status", "d");
            db.Update("Tickets", arguments, "ticket_id = " + ticketId);
        }

        public void MarkTicketAsDonePaidAndPickedUp(int ticketId)
        {
            TicketResource ticket = GetTicketByTicketID(ticketId);

            SQLiteDatabase db = new SQLiteDatabase();
            Dictionary<String, object> arguments = new Dictionary<String, object>();
            arguments.Add("status", "d");
            arguments.Add("deposit", ticket.TotalPrice);
            arguments.Add("picked_up", "y");
            db.Update("Tickets", arguments, "ticket_id = " + ticketId);
        }

        public TicketResource GetTicketByTicketID(int ticketId)
        {
            SQLiteDatabase db = new SQLiteDatabase();
            string sql = "select * from Tickets where ticket_id = " + ticketId;
            DataTable resultTicketTable = db.GetDataTable(sql);
            DataRow queryResult = resultTicketTable.Rows[0];
            TicketResource ticketRes = ConvertDataRowToTicketResource(queryResult);
            return ticketRes;
        }

        public TicketResource GetCustomerInfoBasedOnTicketId(int ticketId)
        {
            TicketResource ticketRes = GetTicketByTicketID(ticketId);
            ticketRes.Comments = "";
            ticketRes.DateIn = DateTime.Today;
            ticketRes.DateReady = DateTime.Today;
            ticketRes.TailorName = "";
            ticketRes.PickedUp = "";
            ticketRes.Status = "a";
            ticketRes.TotalPrice = 0;
            ticketRes.Deposit = 0;
            ticketRes.TicketId = 0;

            return ticketRes;
        }

        public void DeleteTicketByTicketID(int ticketId)
        {
            SQLiteDatabase db = new SQLiteDatabase();
            db.Delete("Tickets", "ticket_id = " + ticketId);
        }

        public List<TicketResource> GetTicketsByArguments(Dictionary<TicketProperty, object> arguments)
        {
            String sql = "select * from Tickets where ";

            int counter = 0;
            foreach (KeyValuePair<TicketProperty, object> entry in arguments)
            {
                if (entry.Key == TicketProperty.TicketId)
                {
                    sql += "ticket_id = " + (String)entry.Value;
                }
                if (entry.Key == TicketProperty.FirstName)
                {
                    sql += "first_name = \"" + (String)entry.Value + "\"  COLLATE NOCASE";
                }
                if (entry.Key == TicketProperty.MiddleName)
                {
                    sql += "middle_name = \"" + (String)entry.Value + "\"  COLLATE NOCASE";
                }
                if (entry.Key == TicketProperty.LastName)
                {
                    sql += "last_name = \"" + (String)entry.Value + "\"  COLLATE NOCASE";
                }
                if (entry.Key == TicketProperty.Address)
                {
                    sql += "address = \"" + (String)entry.Value + "\"  COLLATE NOCASE";
                }
                if (entry.Key == TicketProperty.City)
                {
                    sql += "city = \"" + (String)entry.Value + "\"  COLLATE NOCASE";
                }
                if (entry.Key == TicketProperty.State)
                {
                    sql += "state = \"" + (String)entry.Value + "\"  COLLATE NOCASE";
                }
                if (entry.Key == TicketProperty.Zip)
                {
                    sql += "zip = \"" + (String)entry.Value + "\"  COLLATE NOCASE";
                }
                if (entry.Key == TicketProperty.Telephone)
                {
                    sql += "telephone = \"" + (String)entry.Value + "\"  COLLATE NOCASE";
                }
                if (entry.Key == TicketProperty.Email)
                {
                    sql += "email = \"" + (String)entry.Value + "\"  COLLATE NOCASE";
                }
                if (entry.Key == TicketProperty.PickedUp)
                {
                    sql += "picked_up = \"" + (String)entry.Value + "\"  COLLATE NOCASE";
                }
                if (entry.Key == TicketProperty.Status)
                {
                    sql += "status = \"" + (String)entry.Value + "\"  COLLATE NOCASE";
                }
                if (entry.Key == TicketProperty.TailorName)
                {
                    sql += "tailor_name = \"" + (String)entry.Value + "\"  COLLATE NOCASE";
                }
                if (entry.Key == TicketProperty.OrderId)
                {
                    sql += "order_id = \"" + (String)entry.Value + "\"  COLLATE NOCASE";
                }

                counter++;
                if (counter < arguments.Count)
                {
                    sql += " and ";
                }
            }

            SQLiteDatabase db = new SQLiteDatabase();
            DataTable result = db.GetDataTable(sql);

            List<TicketResource> ticketResources = new List<TicketResource>();
            foreach(DataRow row in result.Rows)
            {
                TicketResource ticketRes = ConvertDataRowToTicketResource(row);
                ticketResources.Add(ticketRes);
            }

            return ticketResources;
        }

        public List<String> GetDistinctEmailAddressBetweenDates(DateTime startDate, DateTime endDate)
        {
            SQLiteDatabase db = new SQLiteDatabase();
            string sql = String.Format(@"select distinct email from Tickets where date_in >= '{0}' AND date_in <= '{1}'", startDate, endDate);
            DataTable resultTicketTable = db.GetDataTable(sql);

            List<String> emails = new List<String>();
            foreach (DataRow row in resultTicketTable.Rows)
            {
                emails.Add(Convert.ToString(row["email"]));
            }

            return emails;
        }

        private Dictionary<String, object> ConvertTicketIntoDictionary(TicketResource ticket)
        {
            Dictionary<String, object> ticketArgs = new Dictionary<string, object>();
            ticketArgs.Add("name_title", ticket.Title);
            ticketArgs.Add("first_name", ticket.FirstName);
            ticketArgs.Add("middle_name", ticket.MiddleName);
            ticketArgs.Add("last_name", ticket.LastName);
            ticketArgs.Add("address", ticket.Address);
            ticketArgs.Add("city", ticket.City);
            ticketArgs.Add("state", ticket.State);
            ticketArgs.Add("zip", ticket.Zip);
            ticketArgs.Add("telephone", ticket.Telephone);
            ticketArgs.Add("email", ticket.Email);
            ticketArgs.Add("date_in", string.Format("{0:yyyy-MM-dd HH:mm:ss}", ticket.DateIn));
            ticketArgs.Add("date_ready", string.Format("{0:yyyy-MM-dd HH:mm:ss}", ticket.DateReady));
            ticketArgs.Add("last_modified_timestamp", string.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Now));
            ticketArgs.Add("status", ticket.Status);
            ticketArgs.Add("comments", ticket.Comments);
            ticketArgs.Add("tailor_name", ticket.TailorName);
            ticketArgs.Add("total_price", ticket.TotalPrice);
            ticketArgs.Add("picked_up", ticket.PickedUp);
            ticketArgs.Add("deposit", ticket.Deposit);
            ticketArgs.Add("order_id", ticket.OrderId);

            return ticketArgs;
        }

        private TicketResource ConvertDataRowToTicketResource(DataRow dataRow)
        {
            int ticketId = dataRow["ticket_id"] is DBNull ? 0 : Convert.ToInt32(dataRow["ticket_id"]);
            String title = dataRow["name_title"] is DBNull ? "" : (String)dataRow["name_title"] ?? "";
            String firstName = dataRow["first_name"] is DBNull ? "" : (String)dataRow["first_name"] ?? "";
            String middleName = dataRow["middle_name"] is DBNull ? "" : (String)dataRow["middle_name"] ?? "";
            String lastName = dataRow["last_name"] is DBNull ? "" : (String)dataRow["last_name"] ?? "";
            String address = dataRow["address"] is DBNull ? "" : (String)dataRow["address"] ?? "";
            String city = dataRow["city"] is DBNull ? "" : (String)dataRow["city"] ?? "";
            String state = dataRow["state"] is DBNull ? "" : (String)dataRow["state"] ?? "";
            String zip = dataRow["zip"] is DBNull ? "" : (String)dataRow["zip"] ?? "";
            String telephone = dataRow["telephone"] is DBNull ? "" : (String)dataRow["telephone"] ?? "";
            String email = dataRow["email"] is DBNull ? "" : (String)dataRow["email"] ?? "";
            String status = dataRow["status"] is DBNull ? "" : (String)dataRow["status"] ?? "";
            double totalPrice = dataRow["total_price"] is DBNull ? 0 : (double)dataRow["total_price"];
            double deposit = dataRow["deposit"] is DBNull ? 0 : (double)dataRow["deposit"];
            String comments = dataRow["comments"] is DBNull ? "" : (String)dataRow["comments"] ?? "";
            String pickedUp = dataRow["picked_up"] is DBNull ? "n/a" : (String)dataRow["picked_up"] ?? "";
            DateTime dateIn = (DateTime)dataRow["date_in"];
            DateTime dateReady = (DateTime)dataRow["date_ready"];
            DateTime lastModifiedTimestamp = (DateTime)dataRow["last_modified_timestamp"];
            String tailorName = dataRow["tailor_name"] is DBNull ? "" : (String)dataRow["tailor_name"];
            String orderId = dataRow["order_id"] is DBNull ? "" : (String)dataRow["order_id"];

            return TicketFactory.CreateTicket(ticketId, status, title, firstName, lastName, middleName, address, city, state, zip, telephone, email, comments, pickedUp, dateIn, dateReady, totalPrice, deposit, tailorName, orderId);
        }
    }
}
