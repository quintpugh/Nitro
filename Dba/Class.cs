using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace Dba
{
    class Class
    {
        public int id;
        public String name { get; set; }
        public String teacher;

        public Class(int id, String n, String t)
        {
            this.id = id;
            name = n;
            teacher = t;
        }

        public static List<Class> Generate()
        {
            MySqlDataReader reader = MySQL_Manager.MySqlManager.Instance.ExecuteReader("select * from class");

            List<Class> list = new List<Class>();

            while(reader.Read())
            {
                list.Add(new Class(Convert.ToInt32(reader["id"]), reader["name"].ToString(), reader["teacherUsername"].ToString()));
            }
            reader.Close();
            return list;
        }

        public bool Delete()
        {
            int studentEnrollmentCount = Convert.ToInt32(MySQL_Manager.MySqlManager.Instance.ExecuteScalar ("select count(*) from student as s where s.id = " + id));

            if (studentEnrollmentCount == 0 && teacher == "")
            {
                MySQL_Manager.MySqlManager.Instance.ExecuteNonQuery("delete from class where id = " + id);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Add()
        {
            if (teacher != "")
            {
               return MySQL_Manager.MySqlManager.Instance.ExecuteNonQuery("insert into class (name, teacherUsername) values ('" + name + "', '" + teacher + "')");
            }
            else
            {
               return MySQL_Manager.MySqlManager.Instance.ExecuteNonQuery("insert into class (name) values ('" + name + "')");
            }
        }

        public bool Update(int id, String name, String teacher)
        {
            return MySQL_Manager.MySqlManager.Instance.ExecuteNonQuery("update class set name = '" + name + "', teacherUsername = '" + teacher + "' where id = '" + id + "'"); 
        }
    }
}
