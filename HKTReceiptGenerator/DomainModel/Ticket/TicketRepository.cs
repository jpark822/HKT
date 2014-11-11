using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using DomainModel.TicketAlterations;
using MySql.Data.MySqlClient;

namespace DomainModel.Ticket
{
    //TODO use mapping library (probably NHibernate) to pipe in values from the database.
    //TODO convert mySQL exections to stored procedures 
    public class TicketRepository : BaseRepository
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
            DBConnector connector = new DBConnector();
            MySqlCommand insertCommand = new MySqlCommand();
            insertCommand.Connection = connector.connection;
            insertCommand.CommandText = @"INSERT into Tickets (ticket_id, status, last_modified_timestamp, first_name, middle_name, last_name, address, city, state, zip, date_in, date_ready, comments, telephone, email, total_price, picked_up, deposit, tailor_name, name_title, order_id, completed_date) values (@ticket_id, @status, @last_modified_timestamp, @first_name, @middle_name, @last_name, @address, @city, @state, @zip, @date_in, @date_ready, @comments, @telephone, @email, @total_price, @picked_up, @deposit, @tailor_name, @name_title, @order_id, @completed_date)";
            insertCommand.Parameters.AddWithValue("@ticket_id", ticket.TicketId);
            insertCommand.Parameters.AddWithValue("@status", ticket.Status);
            insertCommand.Parameters.AddWithValue("@last_modified_timestamp", ConvertDateTimeToUTCString(DateTime.Now));
            insertCommand.Parameters.AddWithValue("@first_name", ticket.FirstName);
            insertCommand.Parameters.AddWithValue("@middle_name", ticket.MiddleName);
            insertCommand.Parameters.AddWithValue("@last_name", ticket.LastName);
            insertCommand.Parameters.AddWithValue("@address", ticket.Address);
            insertCommand.Parameters.AddWithValue("@city", ticket.City);
            insertCommand.Parameters.AddWithValue("@state", ticket.State);
            insertCommand.Parameters.AddWithValue("@zip", ticket.Zip);
            insertCommand.Parameters.AddWithValue("@date_in", ConvertDateTimeToUTCString(ticket.DateIn));
            insertCommand.Parameters.AddWithValue("@date_ready", ConvertDateTimeToUTCString(ticket.DateReady));
            insertCommand.Parameters.AddWithValue("@comments", ticket.Comments);
            insertCommand.Parameters.AddWithValue("@telephone", ticket.Telephone);
            insertCommand.Parameters.AddWithValue("@email", ticket.Email);
            insertCommand.Parameters.AddWithValue("@total_price", ticket.TotalPrice);
            insertCommand.Parameters.AddWithValue("@picked_up", ticket.PickedUp);
            insertCommand.Parameters.AddWithValue("@deposit", ticket.Deposit);
            insertCommand.Parameters.AddWithValue("@tailor_name", ticket.TailorName);
            insertCommand.Parameters.AddWithValue("@name_title", ticket.Title);
            insertCommand.Parameters.AddWithValue("@order_id", ticket.OrderId);
            insertCommand.Parameters.AddWithValue("@completed_date", ConvertDateTimeToUTCString(ticket.CompletedDate));

