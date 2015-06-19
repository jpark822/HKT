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

    public class ConfigurationRepository : BaseRepository
    {

        public IEnumerable<ConfigrationSetting> GetConfigrationSettings()
        {
            DBConnector connector = new DBConnector();
            MySqlCommand getTicketsCommand = new MySqlCommand();
            getTicketsCommand.Connection = connector.connection;
            getTicketsCommand.CommandText = "SELECT * FROM  configuration";
            List<ConfigrationSetting> list = new List<ConfigrationSetting>();
            try
            {
                MySqlDataReader reader = getTicketsCommand.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(ConvertSQLReaderRowToConfigrationSetting(reader));
                }
                reader.Close();
                connector.CloseConnection();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("There was an error. Contact Jay with this message: " + ex.Message + " error code: " + ex.Number);
            }

            return list;
        }

        public void UpdateSetting(ConfigrationSetting setting)
        {
            DBConnector connector = new DBConnector();
            MySqlCommand updateCommand = new MySqlCommand();
            updateCommand.Connection = connector.connection;
            updateCommand.CommandText = "UPDATE configuration SET value = @value WHERE setting = @setting";
            updateCommand.Parameters.AddWithValue("@setting", setting.Setting);
            updateCommand.Parameters.AddWithValue("@value", setting.Value);



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


        private ConfigrationSetting ConvertSQLReaderRowToConfigrationSetting(MySqlDataReader reader)
        {
            var setting = reader["setting"] is DBNull ? "" : (String)reader["setting"];
            var value = reader["value"] is DBNull ? "" : (String)reader["value"];

            return new ConfigrationSetting { Setting = setting, Value = value };
        }
    }
}
