using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teacher
{
    /// <summary>
    /// Represents a student's results in a given exercise
    /// </summary>
    public class ExerciseResult
    {
        public Student student;
        public int exId;
        public int errorCount;
        public int time;

        /// <summary>
        /// ExerciseResult constructor
        /// </summary>
        /// <param name="st">The Student that generated the ExerciseResult</param>
        /// <param name="exId">The ID of the exercise that was performed</param>
        /// <param name="errCt">The number of errors during the exercise's performance</param>
        /// <param name="time">The number of seconds that the exercise took to be finished</param>
        public ExerciseResult(Student st, int exId, int errCt, int time)
        {
            this.student = st;
            this.exId = exId;
            this.errorCount = errCt;
            this.time = time;
        }

        /// <summary>
        /// Generates a list of all of the ExerciseResults that a student has generated
        /// </summary>
        /// <param name="s">The student whose results will be returned</param>
        /// <returns>A List of ExerciseResults</returns>
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
