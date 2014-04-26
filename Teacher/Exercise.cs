using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teacher
{
    public class Exercise
    {

        public static String GetName(int id)
        {
            String str = "select e.name from exercise as e where e.id='" + id + "'";
            Object ret = MySQL_Manager.MySqlManager.Instance.ExecuteScalar(str);
            return Convert.ToString(ret);
        }
    }

}
