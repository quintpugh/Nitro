using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teacher
{
    class ExerciseResult
    {
        public Student student;
        public int exId;
        public int errorCount;
        public double time;

        public ExerciseResult(Student st, int exId, int errCt, double time)
        {
            this.student = st;
            this.exId = exId;
            this.errorCount = errCt;
            this.time = time;
        }

        public static List<ExerciseResult> Generate(Student s)
        {
            String str = "select * from student_results as sr where studentUsername = '" + s.username + "'";

            MySql.Data.MySqlClient.MySqlDataReader rdr = MySQL_Manager.MySqlManager.Instance.ExecuteReader(str);
            //do stuff
            return new List<ExerciseResult>();
        }
    }
}
