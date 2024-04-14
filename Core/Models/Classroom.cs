using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Exceptions;

namespace Core.Models
{
    public enum Type
    {
        Backend,
        Frontend
    }
    public class Classroom 
    {

        public Classroom() { }

        private static int _id;

        public int Id { get; set; }
        public int Limit { get; set; }
        public  string Name { get; set; }
        public Type ClassType { get; set; }

        public  Student[] students = new Student[0];

        public Classroom[] AllClassrooms = new Classroom[0];


        public Classroom(string name ,int limit) 
        {
            _id++;
            Id = _id;
            Name = name;
            Limit = limit;
        }

        public void AddStudent(int id, Student student)
        {
            for (int i = 0; i < AllClassrooms.Length; i++)
            {
                if (AllClassrooms[i].Id == id)
                {                    
                    Array.Resize(ref AllClassrooms[i].students, AllClassrooms[i].students.Length + 1);
                    AllClassrooms[i].students[AllClassrooms[i].students.Length - 1] = student;
                }
            }
        }

        public  void AddClassroom(Classroom classroom)
        {       
            Array.Resize(ref AllClassrooms, AllClassrooms.Length + 1);
            AllClassrooms[AllClassrooms.Length - 1] = classroom;
        }

        public void ShowAllClassrooms()
        {
            for (int i = 0; i < AllClassrooms.Length; i++)
            {                              
                Console.WriteLine($"[{AllClassrooms[i].Id}] {AllClassrooms[i].Name}");                
            }
        }

        public  void ShowAllClassroomsWithStudents()
        {
            for (int i = 0; i < AllClassrooms.Length; i++)
            {
                Console.WriteLine($"[{AllClassrooms[i].Id}] {AllClassrooms[i].Name} - classroomda olan telebeler: \n");
                

                for (int j = 0; j < AllClassrooms[i].students.Length; j++)
                {
                    Console.WriteLine($"{AllClassrooms[i].students[j].Id}    {AllClassrooms[i].students[j].Name}     {AllClassrooms[i].students[j].SurName}");
                }
            }
        }


        public void ShowAllStudentsForSpecificClass(int id)
        {
            bool check = false;
            for (int i = 0; i < AllClassrooms.Length; i++)
            {
                if (AllClassrooms[i].Id == id)
                {
                    Console.WriteLine($"\nSecilmis olan [{AllClassrooms[i].Name}] classroomundaki telebeler:");
                    check = true;
                    for (int j = 0; j < AllClassrooms[i].students.Length; j++)
                    {
                        Console.WriteLine($"\n{AllClassrooms[i].students[j].Id}    {AllClassrooms[i].students[j].Name}     {AllClassrooms[i].students[j].SurName}");
                    }
                }      
            }

            if (check == false)
            {
                throw new ClassroomNotFoundException("Bele bir classroom movcud deyil!");
            }
        }

        public Student FindId(int id)
        {
            for (int i = 0; i < students.Length; i++)
            {
                if (students[i].Id == id)
                {
                    return students[i];
                }
            }
            return null;
        }

        public  void Delete(string classroomName,int id)
        {
            bool isFound = false;

            if (id <= AllClassrooms.Length)
            {
                for (int j = 0; j < AllClassrooms.Length; j++)
                {
                    if (AllClassrooms[j].Name != classroomName)
                    {
                        isFound = true;
                        Student[] FilteredStudents = new Student[0];

                        for (int i = 0; i < AllClassrooms[j].students.Length; i++)
                        {
                            if (AllClassrooms[j].students[i].Id != id)
                            {
                                Array.Resize(ref FilteredStudents, FilteredStudents.Length + 1);
                                FilteredStudents[FilteredStudents.Length - 1] = students[i];
                            }
                        }
                        AllClassrooms[j].students = FilteredStudents;
                        Console.WriteLine("\nTelebe classroomdan silindi!");
                    }
                }

                if (isFound == false)
                {
                    throw new StudentNotFoundException("Bele bir student tapilmadi!");
                }

            }
            else
            {
                throw new ClassroomNotFoundException("Bele bir classroom tapilmadi!");
            }                    
        }
    }
}