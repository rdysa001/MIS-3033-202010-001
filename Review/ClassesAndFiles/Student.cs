using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesAndFiles
{
    class Student
    {
        private string name;
        
        private int id;

        private static int totalStudents;

        public Student (string name, int id)
        {
            this.name = name;
            this.id = id;

        }

        public string getName()
        {
            return name;
        }

        public void setName(string name)
        {
            this.name = name;
        }
    }
}
