using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teacher
{
    /// <summary>
    /// Represents an Exercise that a Teacher may create and a Student may perform.
    /// </summary>
    public class Exercise
    {
        public int id { get; set; }
        public String name { get; set; }
        public String text;
        public Teacher teacher;

        /// <summary>
        /// Exercise constructor with an ID field
        /// </summary>
        /// <param name="id">The unique ID if the Exercise to be created</param>
        /// <param name="name">The name of the exercise that the teacher and students will see</param>
        /// <param name="text">The text to be typed when performing the exercise</param>
        /// <param name="t">The Teacher that created and owns the exercise</param>
        public Exercise(int id, String name, String text, Teacher t)
        {
            this.id = id;
            this.name = name;
            this.text = text;
            this.teacher = t;
        }

        /// <summary>
        /// Exercise constructor without an ID field.  id is set to the sentinel value of '-1'
        /// </summary>
        /// <param name="name">The name of the exercise that the teacher and students will see</param>
        /// <param name="text">The text to be typed when performing the exercise</param>
        /// <param name="t">The Teacher that created and owns the exercise</param>
        public Exercise(String name, String text, Teacher t)
        {
            this.id = -1;
            this.name = name;
            this.text = text;
            this.teacher = t;
        }

        /// <summary>
        /// Generate and return a list of Exercises that have been created by a given Teacher
        /// </summary>
        /// <param name="t">The Teacher whose Exercises will be returned</param>
        /// <returns>A List of Exercises that were created by the Teacher t</returns>
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

        /// <summary>
        /// Generate and return a list of Exercises that are assigned to a given Class
        /// </summary>
        /// <param name="c">The Class whose assigned Exercises will be returned</param>
        /// <returns>A List of Exercises that are assigned to Class c</returns>
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

        /// <summary>
        /// Generate and return a list of Exercises that were created by the instructor a given class but are not assigned to said class
        /// </summary>
        /// <param name="c">The Class whose instructor's Exercises are to be considered</param>
        /// <returns>A List of Exercises created by Class c's instructor but not assigned to c</returns>
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

        /// <summary>
        /// Assigns the Exercise to a given Class
        /// </summary>
        /// <param name="c">The Class that the Exercise will be added to</param>
        /// <returns>True of the change was successful, false otherwise</returns>
        public bool AddToClass(Class c)
        {
            String str = "insert into class_exercises(exerciseId, classId) values ('" + this.id + "', '" + c.id + "')";
            bool ret = MySQL_Manager.MySqlManager.Instance.ExecuteNonQuery(str);
            return ret;
        }

        /// <summary>
        /// Removes the Exercise from a given Class
        /// </summary>
        /// <param name="c">The Class that the Exercise will be removed from</param>
        /// <returns>True of the change was successful, false otherwise</returns>
        public bool RemoveFromClass(Class c)
        {
            String str = "delete from class_exercises where classId='" + c.id + "' and exerciseId='" + this.id + "'";
            bool ret = MySQL_Manager.MySqlManager.Instance.ExecuteNonQuery(str);
            return ret;
        }

        /// <summary>
        /// Gets the name of the Exercise based on an ID
        /// </summary>
        /// <param name="id">The ID of the Exercise in question</param>
        /// <returns>The name of the Exercise if ID is valid, an empty string otherwise</returns>
        public static String GetName(int id)
        {
            String str = "select e.name from exercise as e where e.id='" + id + "'";
            Object ret = MySQL_Manager.MySqlManager.Instance.ExecuteScalar(str);
            return Convert.ToString(ret);
        }

        /// <summary>
        /// Adds the Exercise to the system's database
        /// </summary>
        /// <returns>True of the change was successful, false otherwise</returns>
        public bool Add()
        {
            String str = "insert into exercise(name, text, owner) values ('" + this.name + "', '" + this.text + "', '" + teacher.username + "')";
            bool ret = MySQL_Manager.MySqlManager.Instance.ExecuteNonQuery(str);
            return ret;
        }

        /// <summary>
        /// Updates the Exercises name and/or text.
        /// </summary>
        /// <param name="name">The new name of the Exercise</param>
        /// <param name="text">The new text of the Exercise</param>
        /// <returns>True of the change was successful, false otherwise</returns>
        public bool Update( String name, String text)
        {
            String str = "update exercise set name='" + name + "', text='" + text + "' where id='" + this.id + "'";
            bool ret = MySQL_Manager.MySqlManager.Instance.ExecuteNonQuery(str);
            return ret;
        }

        /// <summary>
        /// Deletes the Exercise from the system's database
        /// </summary>
        /// <returns>True of the change was successful, false otherwise</returns>
        public bool Delete()
        {
            String str = "delete from exercise where id='" + this.id + "'";
            bool ret = MySQL_Manager.MySqlManager.Instance.ExecuteNonQuery(str);
            return ret;
        }
    }

}
