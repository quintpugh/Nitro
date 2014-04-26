using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySQL_Manager;

namespace Teacher
{
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

        public Student(String uName, String pWord, String fName, String lName, Class c)
        {
            username = uName;
            password = pWord;
            this.fName = fName;
            this.lName = lName;
            studentClass = c;
        }

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
    }
}
