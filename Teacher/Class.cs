using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teacher
{
    public class Class
    {
        public int id { get; set; }
        public String name {get; set;}
        public Teacher teacher;
        public List<Student> students;
        public List<Exercise> exercises;

        public Class(int id, String name, Teacher t)
        {
            this.id = id;
            this.name = name;
            this.teacher = t;
        }

        public static List<Class> Generate(Teacher t)
        {
            String str = "select * from class as c where c.teacherUsername='" + t.username + "'";
            MySql.Data.MySqlClient.MySqlDataReader rdr = MySQL_Manager.MySqlManager.Instance.ExecuteReader(str);

            List<Class> list = new List<Class>();

            while(rdr.Read())
            {
                int id = Convert.ToInt32(rdr["id"]);
                String name = rdr["name"].ToString();
                list.Add(new Class(id, name, t));
            }
            rdr.Close();
            return list;
        }

        public static Class Empty
        {
            get
            {
                return new Class(-1, String.Empty, null);
            }
        }
    }
}
