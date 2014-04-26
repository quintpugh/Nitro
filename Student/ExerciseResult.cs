using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    class ExerciseResult
    {
        private Student student;
        private int exId;
        private int errorCount;
        private int time;

        public ExerciseResult(Student s, int exId, int errCount, int time)
        {
            this.student = s;
            this.exId = exId;
            this.errorCount = errCount;
            this.time = time;
        }

        public bool Add()
        {
            return false;
        }
    }
}
