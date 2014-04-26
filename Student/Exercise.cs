using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Student
{
    class Exercise
    {
        private int id;
        public String name { get; set; }
        public String text { get; set; }

        public Exercise(int id, String n, String t)
        {
            this.id = id;
            name = n;
            text = t;
        }

        public static List<Exercise> ToBePerformed(Student s)
        {
            // USE THIS ONE!!!!
//            select e.*
//from exercise as e,
//    (select ceRefined.exerciseId
//    from
//        (select *
//        from class_exercises as ce
//        where ce.classId = '1') as ceRefined,
//        (select *
//        from student_performance
//        where studentUsername = 'rhowatt') as refinedStuPerf
//    where ceRefined.exerciseId != refinedStuPerf.exerciseId) as exercisesLeft
//where e.id = exercisesLeft.exerciseId;
            MySqlDataReader reader = MySQL_Manager.MySqlManager.Instance.ExecuteReader
                 (@"select classExercises.id, classExercises.name, classExercises.text
                    from
                        (select e.id, e.name, e.text
                        from exercise as e,
                        (
                            select *
                            from class_exercises as ce
                            where ce.classId = " + s.classId + @"
                        ) as ce
                        where e.id = ce.exerciseId)
                        as classExercises, student_performance as sp
                    where classExercises.id != sp.exerciseId;");
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
