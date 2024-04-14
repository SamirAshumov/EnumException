using Core.Exceptions;
using Core.Models;
using System.Xml.Linq;
namespace EnumException
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int intChoice, id, limit = 0;
            string choice, classroomName, classType, studentName, studentSurname;

            Classroom nullClassroom = new Classroom();

            do
            {
                Console.WriteLine("Menu:\n1.Classroom yarat\n2.Student yarat\n3.Butun telebeleri ekranda goster" +
                    "\n4.Secilmis sinifdeki telebeleri ekrana cixart\n5.Telebe sil\n0.Proqrami bitir");
                choice = Console.ReadLine();
                                           

                switch (choice)
                {
                    case "1":

                        do
                        {
                            Console.WriteLine("\nClassroom adini daxil edin (2 boyuk herf, 3 reqem)");
                            classroomName = Console.ReadLine();
                        } while (!classroomName.CheckClassroomName());

                        do
                        {
                            Classroom classroom = new Classroom(classroomName, limit);
                                                        
                            nullClassroom.AddClassroom(classroom);

                            Console.WriteLine("\nClassroom tipini secin:\n1.Frontend\n2.Backend\n");
                            classType = Console.ReadLine();


                            if (classType == "1")
                            {
                                classroom.ClassType = Core.Models.Type.Frontend;

                                if (classroom.ClassType == Core.Models.Type.Frontend)
                                {
                                    classroom.Limit = 15;                                    
                                }
                            }

                            else if (classType == "2")
                            {
                                classroom.ClassType = Core.Models.Type.Backend;

                                if (classroom.ClassType == Core.Models.Type.Backend)
                                {
                                    classroom.Limit = 20;                                    
                                }
                            }

                        } while (classType != "1" && classType != "2");
                        break;

                    case "2":                                         

                        do
                        {
                            Console.WriteLine("\nStudent adini daxil edin: ");
                            studentName = Console.ReadLine();
                        } while (!studentName.CheckNameOrSurname());

                        do
                        {
                            Console.WriteLine("\nStudent soyadini daxil edin: ");
                            studentSurname = Console.ReadLine();
                        } while (!studentSurname.CheckNameOrSurname());

                        try
                        {
                            if (nullClassroom.AllClassrooms.Length == 0)
                            {
                                throw new ClassroomNotFoundException("Classroom movcud deyil!");
                            }
                        }
                        catch (ClassroomNotFoundException ex)
                        {
                            Console.WriteLine(ex.Message);
                            break;
                        }
                        Console.WriteLine("------------------------------------");
                        nullClassroom.ShowAllClassrooms();
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine("\nStudent hansi qrupa elave olunsun ? (no daxil edin)");
                        id = Convert.ToInt32(Console.ReadLine());

                        Student student = new Student(studentName, studentSurname);

                        nullClassroom.AddStudent(id, student);
                        break;


                    case "3":
                        Console.WriteLine("------------------------------------");
                        nullClassroom.ShowAllClassroomsWithStudents();
                        Console.WriteLine("------------------------------------");
                        break;

                    case "4":
                        Console.WriteLine("------------------------------------");
                        nullClassroom.ShowAllClassrooms();
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine("\nHansi qrupun telebelerine baxmaq isteyirsiniz ? (no daxil edin)");

                        id = Convert.ToInt32(Console.ReadLine());
                        try
                        {
                            nullClassroom.ShowAllStudentsForSpecificClass(id);
                        }
                        catch(ClassroomNotFoundException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        
                        break;

                    case "5":

                        Console.WriteLine("------------------------------------");
                        nullClassroom.ShowAllClassroomsWithStudents();
                        Console.WriteLine("------------------------------------");


                        Console.WriteLine("\nTelebe hansi qrupdan silinecek ? (classroom no daxil edin)");
                        classroomName = Console.ReadLine();

                        Console.WriteLine("\nSilinecek telebenin id-ni daxil edin : ");
                        id = Convert.ToInt32(Console.ReadLine());

                        try
                        {
                            nullClassroom.Delete(classroomName, id);
                        }

                        catch (StudentNotFoundException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch (ClassroomNotFoundException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "0":
                        break;

                    default:
                        Console.WriteLine("\nSecim yanlisdir!!!");
                        break;
                }
            } while (choice != "0");
        }
    }
}
