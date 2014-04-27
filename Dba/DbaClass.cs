using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace Dba
{
    class DbaClass
    {
        private int id;
        public String name { get; set; }
        public String teacher;

        public DbaClass(int id, String n, String t)
        {
            this.id = id;
            name = n;
            teacher = t;
        }

        public static List<DbaClass> Generate()
        {
            MySqlDataReader reader = MySQL_Manager.MySqlManager.Instance.ExecuteReader("select * from class");

            List<DbaClass> list = new List<DbaClass>();

            while(reader.Read())
            {
                list.Add(new DbaClass(Convert.ToInt32(reader["id"]), reader["name"].ToString(), reader["teacherUsername"].ToString()));
            }
            reader.Close();
            return list;
        }

        public bool Delete()
        {
            int studentEnrollmentCount = Convert.ToInt32(MySQL_Manager.MySqlManager.Instance.ExecuteScalar ("select count(*) from student as s where s.classId = " + id));

            if (studentEnrollmentCount == 0 && teacher == "")
            {
                MySQL_Manager.MySqlManager.Instance.ExecuteNonQuery("delete from class where classId = " + id);
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
               return MySQL_Manager.MySqlManager.Instance.ExecuteNonQuery("insert into class (name, teacherUsername) values (" + name + ", " + teacher + ")");
            }
            else
            {
               return MySQL_Manager.MySqlManager.Instance.ExecuteNonQuery("insert into class (name) values (" + name + ")");
            }
        }

        public bool Update(int id, String name, String teacher)
        {
            return MySQL_Manager.MySqlManager.Instance.ExecuteNonQuery("update class set name = " + name + ", teacherUsername = " + teacher + " where id = " + id); 
        }
    }
}
