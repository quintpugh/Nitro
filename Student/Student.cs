using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Student
{
    public class Student
    {
        public String username;
        private String password;
        public String fName;
        public String lName;
        public int classId;

        public Student(String uName)
        {
            this.username = uName;
            MySqlDataReader reader = MySQL_Manager.MySqlManager.Instance.ExecuteReader
                 ("select * from student as s where s.username = '" + uName+"'");

            while (reader.Read())
            {
                password = reader["password"].ToString();
                fName = reader["fName"].ToString();
                lName = reader["lName"].ToString();
                classId = Convert.ToInt32(reader["classId"]);
            }
            reader.Close();
        }
    }
}
