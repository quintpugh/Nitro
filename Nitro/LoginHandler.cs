using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    class LoginHandler
    {
        public LoginHandler(){}

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

            string str = "select count(*) from " + table + " where username='" + uName + "' and password='" + pWord + "'";
            
            int count = Convert.ToInt32(MySQL_Manager.MySqlManager.Instance.ExecuteScalar(str));

            return (count == 1);
        }
    }
}
