using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace Dba
{
    /// <summary>
    /// Represents a Class in the system associated with the DBA interface.
    /// </summary>
    class Class
    {
        public int id;
        public String name { get; set; }
        public String teacher;

        /// <summary>
        /// The constructor for the Class class that is used to create a new Class object in the system. The information for the
        /// Class is passed directly as paramaters to this method
        /// </summary>
        /// <param name="id"></param> represents the Class' id
        /// <param name="n"></param> represents the Class' name
        /// <param name="t"></param> represents the Class' teacher's username
        public Class(int id, String n, String t)
        {
            this.id = id;
            name = n;
            teacher = t;
        }

        /// <summary>
        /// This method creates and returns a list of all of the Classes in the database
        /// </summary>
        /// <returns></returns> returns a list of all of the Classes in the database
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

        /// <summary>
        /// This method is used to remove the repsective Class from the database. However, a class cannot be removed from the system if it contains
        /// any students or teachers
        /// </summary>
        /// <returns></returns> returns 'true' if the operation was successful and 'false' otherwise
        public bool Delete()
        {
            int studentEnrollmentCount = Convert.ToInt32(MySQL_Manager.MySqlManager.Instance.ExecuteScalar ("select count(*) from student as s where s.classId = " + id));

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

        /// <summary>
        /// This method is used to add a new Class into the database. A class does not require a teacher upon creation (this can be added seperately)
        /// </summary>
        /// <returns></returns> returns 'true' if the operation was successful and 'false' otherwise
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

        /// <summary>
        /// This method is used to update the Classes information in the database. Only the Class' name and teacher
        /// may be updated. The id may not be.
        /// </summary>
        /// <param name="id"></param> the Class id that will be updated
        /// <param name="name"></param> represents the Class' new name
        /// <param name="teacher"></param> represents the Class' new teacher
        /// <returns></returns>
        public bool Update(int id, String name, String teacher)
        {
            return MySQL_Manager.MySqlManager.Instance.ExecuteNonQuery("update class set name = '" + name + "', teacherUsername = '" + teacher + "' where id = '" + id + "'"); 
        }
    }
}
