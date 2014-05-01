using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Student
{
    /// <summary>
    /// This is the exercise class of the student module.
    /// It will generate a list of all the exercises that the student needs to perform.
    /// It fields are the unique id for the exercise, the name of the exercise, and the exercise text
    /// </summary>
    class Exercise
    {
        public int id;
        public String name { get; set; }
        public String text { get; set; }

        /// <summary>
        /// This is the constructor for the Exercise class.
        /// It initializes the exercises object's information.
        /// </summary>
        /// <param name="id">The unique id of the exercise</param>
        /// <param name="n">The name of the exercise</param>
        /// <param name="t">The text for the exercise</param>
        public Exercise(int id, String n, String t)
        {
            this.id = id;
            name = n;
            text = t;
        }

        /// <summary>
        /// This is a static function to genereate a list of exercise objects that the student needs to perfrom.
        /// It uses the username and class id of the student in order to query the database about which exercises the
        /// student has not performed.
        /// </summary>
        /// <param name="s">The student object of the student who is currently logged in.</param>
        /// <returns>A list of exercises the student needs to perform.</returns>
        public static List<Exercise> ToBePerformed(Student s)
        {
            MySqlDataReader reader = MySQL_Manager.MySqlManager.Instance.ExecuteReader
                 (@"select e.*
                    from exercise as e,
                        (select exercises_in_class.exerciseId
                        from

                            (select ce.exerciseId
                            from class_exercises as ce
                            where ce.classId = '"+s.classId+@"') as exercises_in_class

                            where exercises_in_class.exerciseId not in 
                            (select sp.exerciseId
                            from student_performance as sp
                            where studentUsername = '"+s.username+@"')
                     ) as exercisesLeftToBePerformed
                     where e.id = exercisesLeftToBePerformed.exerciseId;");
            List<Exercise> list = new List<Exercise>();

            
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["id"]);
                String name = reader["name"].ToString();
                String text = reader["text"].ToString();

                list.Add(new Exercise(id, name, text));
            }
            reader.Close();
            return list;


        }
    }
}
