using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Exceptions;

namespace Core.Models
{
    public class Student 
    {
        private static int _id;

        public int Id { get; set; }

        public string Name { get; set; }

        public string SurName { get; set; }


        public Student(string studentName, string studentSurname)
        {
            _id++;
            Id = _id;
            Name = studentName;
            SurName = studentSurname;
        }
    }
}
