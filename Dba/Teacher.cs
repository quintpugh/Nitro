using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Dba
{
    class Teacher
    {
        public String username;
        private String fName;
        private String lName;
        private String password;

        public String fullName { get { return fName + " " + lName; } }

        public Teacher(String u, String p, String f, String l)
        {
            username = u;
            password = p;
            fName = f;
            lName = l;
        }

        public static List<Teacher> Generate()
        {
            MySqlDataReader reader = MySQL_Manager.MySqlManager.Instance.ExecuteReader("select * from teacher");

            List<Teacher> list = new List<Teacher>();
            while (reader.Read())
            {
                list.Add(new Teacher(reader["username"].ToString(), reader["password"].ToString(), reader["fName"].ToString(), reader["lName"].ToString()));
            }
            reader.Close();
            return list;
        }

        public bool Delete()
        {
            return MySQL_Manager.MySqlManager.Instance.ExecuteNonQuery("delete from Teacher where username = " + username); 
        }

        public bool Add()
        {
            return MySQL_Manager.MySqlManager.Instance.ExecuteNonQuery("insert into teacher (username, password, lName, fName) values (" + username + ", " + password + ", " + fName + ", " + lName + ")");
        }

        public bool Update(String password, String f, String l)
        {
            return MySQL_Manager.MySqlManager.Instance.ExecuteNonQuery
                (@"update teacher
                    set password = " + password + ", fName = " + f + ", lName " + l + " where username = " + username);
        }
    }
}
