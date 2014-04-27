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
        public int id;
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
