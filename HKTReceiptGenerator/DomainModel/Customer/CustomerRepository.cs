using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using DomainModel.Ticket;

namespace DomainModel.Customer
{
    public class CustomerRepository
    {
        public enum CustomerProperty
        {
            CustomerId,
            FirstName,
            MiddleName,
            LastName,
            Address,
            Address2,
            City,
            State,
            Zip,
            Telephone,
            Email
        };

        public CustomerResource getCustomerById(int customerId)
        {
            DBConnector connector = new DBConnector();
            MySqlCommand getTicketCommand = new MySqlCommand();
            getTicketCommand.Connection = connector.connection;
            getTicketCommand.CommandText = "select * from Customer where id = @customer_id LIMIT 1";
            getTicketCommand.Parameters.AddWithValue("@customer_id", customerId);

            CustomerResource customerToReturn = null;
            try
            {
                MySqlDataReader reader = getTicketCommand.ExecuteReader();
                while (reader.Read())
                {
                    customerToReturn = ConvertSQLReaderRowToTicketResource(reader);
                }
                reader.Close();
                connector.CloseConnection();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("There was an error. Contact Jay with this message: " + ex.Message + " error code: " + ex.Number);
            }

            return customerToReturn;
        }

        public void InsertCustomer(CustomerResource customerResource)
        {
            DBConnector connector = new DBConnector();

            int orderIndex = 0;

            MySqlCommand insertCommand = new MySqlCommand();
            insertCommand.Connection = connector.connection;
            insertCommand.CommandText = @"INSERT into Customer (title, first_name, middle_name, last_name, address, address2, city, state, zip, phone, email) values (@title, @first_name, @middle_name, @last_name, @address, @address2, @city, @state, @zip, @phone, @email)";
            insertCommand.Parameters.AddWithValue("@title", customerResource.Title);
            insertCommand.Parameters.AddWithValue("@first_name", customerResource.FirstName);
            insertCommand.Parameters.AddWithValue("@middle_name", customerResource.MiddleName);
            insertCommand.Parameters.AddWithValue("@last_name", customerResource.LastName);
            insertCommand.Parameters.AddWithValue("@address", customerResource.Address);
            insertCommand.Parameters.AddWithValue("@address2", customerResource.Address2);
            insertCommand.Parameters.AddWithValue("@city", customerResource.City);
            insertCommand.Parameters.AddWithValue("@state", customerResource.State);
            insertCommand.Parameters.AddWithValue("@zip", customerResource.Zip);
            insertCommand.Parameters.AddWithValue("@phone", customerResource.Telephone);
            insertCommand.Parameters.AddWithValue("@email", customerResource.Email);
            orderIndex++;
            try
            {
                insertCommand.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("There was an error. Contact Jay with this message: " + ex.Message + " error code: " + ex.Number);
            }

            connector.CloseConnection();
        }

        public void UpdateCustomer(CustomerResource customerResource)
        {
            DBConnector connector = new DBConnector();
            MySqlCommand insertCommand = new MySqlCommand();
            insertCommand.Connection = connector.connection;
            insertCommand.CommandText = @"UPDATE Customer SET title = @title, first_name = @first_name, middle_name = @middle_name, last_name = @last_name, address = @address, address2 = @address2, city = @city, state = @state, zip = @zip, phone = @phone, email = @email where id = @customerId";
            insertCommand.Parameters.AddWithValue("@title", customerResource.Title);
            insertCommand.Parameters.AddWithValue("@first_name", customerResource.FirstName);
            insertCommand.Parameters.AddWithValue("@middle_name", customerResource.MiddleName);
            insertCommand.Parameters.AddWithValue("@last_name", customerResource.LastName);
            insertCommand.Parameters.AddWithValue("@address", customerResource.Address);
            insertCommand.Parameters.AddWithValue("@address2", customerResource.Address2);
            insertCommand.Parameters.AddWithValue("@city", customerResource.City);
            insertCommand.Parameters.AddWithValue("@state", customerResource.State);
            insertCommand.Parameters.AddWithValue("@zip", customerResource.Zip);
            insertCommand.Parameters.AddWithValue("@phone", customerResource.Telephone);
            insertCommand.Parameters.AddWithValue("@email", customerResource.Email);
            insertCommand.Parameters.AddWithValue("@customerId", customerResource.CustomerId);
            
            try
            {
                insertCommand.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("There was an error. Contact Jay with this message: " + ex.Message + " error code: " + ex.Number);
            }

            connector.CloseConnection();
        }

