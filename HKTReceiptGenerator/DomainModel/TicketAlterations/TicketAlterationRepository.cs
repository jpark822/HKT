using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace DomainModel.TicketAlterations
{
    //TODO use mapping library (probably NHibernate) to pipe in values from the database.
    public class TicketAlterationRepository : BaseRepository
    {
        public void InsertAlterations(TicketAlterationResource alterationResource)
        {
            DBConnector connector = new DBConnector();

            int orderIndex = 0;
            foreach (TicketAlterationResourceItem alteration in alterationResource.Alterations)
            {
                MySqlCommand insertCommand = new MySqlCommand();
                insertCommand.Connection = connector.connection;
                insertCommand.CommandText = @"INSERT into Ticket_Alterations (ticket_alteration_id, ticket_id, quantity, description, price, taxable, order_index) values (@ticket_alteration_id, @ticket_id, @quantity, @description, @price, @taxable, @order_index)";
                insertCommand.Parameters.AddWithValue("@ticket_alteration_id", alteration.TicketAlterationID);
                insertCommand.Parameters.AddWithValue("@ticket_id", alteration.TicketId);
                insertCommand.Parameters.AddWithValue("@quantity", alteration.Quantity);
                insertCommand.Parameters.AddWithValue("@description", alteration.Description);
                insertCommand.Parameters.AddWithValue("@price", alteration.Price);
                insertCommand.Parameters.AddWithValue("@taxable", alteration.Taxable);
                insertCommand.Parameters.AddWithValue("@order_index", orderIndex);
                orderIndex++;
                try
                {
                    insertCommand.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("There was an error. Contact Jay with this message: " + ex.Message + " error code: " + ex.Number);
                }
            }
            connector.CloseConnection();
        }

        public void DeleteAndReinsertAlterations(TicketAlterationResource alterationResource, int ticketId)
        {
            DBConnector deleteConnector = new DBConnector();
            MySqlCommand deleteCommand = new MySqlCommand();
            deleteCommand.Connection = deleteConnector.connection;
            deleteCommand.CommandText = @"DELETE from Ticket_Alterations WHERE ticket_id = @ticket_id";
            deleteCommand.Parameters.AddWithValue("@ticket_id", ticketId);
            try
            {
                deleteCommand.ExecuteNonQuery();
                deleteConnector.CloseConnection();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("There was an error deleting alterations. Contact Jay with this message: " + ex.Message + " error code: " + ex.Number);
            }

            InsertAlterations(alterationResource);
        }

        public TicketAlterationResource GetAlterationsByTicketId(int ticketId)
        {
            DBConnector connector = new DBConnector();
            MySqlCommand getAlterationsCommand = new MySqlCommand();
            getAlterationsCommand.Connection = connector.connection;
            getAlterationsCommand.CommandText = @"SELECT * from Ticket_Alterations where ticket_id = @ticket_id ORDER BY order_index";
            getAlterationsCommand.Parameters.AddWithValue("@ticket_id", ticketId);

            List<TicketAlterationResourceItem> alterationItems = new List<TicketAlterationResourceItem>();
            try
            {
                MySqlDataReader reader = getAlterationsCommand.ExecuteReader();
                while (reader.Read())
                {
                    alterationItems.Add(new TicketAlterationResourceItem
                    {
                        Price = Convert.ToDouble(reader["price"]),
                        Quantity = Convert.ToInt32(reader["quantity"]),
                        Description = (String)reader["description"],
                        Taxable = Convert.ToInt32(reader["taxable"])
                    });
                }
                reader.Close();
                connector.CloseConnection();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("There was an error. Contact Jay with this message: " + ex.Message + " error code: " + ex.Number);
            }

            TicketAlterationResource alterationRes = TicketAlterationFactory.CreateTicketAlterationResource(alterationItems);
            return alterationRes;
        }

        public void DeleteAlterationsByTicketID(int ticketId)
        {
            DBConnector connector = new DBConnector();
            MySqlCommand deleteCommand = new MySqlCommand();
            deleteCommand.Connection = connector.connection;
            deleteCommand.CommandText = @"DELETE from Ticket_Alterations where ticket_id = @ticket_id";
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
    }
}
