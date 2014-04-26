using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teacher
{
    public class Student
    {
        public String username;
        private String password;
        public String fName;
        public String lName;
        public Class studentClass;

        public Student(String uName, String pWord, String fName, String lName, Class c)
        {
            username = uName;
            password = pWord;
            this.fName = fName;
            this.lName = lName;
            studentClass = c;
        }
    }
}