        private CustomerResource ConvertSQLReaderRowToTicketResource(MySqlDataReader reader)
        {
            CustomerResource customer = new CustomerResource();
            customer.CustomerId = reader["id"] is DBNull ? 0 : Convert.ToInt32(reader["id"]);
            customer.Title = reader["title"] is DBNull ? "" : (String)reader["title"] ?? "";
            customer.FirstName = reader["first_name"] is DBNull ? "" : (String)reader["first_name"] ?? "";
            customer.MiddleName = reader["middle_name"] is DBNull ? "" : (String)reader["middle_name"] ?? "";
            customer.LastName= reader["last_name"] is DBNull ? "" : (String)reader["last_name"] ?? "";
            customer.Address = reader["address"] is DBNull ? "" : (String)reader["address"] ?? "";
            customer.Address2 = reader["address2"] is DBNull ? "" : (String)reader["address2"] ?? "";
            customer.City = reader["city"] is DBNull ? "" : (String)reader["city"] ?? "";
            customer.State = reader["state"] is DBNull ? "" : (String)reader["state"] ?? "";
            customer.Zip = reader["zip"] is DBNull ? "" : Convert.ToString(reader["zip"] ?? "");
            customer.Telephone = reader["phone"] is DBNull ? "" : (String)reader["phone"] ?? "";
            customer.Email = reader["email"] is DBNull ? "" : (String)reader["email"] ?? "";

            return customer;
        }

        public List<CustomerResource> GetCustomersByArguments(Dictionary<CustomerProperty, object> arguments)
        {
            DBConnector connector = new DBConnector();
            MySqlCommand getTicketsCommand = new MySqlCommand();
            getTicketsCommand.Connection = connector.connection;
            String sql = "select * from Customer where ";

            int counter = 0;
            foreach (KeyValuePair<CustomerProperty, object> entry in arguments)
            {

                if (entry.Key == CustomerProperty.FirstName)
                {
                    sql += "first_name LIKE @first_name";
                    getTicketsCommand.Parameters.AddWithValue("@first_name", "%" + (String)entry.Value + "%");
                }
                if (entry.Key == CustomerProperty.MiddleName)
                {
                    sql += "middle_name LIKE @middle_name";
                    getTicketsCommand.Parameters.AddWithValue("@middle_name", "%" + (String)entry.Value + "%");
                }
                if (entry.Key == CustomerProperty.LastName)
                {
                    sql += "last_name LIKE @last_name";
                    getTicketsCommand.Parameters.AddWithValue("@last_name", "%" + (String)entry.Value + "%");
                }
                if (entry.Key == CustomerProperty.Address)
                {
                    sql += "address LIKE @address";
                    getTicketsCommand.Parameters.AddWithValue("@address", "%" + (String)entry.Value + "%");
                }
                if (entry.Key == CustomerProperty.Address2)
                {
                    sql += "address2 LIKE @address2";
                    getTicketsCommand.Parameters.AddWithValue("@address2", "%" + (String)entry.Value + "%");
                }
                if (entry.Key == CustomerProperty.City)
                {
                    sql += "city LIKE @city";
                    getTicketsCommand.Parameters.AddWithValue("@city", "%" + (String)entry.Value + "%");
                }
                if (entry.Key == CustomerProperty.State)
                {
                    sql += "state = @state";
                    getTicketsCommand.Parameters.AddWithValue("@state", (String)entry.Value);
                }
                if (entry.Key == CustomerProperty.Zip)
                {
                    sql += "zip = @zip";
                    getTicketsCommand.Parameters.AddWithValue("@zip", (String)entry.Value);
                }
                if (entry.Key == CustomerProperty.Telephone)
                {
                    sql += "phone = @phone";
                    getTicketsCommand.Parameters.AddWithValue("@phone", (String)entry.Value);
                }
                if (entry.Key == CustomerProperty.Email)
                {
                    sql += "email LIKE @email";
                    getTicketsCommand.Parameters.AddWithValue("@email", "%" + (String)entry.Value + "%");
                }

                counter++;
                if (counter < arguments.Count)
                {
                    sql += " and ";
                }
            }

            //sql += " order by ticket_id desc";

            getTicketsCommand.CommandText = sql;

            List<CustomerResource> customerResources = new List<CustomerResource>();
            try
            {
                MySqlDataReader reader = getTicketsCommand.ExecuteReader();
                while (reader.Read())
                {
                    customerResources.Add(ConvertSQLReaderRowToTicketResource(reader));
                }
                reader.Close();
                connector.CloseConnection();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("There was an error. Contact Jay with this message: " + ex.Message + " error code: " + ex.Number);
            }

            return customerResources;
        }
    }
}
