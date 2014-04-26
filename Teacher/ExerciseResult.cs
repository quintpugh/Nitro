using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teacher
{
    public class ExerciseResult
    {
        public Student student;
        public int exId;
        public int errorCount;
        public int time;

        public ExerciseResult(Student st, int exId, int errCt, int time)
        {
            this.student = st;
            this.exId = exId;
            this.errorCount = errCt;
            this.time = time;
        }

        public static List<ExerciseResult> Generate(Student s)
        {
            String str = "select * from student_performance as sr where studentUsername = '" + s.username + "'";

            MySql.Data.MySqlClient.MySqlDataReader rdr = MySQL_Manager.MySqlManager.Instance.ExecuteReader(str);
            if (rdr == null)
            {
                throw new Exception("ERROR: COULDN'T GET THE EXERCISE RESULTS!");
            }

            List<ExerciseResult> list = new List<ExerciseResult>();
            while (rdr.Read())
            {
                list.Add(new ExerciseResult(s, Convert.ToInt32(rdr["exerciseId"]), Convert.ToInt32(rdr["errorCount"]), Convert.ToInt32(rdr["time"])));
            }
            rdr.Close();
            return list;
        }
    }
}
