using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Dba
{
    public class Dba
    {
        public String username;
        private String password;
        private String fName;
        private String lName;

        public String fullName { get { return fName + " " + lName; } }

        public Dba(String u, String p, String f, String l)
        {
            username = u;
            password = p;
            fName = f;
            lName = l;
        }

        public static List<Dba> Generate()
        {
            MySqlDataReader reader = MySQL_Manager.MySqlManager.Instance.ExecuteReader("select * from dba");

            List<Dba> list = new List<Dba>();

            while(reader.Read())
            {
                list.Add(new Dba(reader["username"].ToString(), reader["password"].ToString(), reader["fName"].ToString(), reader["lName"].ToString()));
            }
            reader.Close();
            return list;
        }

        public bool Delete()
        {
            return MySQL_Manager.MySqlManager.Instance.ExecuteNonQuery("delete from dba where username = " + username);
        }

        public bool Add()
        {
            return MySQL_Manager.MySqlManager.Instance.ExecuteNonQuery ("insert into dba (username, password, lName, fName) values (" + username + ", " + password + ", " + fName + ", " + lName + ")") 
        }

        public bool Update(String password, String f, String l)
        {
            return MySQL_Manager.MySqlManager.Instance.ExecuteNonQuery("update dba set password = " + password + ", fName = " + f + ", lName " + l + " where id = " + username); 
        }
    }
}