            //race condition prone. First on list to convert to stored proc
            MySqlCommand getLastRowCommand = new MySqlCommand();
            getLastRowCommand.Connection = connector.connection;
            getLastRowCommand.CommandText = "SELECT ticket_id FROM Tickets ORDER BY ticket_id DESC LIMIT 1;";
            try
            {
                insertCommand.ExecuteNonQuery();
                MySqlDataReader reader = getLastRowCommand.ExecuteReader();
                int ticketId = 0;
                while (reader.Read())
                {
                    ticketId = (int)reader["ticket_id"];
                }
                connector.CloseConnection();
                reader.Close();
                return ticketId;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("There was an error. Contact Jay with this message: " + ex.Message + " error code: " + ex.Number);
            }
            return 1;

        }

        public void UpdateTicket(TicketResource ticket)
        {
            DBConnector connector = new DBConnector();
            MySqlCommand updateCommand = new MySqlCommand();
            updateCommand.Connection = connector.connection;
            updateCommand.CommandText = "UPDATE Tickets SET ticket_id = @ticket_id, status = @status ,last_modified_timestamp = @last_modified_timestamp, first_name = @first_name, middle_name = @middle_name, last_name = @last_name, address = @address, city = @city, state = @state, zip = @zip, date_in = @date_in, date_ready = @date_ready, comments = @comments, telephone = @telephone, email = @email, total_price = @total_price, picked_up = @picked_up, deposit = @deposit, tailor_name = @tailor_name, name_title = @name_title, order_id = @order_id, completed_date = @completed_date WHERE ticket_id = @ticket_id";
            updateCommand.Parameters.AddWithValue("@ticket_id", ticket.TicketId);
            updateCommand.Parameters.AddWithValue("@status", ticket.Status);
            updateCommand.Parameters.AddWithValue("@last_modified_timestamp", ConvertDateTimeToUTCString(DateTime.Now));
            updateCommand.Parameters.AddWithValue("@first_name", ticket.FirstName);
            updateCommand.Parameters.AddWithValue("@middle_name", ticket.MiddleName);
            updateCommand.Parameters.AddWithValue("@last_name", ticket.LastName);
            updateCommand.Parameters.AddWithValue("@address", ticket.Address);
            updateCommand.Parameters.AddWithValue("@city", ticket.City);
            updateCommand.Parameters.AddWithValue("@state", ticket.State);
            updateCommand.Parameters.AddWithValue("@zip", ticket.Zip);
            updateCommand.Parameters.AddWithValue("@date_in", ConvertDateTimeToUTCString(ticket.DateIn));
            updateCommand.Parameters.AddWithValue("@date_ready", ConvertDateTimeToUTCString(ticket.DateReady));
            updateCommand.Parameters.AddWithValue("@comments", ticket.Comments);
            updateCommand.Parameters.AddWithValue("@telephone", ticket.Telephone);
            updateCommand.Parameters.AddWithValue("@email", ticket.Email);
            updateCommand.Parameters.AddWithValue("@total_price", ticket.TotalPrice);
            updateCommand.Parameters.AddWithValue("@picked_up", ticket.PickedUp);
            updateCommand.Parameters.AddWithValue("@deposit", ticket.Deposit);
            updateCommand.Parameters.AddWithValue("@tailor_name", ticket.TailorName);
            updateCommand.Parameters.AddWithValue("@name_title", ticket.Title);
            updateCommand.Parameters.AddWithValue("@order_id", ticket.OrderId);
            updateCommand.Parameters.AddWithValue("@completed_date", ConvertDateTimeToUTCString(ticket.CompletedDate));

            try
            {
                updateCommand.ExecuteNonQuery();
                connector.CloseConnection();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("There was an error. Contact Jay with this message: " + ex.Message + " error code: " + ex.Number);
            }

        }

        public TicketResource GetTicketByTicketID(int ticketId)
        {
            DBConnector connector = new DBConnector();
            MySqlCommand getTicketCommand = new MySqlCommand();
            getTicketCommand.Connection = connector.connection;
            getTicketCommand.CommandText = "select * from Tickets where ticket_id = @ticket_id LIMIT 1";
            getTicketCommand.Parameters.AddWithValue("@ticket_id", ticketId);

            TicketResource ticketToReturn = null;
            try
            {
                MySqlDataReader reader = getTicketCommand.ExecuteReader();
                while (reader.Read())
                {
                    ticketToReturn = ConvertSQLReaderRowToTicketResource(reader);
                }
                reader.Close();
                connector.CloseConnection();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("There was an error. Contact Jay with this message: " + ex.Message + " error code: " + ex.Number);
            }
            
            return ticketToReturn;
        }

        public void MarkTicketAsDonePaidAndPickedUp(int ticketId)
        {
            TicketResource ticket = GetTicketByTicketID(ticketId);
            ticket.Status = "d";
            ticket.Deposit = ticket.TotalPrice;
            ticket.PickedUp = "y";
            ticket.CompletedDate = DateTime.Today;
            UpdateTicket(ticket);
        }

        //for migration purposes only. delete.
        public List<TicketResource> GetAllTickets()
        {
            SQLiteDatabase db = new SQLiteDatabase();
            string sql = "select * from Tickets";
            DataTable result = db.GetDataTable(sql);

            List<TicketResource> ticketResources = new List<TicketResource>();
            foreach (DataRow row in result.Rows)
            {
                //just do an insert here instead
                TicketResource ticketRes = ConvertDataRowToTicketResource(row);
                InsertNewTicket(ticketRes);
                ticketResources.Add(ticketRes);
            }
            return ticketResources;
        }
        
        //should be returning a customer info object, not a broken ticket resource. refactor
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
            ticketRes.OrderId = "";

            return ticketRes;
        }

        public void DeleteTicketByTicketID(int ticketId)
        {
            DBConnector connector = new DBConnector();
            MySqlCommand deleteCommand = new MySqlCommand();
            deleteCommand.Connection = connector.connection;
            deleteCommand.CommandText = "DELETE from Tickets WHERE ticket_id = @ticket_id";
            deleteCommand.Parameters.AddWithValue("@ticket_id", ticketId);

            try
            {
                deleteCommand.ExecuteNonQuery();
                connector.CloseConnection();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("There was an error. Contact Jay with this message: " + ex.Message + " error code: " + ex.Number);
            }
        }

        public List<TicketResource> GetTicketsByArguments(Dictionary<TicketProperty, object> arguments)
        {
            DBConnector connector = new DBConnector();
            MySqlCommand getTicketsCommand = new MySqlCommand();
            getTicketsCommand.Connection = connector.connection;
            String sql = "select * from Tickets where ";

            int counter = 0;
            foreach (KeyValuePair<TicketProperty, object> entry in arguments)
            {
                if (entry.Key == TicketProperty.TicketId)
                {
                    sql += "ticket_id = @ticket_id";
                    getTicketsCommand.Parameters.AddWithValue("@ticket_id", Convert.ToInt32(entry.Value));
                }
                if (entry.Key == TicketProperty.FirstName)
                {
                    sql += "first_name = @first_name";
                    getTicketsCommand.Parameters.AddWithValue("@first_name", (String)entry.Value);
                }
                if (entry.Key == TicketProperty.MiddleName)
                {
                    sql += "middle_name = @middle_name";
                    getTicketsCommand.Parameters.AddWithValue("@middle_name", (String)entry.Value);
                }
                if (entry.Key == TicketProperty.LastName)
                {
                    sql += "last_name = @last_name";
                    getTicketsCommand.Parameters.AddWithValue("@last_name", (String)entry.Value);
                }
                if (entry.Key == TicketProperty.Address)
                {
                    sql += "address = @address";
                    getTicketsCommand.Parameters.AddWithValue("@address", (String)entry.Value);
                }
                if (entry.Key == TicketProperty.City)
                {
                    sql += "city = @city";
                    getTicketsCommand.Parameters.AddWithValue("@city", (String)entry.Value);
                }
                if (entry.Key == TicketProperty.State)
                {
                    sql += "state = @state";
                    getTicketsCommand.Parameters.AddWithValue("@state", (String)entry.Value);
                }
                if (entry.Key == TicketProperty.Zip)
                {
                    sql += "zip = @zip";
                    getTicketsCommand.Parameters.AddWithValue("@zip", (String)entry.Value);
                }
                if (entry.Key == TicketProperty.Telephone)
                {
                    sql += "telephone = @telephone";
                    getTicketsCommand.Parameters.AddWithValue("@telephone", (String)entry.Value);
                }
                if (entry.Key == TicketProperty.Email)
                {
                    sql += "email = @email";
                    getTicketsCommand.Parameters.AddWithValue("@email", (String)entry.Value);
                }
                if (entry.Key == TicketProperty.PickedUp)
                {
                    sql += "picked_up = @picked_up";
                    getTicketsCommand.Parameters.AddWithValue("@picked_up", (String)entry.Value);
                }
                if (entry.Key == TicketProperty.Status)
                {
                    sql += "status = @status";
                    getTicketsCommand.Parameters.AddWithValue("@status", (String)entry.Value);
                }
                if (entry.Key == TicketProperty.TailorName)
                {
                    sql += "tailor_name = @tailor_name";
                    getTicketsCommand.Parameters.AddWithValue("@tailor_name", (String)entry.Value);
                }
                if (entry.Key == TicketProperty.OrderId)
                {
                    sql += "order_id = @order_id";
                    getTicketsCommand.Parameters.AddWithValue("@order_id", (String)entry.Value);
                }

                counter++;
                if (counter < arguments.Count)
                {
                    sql += " and ";
                }
            }

            getTicketsCommand.CommandText = sql;

            List<TicketResource> ticketResources = new List<TicketResource>();
            try
            {
                MySqlDataReader reader = getTicketsCommand.ExecuteReader();
                while (reader.Read())
                {
                    ticketResources.Add(ConvertSQLReaderRowToTicketResource(reader));
                }
                reader.Close();
                connector.CloseConnection();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("There was an error. Contact Jay with this message: " + ex.Message + " error code: " + ex.Number);
            }

            return ticketResources;
        }

        public List<TicketResource> GetDistinctEmailAddressBetweenDates(DateTime startDate, DateTime endDate)
        {
            DBConnector connector = new DBConnector();
            MySqlCommand getTicketsCommand = new MySqlCommand();
            getTicketsCommand.Connection = connector.connection;
            getTicketsCommand.CommandText = "select distinct email, first_name, last_name from Tickets where date_in >= @startDate AND date_in <= @endDate";
            getTicketsCommand.Parameters.AddWithValue("@startDate", ConvertDateTimeToUTCString(startDate));
            getTicketsCommand.Parameters.AddWithValue("@endDate", ConvertDateTimeToUTCString(endDate));

            List<TicketResource> ticketResources = new List<TicketResource>();
            try
            {
                MySqlDataReader reader = getTicketsCommand.ExecuteReader();
                while (reader.Read())
                {
                    TicketResource resource = new TicketResource();
                    resource.FirstName = Convert.ToString(reader["first_name"]);
                    resource.LastName = Convert.ToString(reader["last_name"]);
                    resource.Email = Convert.ToString(reader["email"]);
                    ticketResources.Add(resource);
                }
                reader.Close();
                connector.CloseConnection();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("There was an error. Contact Jay with this message: " + ex.Message + " error code: " + ex.Number);
            }

            return ticketResources;
        }

        public List<TicketResource> GetDistinctMailingAddressBetweenDates(DateTime startDate, DateTime endDate)
        {
            DBConnector connector = new DBConnector();
            MySqlCommand getTicketsCommand = new MySqlCommand();
            getTicketsCommand.Connection = connector.connection;
            getTicketsCommand.CommandText = "select distinct Address, first_name, last_name, city, state, zip from Tickets where date_in >= @startDate AND date_in <= @endDate";
            getTicketsCommand.Parameters.AddWithValue("@startDate", ConvertDateTimeToUTCString(startDate));
            getTicketsCommand.Parameters.AddWithValue("@endDate", ConvertDateTimeToUTCString(endDate));

            List<TicketResource> ticketResources = new List<TicketResource>();
            try
            {
                MySqlDataReader reader = getTicketsCommand.ExecuteReader();
                while (reader.Read())
                {
                    TicketResource resource = new TicketResource();
                    resource.FirstName = Convert.ToString(reader["first_name"]);
                    resource.LastName = Convert.ToString(reader["last_name"]);
                    resource.Address = Convert.ToString(reader["address"]);
                    resource.City = Convert.ToString(reader["city"]);
                    resource.State = Convert.ToString(reader["state"]);
                    resource.Zip = Convert.ToString(reader["zip"]);
                    ticketResources.Add(resource);
                }
                reader.Close();
                connector.CloseConnection();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("There was an error. Contact Jay with this message: " + ex.Message + " error code: " + ex.Number);
            }

            return ticketResources;
        }

        public List<TicketResource> GetActiveTicketsBetweenDates(DateTime startDate, DateTime endDate)
        {
            DBConnector connector = new DBConnector();
            MySqlCommand getTicketsCommand = new MySqlCommand();
            getTicketsCommand.Connection = connector.connection;
            getTicketsCommand.CommandText = "SELECT * from Tickets where date_ready >= @startDate AND date_ready <= @endDate AND status = 'a'";
            getTicketsCommand.Parameters.AddWithValue("@startDate", ConvertDateTimeToUTCString(startDate));
            getTicketsCommand.Parameters.AddWithValue("@endDate", ConvertDateTimeToUTCString(endDate));

            List<TicketResource> ticketResources = new List<TicketResource>();
            try
            {
                MySqlDataReader reader = getTicketsCommand.ExecuteReader();
                while (reader.Read())
                {
                    ticketResources.Add(ConvertSQLReaderRowToTicketResource(reader));
                }
                reader.Close();
                connector.CloseConnection();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("There was an error. Contact Jay with this message: " + ex.Message + " error code: " + ex.Number);
            }

            return ticketResources;
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
            ticketArgs.Add("completed_date", string.Format("{0:yyyy-MM-dd}", ticket.CompletedDate));

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
            DateTime? completedDate;
            //we have to convert from string because its stored in the sqllite database that way in order to accomodate null dateTimes
            String rawDate = dataRow["completed_date"] is DBNull ? "" : (String)dataRow["completed_date"];
            if (String.IsNullOrEmpty(rawDate))
            {
                completedDate = null;
            }
            else
            {
                completedDate = DateTime.Parse(rawDate);
            }

            String tailorName = dataRow["tailor_name"] is DBNull ? "" : (String)dataRow["tailor_name"];
            String orderId = dataRow["order_id"] is DBNull ? "" : (String)dataRow["order_id"];

            return TicketFactory.CreateTicket(ticketId, status, title, firstName, lastName, middleName, address, city, state, zip, telephone, email, comments, pickedUp, dateIn, dateReady, totalPrice, deposit, tailorName, orderId, completedDate);
        }

        private TicketResource ConvertSQLReaderRowToTicketResource(MySqlDataReader reader)
        {
            int ticketId = reader["ticket_id"] is DBNull ? 0 : Convert.ToInt32(reader["ticket_id"]);
            String title = reader["name_title"] is DBNull ? "" : (String)reader["name_title"] ?? "";
            String firstName = reader["first_name"] is DBNull ? "" : (String)reader["first_name"] ?? "";
            String middleName = reader["middle_name"] is DBNull ? "" : (String)reader["middle_name"] ?? "";
            String lastName = reader["last_name"] is DBNull ? "" : (String)reader["last_name"] ?? "";
            String address = reader["address"] is DBNull ? "" : (String)reader["address"] ?? "";
            String city = reader["city"] is DBNull ? "" : (String)reader["city"] ?? "";
            String state = reader["state"] is DBNull ? "" : (String)reader["state"] ?? "";
            String zip = reader["zip"] is DBNull ? "" : (String)reader["zip"] ?? "";
            String telephone = reader["telephone"] is DBNull ? "" : (String)reader["telephone"] ?? "";
            String email = reader["email"] is DBNull ? "" : (String)reader["email"] ?? "";
            String status = reader["status"] is DBNull ? "" : (String)reader["status"] ?? "";
            float totalPrice = reader["total_price"] is DBNull ? 0 : (float)reader["total_price"];
            float deposit = reader["deposit"] is DBNull ? 0 : (float)reader["deposit"];
            String comments = reader["comments"] is DBNull ? "" : (String)reader["comments"] ?? "";
            String pickedUp = reader["picked_up"] is DBNull ? "n/a" : (String)reader["picked_up"] ?? "";
            DateTime dateIn = (DateTime)reader["date_in"];
            DateTime dateReady = (DateTime)reader["date_ready"];
            DateTime lastModifiedTimestamp = (DateTime)reader["last_modified_timestamp"];
            DateTime? completedDate = reader["completed_date"] is DBNull ? null : (DateTime?)reader["completed_date"]; ;

            String tailorName = reader["tailor_name"] is DBNull ? "" : (String)reader["tailor_name"];
            String orderId = reader["order_id"] is DBNull ? "" : (String)reader["order_id"];

            return TicketFactory.CreateTicket(ticketId, status, title, firstName, lastName, middleName, address, city, state, zip, telephone, email, comments, pickedUp, dateIn, dateReady, totalPrice, deposit, tailorName, orderId, completedDate);
        }
    }
}
