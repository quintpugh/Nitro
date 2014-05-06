using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Dba
{
    /// <summary>
    /// Represents a teacher in the system associated with the DBA interface.
    /// </summary>
    class Teacher
    {
        public String username {get; set;}
        public String fName {get; set;}
        public String lName { get; set; }
        public String password;
        public static Teacher Empty { get { return new Teacher("", "", "", ""); } }
        public String fullName { get { return fName + " " + lName; } }

        /// <summary>
        /// The constructor for the teacher class that is used to create a new teacher object in the system. The information for the
        /// teacher is passed directly as paramaters to this method
        /// </summary>
        /// <param name="u"></param> represents the teacher's username
        /// <param name="p"></param> represents the teacher's password
        /// <param name="f"></param> represents the teacher's first name
        /// <param name="l"></param> represents the teacher's last name
        public Teacher(String u, String p, String f, String l)
        {
            username = u;
            password = p;
            fName = f;
            lName = l;
        }

        /// <summary>
        /// This method creates and returns a list of all of the teachers in the database
        /// </summary>
        /// <returns></returns> returns a list of all of the teachers in the database
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

        /// <summary>
        /// This method is used to remove the repsective teacher from the database
        /// </summary>
        /// <returns></returns> returns 'true' if the operation was successful and 'false' otherwise
        public bool Delete()
        {
            return MySQL_Manager.MySqlManager.Instance.ExecuteNonQuery("delete from Teacher where username = '" + username + "'"); 
        }

        /// <summary>
        /// This method is used to add a new teacher into the database
        /// </summary>
        /// <returns></returns> returns 'true' if the operation was successful and 'false' otherwise
        public bool Add()
        {
            return MySQL_Manager.MySqlManager.Instance.ExecuteNonQuery("insert into teacher (username, password, lName, fName) values ('" + username + "', '" + password + "', '" + fName + "', '" + lName + "')");
        }

        /// <summary>
        /// This method is used to update the teachers information in the database. Only the teacher's password, first name, and last name
        /// may be updated. The username cannot be.
        /// </summary>
        /// <param name="password"></param> represents the teacher's new password
        /// <param name="f"></param> represents the teacher's new first name
        /// <param name="l"></param> represents the teacher's new last name
        /// <returns></returns> returns 'true' if the operation was successful and 'false' otherwise
        public bool Update(String password, String f, String l)
        {
            return MySQL_Manager.MySqlManager.Instance.ExecuteNonQuery
                (@"update teacher
                    set password = '" + password + "', fName = '" + f + "', lName = '" + l + "' where username = '" + username + "'");
        }
    }
}
