using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Teacher
{
    /// <summary>
    /// Represents the currently authenicated Teacher
    /// </summary>
    public class Teacher
    {
        public String username;
        private String password;
        public String fName;
        public String lName;
        public List<Class> classes;
        public List<Exercise> exercises;

        /// <summary>
        /// Teacher constructor.  Sends requires to MySQL Manager for data regarding a Teacher
        /// with a given username then parses the data to the fill appropraite class fields
        /// </summary>
        /// <param name="uName">The username of the Teacher to be created</param>
        public Teacher(String uName)
        {
            String str = "select * from teacher as t where t.username = '" + uName + "'";
            MySql.Data.MySqlClient.MySqlDataReader rdr = MySQL_Manager.MySqlManager.Instance.ExecuteReader(str);
            if (rdr == null)
            {
                throw new Exception("ERROR: THE AUTHENTICATED TEACHER DOESN'T EXIST!");
            }
            rdr.Read();
            this.username = rdr["username"].ToString();
            this.password = rdr["password"].ToString();
            this.fName = rdr["fName"].ToString();
            this.lName = rdr["lName"].ToString();
            rdr.Close();
        }

        /// <summary>
        /// Updates the Teacher to set new values for the password, first name, and last name.
        /// </summary>
        /// <param name="pWord">The new password of the Teacher</param>
        /// <param name="fName">The new first name of the Teacher</param>
        /// <param name="lName">The new last name of the Teacher</param>
        /// <returns></returns>
        public bool Update(String pWord, String fName, String lName)
        {
            String str = "update teacher set password='" + pWord + "', fName='" + fName + "', lName='"
                + lName + "' where username='" + this.username + "';";
            bool ret = MySQL_Manager.MySqlManager.Instance.ExecuteNonQuery(str);
            return ret;
        }
    }
}
