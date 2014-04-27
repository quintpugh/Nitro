using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySQL_Manager;

namespace Teacher
{
    /// <summary>
    /// Represents a Student in the system
    /// </summary>
    public class Student
    {
        public String username { get; set; }
        private String password;
        public String fName;
        public String lName;
        public Class studentClass;
        public List<ExerciseResult> results;
        public String FullName
        {
            get
            {
                return fName + " " + lName;
            }
        }

        /// <summary>
        /// Student constructor
        /// </summary>
        /// <param name="uName">Username of the Student</param>
        /// <param name="pWord">Password of the Student</param>
        /// <param name="fName">First Name of the Student</param>
        /// <param name="lName">Last Name of the Student</param>
        /// <param name="c">The Class that the student is enrolled in (null if not enrolled)</param>
        public Student(String uName, String pWord, String fName, String lName, Class c)
        {
            username = uName;
            password = pWord;
            this.fName = fName;
            this.lName = lName;
            studentClass = c;
        }

        /// <summary>
        /// Generate a List of Students enrolled in a given Class
        /// </summary>
        /// <param name="c">The Class whose enrolled students will be generated</param>
        /// <returns>A List of Students that are enrolled in Class c</returns>
        public static List<Student> GenerateIn(Class c)
        {
            String str = "select * from student as s where s.classId='" + c.id + "'";
            MySqlDataReader rdr = MySqlManager.Instance.ExecuteReader(str);
            if (rdr == null)
            {
                throw new Exception("ERROR: FAILED TO GET STUDENT DATA");
            }

            List<Student> list = new List<Student>();
            while (rdr.Read())
            {
                list.Add(new Student(rdr["username"].ToString(), rdr["password"].ToString(), rdr["fName"].ToString(), rdr["lName"].ToString(), c));
            }
            rdr.Close();
            return list;
        }

        /// <summary>
        /// Generate a List of Students enrolled in a given List of Classes.  This function loops through each
        /// Class in a given list, calling Student.GenerateIn(Class c) for each and adds the returns of each call to a list
        /// </summary>
        /// <param name="c">The List of Classes whose enrolled students will be generated</param>
        /// <returns>A List of Students that are enrolled in each of the Classes provided</returns>
        public static List<Student> GenerateIn(List<Class> classList)
        {
            List<Student> list = new List<Student>();
            foreach(Class cls in classList)
            {
                list.AddRange(Student.GenerateIn(cls));
            }

            return list;
        }

        /// <summary>
        /// Genreate a List of Students that aren't enrolled in a Class
        /// </summary>
        /// <returns>A List of Students that aren't enrolled in a Class</returns>
        public static List<Student> GenerateNotEnrolled()
        {
            String str = "select * from student as s where s.classId is null";
            MySqlDataReader rdr = MySQL_Manager.MySqlManager.Instance.ExecuteReader(str);
            if (rdr == null)
            {
                throw new Exception("ERROR: FAILED TO GET STUDENT DATA");
            }

            List<Student> list = new List<Student>();
            while(rdr.Read())
            {
                list.Add(new Student(rdr["username"].ToString(), rdr["password"].ToString(), rdr["fName"].ToString(), rdr["lName"].ToString(), null));
            }
            rdr.Close();
            return list;
        }


        /// <summary>
        /// Enrolls the Student in a given Class  Note that this function withdraws the
        /// Student from a Class if he is currently enrolled in one.
        /// </summary>
        /// <param name="c">The Class that the Student will be enrolled in.</param>
        /// <returns>True of the change was successfull, false otherwise</returns>
        public bool AddToClass(Class c)
        {
            String str = "update student set classId='" + c.id + "' where username='" + this.username + "'";
            bool ret = MySQL_Manager.MySqlManager.Instance.ExecuteNonQuery(str);
            return ret;
        }

        /// <summary>
        /// Withdraws the Student from a Class if he is currently enrolled in one
        /// </summary>
        /// <returns>True of the change was successfull, false otherwise</returns>
        public bool RemoveFromClass()
        {
            String str = "update student set classId=null where username='" + this.username + "'";
            bool ret = MySQL_Manager.MySqlManager.Instance.ExecuteNonQuery(str);
            return ret;
        }

        /// <summary>
        /// Adds the Student to the system's database.
        /// </summary>
        /// <returns>True of the change was successfull, false otherwise</returns>
        public bool Add()
        {
            String str;
            if (this.studentClass != null)
            {
                str = "insert into student (username, password, fName, lName, classId) values ('" + this.username + "', '" + this.password + "', '" + this.fName + "', '" + this.lName + "', '" + this.studentClass.id + "')";
            }
            else
            {
                str = "insert into student (username, password, fName, lName) values ('" + this.username + "', '" + this.password + "', '" + this.fName + "', '" + this.lName + "')";
            }
            bool ret = MySQL_Manager.MySqlManager.Instance.ExecuteNonQuery(str);
            return ret;
        }

        /// <summary>
        /// Updates the Student's password, first name, last name, and class enrolled in
        /// </summary>
        /// <param name="pWord">The Student's new password</param>
        /// <param name="fName">The Student's new first name</param>
        /// <param name="lName">The Student's new last name</param>
        /// <param name="c">The Student's new Class</param>
        /// <returns>True of the change was successful, false otherwise</returns>
        public bool Update(String pWord, String fName, String lName, Class c)
        {
            String str;
            if (c != null)
            {
                str = "update student set password='" + pWord + "', fName='" + fName + "', lName='" + lName + "', classId='" + c.id + "' where username='" + this.username + "'";
            }
            else
            {
                str = "update student set password='" + pWord + "', fName='" + fName + "', lName='" + lName + "', classId=null where username='" + this.username + "'";
            }
            bool ret = MySQL_Manager.MySqlManager.Instance.ExecuteNonQuery(str);
            return ret;
        }

        /// <summary>
        /// Deletes the Student from the system's database.  Note that this also removes all of the ExerciseResults of the student.
        /// </summary>
        /// <returns>True if the change was successful, false otherwise</returns>
        public bool Delete()
        {
            String str = "delete from student where username='" + this.username + "'";
            bool ret = MySQL_Manager.MySqlManager.Instance.ExecuteNonQuery(str);
            return ret;
        }
    }
}
