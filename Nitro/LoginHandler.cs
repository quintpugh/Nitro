using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    /// <summary>Class that contains the LoginHandler, which grants authentication to the user
    /// This class contains the methods that facilitate the login authentication process. These methods determine if the user 
    /// information entered is valid within the database.
    /// </summary>
    class LoginHandler
    {
        public LoginHandler(){}

        /// <summary>This method determines if the user information is valid in the database
        /// This method determines if the user information entered is valid within the database.
        /// It uses a MySQL query to count the number of users in the respective table that match the given user information.
        /// If the value is 1, it returns true and grants authentication. Otherwise it returns false and authentication is denied.
        /// </summary>
        /// <param name="uName"></param>Username paramater of the respective userType
        /// <param name="pWord"></param>Password paramater of the respective userType
        /// <param name="userType"></param>Selected userType in the Login Interface (Student, Teacher, Database Administrator)
        /// <returns></returns>Returns true if the user is valid and false otherwise
        public bool IsValidUser(String uName, String pWord, String userType)
        {
            String table;
            switch (userType)
            {
                case ("Student"):
                    table = "student";
                    break;
                case ("Teacher"):
                    table = "teacher";
                    break;
                case ("Database Administrator"):
                    table = "dba";
                    break;
                default:
                    throw new Exception("How did you get a user that doesn't exist?");
            }

            //Query returns the number of users in the database with the respective information. If the query returns 1
            //the user will be granted authentication, otherwise they will not.
            string str = "select count(*) from " + table + " where username='" + uName + "' and password='" + pWord + "'";
            
            int count = Convert.ToInt32(MySQL_Manager.MySqlManager.Instance.ExecuteScalar(str));

            return (count == 1);
        }
    }
}
