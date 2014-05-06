using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Dba
{
    /// <summary>
    /// Represents the currently authenticated Database administrator
    /// </summary>
    public class DbaUser
    {
        public String username;
        public String password;
        public String fName;
        public String lName;

        /// <summary>
        /// The constructor for the DBA user which requests database information using the uName (username) paramter.
        /// This database information is then placed into the repsective fields.
        /// </summary>
        /// <param name="uName"></param> The username that is passed from the Login Module, used to find the DBA information in the database.
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

        /// <summary>
        /// This method updates the associated DBA user's information in the databse. The information that needs updating consists
        /// of the password, the first name, and the last name. The username cannot be updated, but is used to locate the respective DBA in the database.
        /// </summary>
        /// <param name="p"></param> the password of the DBA user which is being updated
        /// <param name="f"></param> the first name of the DBA user which is being updated
        /// <param name="l"></param> the last name of the DBA user which is being updated
        /// <returns></returns> returns 'true' if the database operation is successful and false otherwise
        public bool Update(String p, String f, String l)
        {
            return MySQL_Manager.MySqlManager.Instance.ExecuteNonQuery("update dba set password = " + p + ", fName = " + f + ", lName = " + l + "where username = " + this.username);
        }
    }
}
