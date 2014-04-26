using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    public class Student
    {
        public String username;
        private String password;
        public String fName;
        public String lName;
        public int classId;

        public Student(String uName)
        {
            this.username = uName;

        }
    }
}
