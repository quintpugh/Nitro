using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Student
{
    /// <summary>
    /// This class creates the student user object after they log into the system.
    /// The class queries the database for the student's class, name, and password
    /// </summary>
    public class Student
    {
        public String username;
        private String password;
        public String fName;
        public String lName;
        public int classId;

        /// <summary>
        /// This is the constructor for the student class.
        /// It contains all the functionality of the class.
        /// It is passed the username of the student from the login module, and
        /// uses it to query the student's information.
        /// </summary>
        /// <param name="uName">The username of the student sent by the login module</param>
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
