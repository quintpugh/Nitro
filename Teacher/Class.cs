using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teacher
{
    /// <summary>
    /// Represents a Class that the currently authenticated Teacher is the instructor of.
    /// </summary>
    public class Class
    {
        public int id { get; set; }
        public String name {get; set;}
        public Teacher teacher;
        public List<Student> students;
        public List<Exercise> exercises;

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="id">The unique ID of the class</param>
        /// <param name="name">The name of the class</param>
        /// <param name="t">The Teacher that 'owns' the class</param>
        public Class(int id, String name, Teacher t)
        {
            this.id = id;
            this.name = name;
            this.teacher = t;
        }

        /// <summary>
        /// Generate a List of Classes that a given Teacher is an instructor of
        /// </summary>
        /// <param name="t">The Teacher in question</param>
        /// <returns>A List of Classes that Teacher t is an instructor of</returns>
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

        /// <summary>
        /// Represents an empty class with an ID of '-1', no name, and no Teacher
        /// </summary>
        public static Class Empty
        {
            get
            {
                return new Class(-1, String.Empty, null);
            }
        }
    }
}
