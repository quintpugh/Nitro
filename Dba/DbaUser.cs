using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Dba
{
    class DbaUser
    {
        public String username;
        private String password;
        public String fName;
        public String lName;

        public DbaUser(String uName)
        {
            MySqlDataReader reader = MySQL_Manager.MySqlManager.Instance.ExecuteReader("select *from dba as d where d.username = '" + uName + "'");

            while (reader.Read())
            {
                username = reader["username"].ToString();
                password = reader["password"].ToString();
                fName = reader["fName"].ToString();
                lName = reader["lName"].ToString();
            }
            reader.Close();
        }

        public bool Update(String p, String f, String l)
        {
            return MySQL_Manager.MySqlManager.Instance.ExecuteNonQuery("update dba set password = " + p + ", fName = " + f + ", lName = " + l + "where username = " + this.username);
        }
    }
}
