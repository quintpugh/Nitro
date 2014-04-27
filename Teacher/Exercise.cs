using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teacher
{
    public class Exercise
    {
        public int id { get; set; }
        public String name { get; set; }
        public String text;
        public Teacher teacher;

        public Exercise(int id, String name, String text, Teacher t)
        {
            this.id = id;
            this.name = name;
            this.text = text;
            this.teacher = t;
        }

        public static List<Exercise> Generate(Teacher t)
        {
            String str = "select * from exercise as e where e.owner='" + t.username + "'";
            MySql.Data.MySqlClient.MySqlDataReader rdr = MySQL_Manager.MySqlManager.Instance.ExecuteReader(str);
            if (rdr == null)
            {
                return null;
            }
            List<Exercise> list = new List<Exercise>();
            while (rdr.Read())
            {
                list.Add(new Exercise(Convert.ToInt32(rdr["id"]), rdr["name"].ToString(), rdr["text"].ToString(), t));
            }
            rdr.Close();
            return list;
        }

        public static List<Exercise> GenerateInClass(Class c)
        {
            String str = "select e.* from exercise as e where e.owner = '" + c.teacher.username +
                "' and e.id in (select ce.exerciseId from class_exercises as ce where ce.classId='" + c.id + "');";
            MySql.Data.MySqlClient.MySqlDataReader rdr = MySQL_Manager.MySqlManager.Instance.ExecuteReader(str);
            if (rdr == null)
            {
                return null;
            }
            List<Exercise> list = new List<Exercise>();
            while (rdr.Read())
            {
                list.Add(new Exercise(Convert.ToInt32(rdr["id"]), rdr["name"].ToString(), rdr["text"].ToString(), c.teacher));
            }
            rdr.Close();
            return list;
        }

        public static List<Exercise> GenerateNotInClass(Class c)
        {
            String str = "select e.* from exercise as e where e.owner = '" + c.teacher.username +
                "' and e.id not in (select ce.exerciseId from class_exercises as ce where ce.classId='" + c.id + "');";
            MySql.Data.MySqlClient.MySqlDataReader rdr = MySQL_Manager.MySqlManager.Instance.ExecuteReader(str);
            if (rdr == null)
            {
                return null;
            }
            List<Exercise> list = new List<Exercise>();
            while (rdr.Read())
            {
                list.Add(new Exercise(Convert.ToInt32(rdr["id"]), rdr["name"].ToString(), rdr["text"].ToString(), c.teacher));
            }
            rdr.Close();
            return list;
        }

        public bool AddToClass(Class c)
        {
            String str = "insert into class_exercises(exerciseId, classId) values ('" + this.id + "', '" + c.id + "')";
            bool ret = MySQL_Manager.MySqlManager.Instance.ExecuteNonQuery(str);
            return ret;
        }

        public bool RemoveFromClass(Class c)
        {
            String str = "delete from class_exercises where classId='" + c.id + "' and exerciseId='" + this.id + "'";
            bool ret = MySQL_Manager.MySqlManager.Instance.ExecuteNonQuery(str);
            return ret;
        }

        public static String GetName(int id)
        {
            String str = "select e.name from exercise as e where e.id='" + id + "'";
            Object ret = MySQL_Manager.MySqlManager.Instance.ExecuteScalar(str);
            return Convert.ToString(ret);
        }

        public bool Update(int id, String name, String text, Teacher t)
        {
            String str = "update exercise set name='" + name + "', text='" + text + "' where id='" + id + "'";
            bool ret = MySQL_Manager.MySqlManager.Instance.ExecuteNonQuery(str);
            return ret;
        }

        public bool Delete()
        {
            String str = "delete from exercise where id='" + this.id + "'";
            bool ret = MySQL_Manager.MySqlManager.Instance.ExecuteNonQuery(str);
            return ret;
        }
    }

}
