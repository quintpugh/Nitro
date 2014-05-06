using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Dba
{
    /// <summary>
    /// Represents a DBA in the system associated with the DBA interface.
    /// </summary>
    public class Dba
    {
        public String username;
        public String password;
        public String fName;
        public String lName;

        public String fullName { get { return fName + " " + lName; } }

        /// <summary>
        /// The constructor for the DBA class that is used to create a new DBA object in the system. The information for the
        /// DBA is passed directly as paramaters to this method
        /// </summary>
        /// <param name="u"></param> represents the DBA's username
        /// <param name="p"></param> represents the DBA's password
        /// <param name="f"></param> represents the DBA's first name
        /// <param name="l"></param> represents the DBA's last name
        public Dba(String u, String p, String f, String l)
        {
            username = u;
            password = p;
            fName = f;
            lName = l;
        }

        /// <summary>
        /// This method creates and returns a list of all of the DBAs in the database
        /// </summary>
        /// <returns></returns> returns a list of all of the DBAs in the database
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

        /// <summary>
        /// This method is used to remove the repsective DBA from the database
        /// </summary>
        /// <returns></returns> returns 'true' if the operation was successful and 'false' otherwise
        public bool Delete()
        {
            return MySQL_Manager.MySqlManager.Instance.ExecuteNonQuery("delete from dba where username = '" + username + "'");
        }

        /// <summary>
        /// This method is used to add a new DBA into the database
        /// </summary>
        /// <returns></returns> returns 'true' if the operation was successful and 'false' otherwise
        public bool Add()
        {
            return MySQL_Manager.MySqlManager.Instance.ExecuteNonQuery("insert into dba (username, password, fName, lName) values ('" + username + "', '" + password + "', '" + fName + "', '" + lName + "')"); 
        }

        /// <summary> Updating method for the DBAA class
        /// This method is used to update the DBAs information in the database. Only the DBA's password, first name, and last name
        /// may be updated. The username cannot be.
        /// </summary>
        /// <param name="password"></param> represents the DBA's new password
        /// <param name="f"></param> represents the DBA's new first name
        /// <param name="l"></param> represents the DBA's new last name
        /// <returns></returns> returns 'true' if the operation was successful and 'false' otherwise
        public bool Update(String password, String f, String l)
        {
            return MySQL_Manager.MySqlManager.Instance.ExecuteNonQuery("update dba set password = '" + password + "', fName = '" + f + "', lName = '" + l + "' where username = '" + username + "'"); 
        }
    }
}
