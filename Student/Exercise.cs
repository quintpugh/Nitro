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

//        public static List<Exercise> ToBePerformed(Student s)
//        {
//            MySqlDataReader returnMySqlResults = MySQL_Manager.MySqlManager.Instance.ExecuteReader
//                (@"select classExercises.id, classExercises.name, classExercises.text
//from
//
//(select e.id, e.name, e.text
//
//from exercise as e,
//
//(
//
//select *
//
//from class_exercises as ce
//
//where ce.classId = "" + s.classId + ""
//
//) as ce,
//
//where e.id = ce.exerciseId)
//
//as classExercises, student_performs as sp
//
//where classExercises.id != sp.exerciseId;");

//            List<Exercise> list;

//            /*foreach (row in returnMySqlResults)
//            {

//            }*/
//            //return list;

            
//        }
    }
}
