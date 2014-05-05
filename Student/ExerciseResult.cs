using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Student
{
    /// <summary>
    /// The exercise result class creates an object with all the information about
    /// the exercise the student just completed, and adds that information to the database.
    /// </summary>
    class ExerciseResult
    {
        private Student student;
        private int exId;
        private int errorCount;
        private int time;

        /// <summary>
        /// This is the constructor for the class.  It initializes
        /// the variables to the student's exercise result information.
        /// </summary>
        /// <param name="s">The student who completed the exercise</param>
        /// <param name="exId">The id of the exercise completed</param>
        /// <param name="errCount">The number of errors produced by the student</param>
        /// <param name="time">The time taken to complete the exercise</param>
        public ExerciseResult(Student s, int exId, int errCount, int time)
        {
            this.student = s;
            this.exId = exId;
            this.errorCount = errCount;
            this.time = time;
        }

        /// <summary>
        /// Attempts to add the exercise result to the database.
        /// </summary>
        /// <returns>True if the exercise result was successfully added to the database, false otherwise</returns>
        public bool Add()
        {
            return MySQL_Manager.MySqlManager.Instance.ExecuteNonQuery 
                ("insert into student_performance (studentUsername, exerciseId, errorCount, time) values ('" + student.username + "', '" + exId + "', '" + errorCount + "', '" + time + "')");
        }
    }
}
