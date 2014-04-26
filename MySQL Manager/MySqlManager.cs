using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MySQL_Manager
{
    public sealed class MySqlManager
    {
        private String connectionString = "server=localhost;user=root;password=root;database=nitro;port=3306";
        private MySqlConnection conn;
        private static MySqlManager instance = null;

        private MySqlManager()
        {
            conn = new MySqlConnection(connectionString);
            try
            {
                conn.Open();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                //System.Windows.Forms.Application.Exit();
            }
        }

        public static MySqlManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MySqlManager();
                }
                return instance;
            }
        }

        public MySqlDataReader ExecuteReader(String query)
        {
            MySqlCommand cmd = new MySqlCommand(query, conn);

            try
            {
                MySqlDataReader rdr = cmd.ExecuteReader();
                return rdr;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public bool ExecuteNonQuery(String script)
        {
            MySqlCommand cmd = new MySqlCommand(script, conn);

            try
            {
                int i = cmd.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public Object ExecuteScalar(String query)
        {
            MySqlCommand cmd = new MySqlCommand(query, conn);

            try
            {
                Object returnVal = cmd.ExecuteScalar();
                return returnVal;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
