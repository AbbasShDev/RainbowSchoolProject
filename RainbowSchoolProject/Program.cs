using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RainbowSchoolProject
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Rainbow School Teacher System");

            Console.WriteLine("Select option:");
            Console.WriteLine("Press 1 to display all teachers.");
            Console.WriteLine("Press 2 to add new teacher.");
            Console.WriteLine("Press 3 to update a teacher data.");
            Console.WriteLine("Press x to exit.");


            string choise = Console.ReadLine();

            var teachersData = new TeachersData();

            while (true)
            {
                switch (choise)
                {
                    case "1":
                        Console.WriteLine("-----> All Teachers <-----");
                        teachersData.DisplayAllTeachers();
                        break;
                    case "2":
                        Console.WriteLine("-----> Adding New Teacher <-----");
                        teachersData.AddnewTeacher();
                        teachersData.DisplayAllTeachers();
                        break;
                    case "3":
                        Console.WriteLine("-----> Updating Teacher's data <-----");
                        teachersData.DisplayAllTeachers();
                        teachersData.UpdateTeacher();
                        break;
                    case "x":
                        Console.WriteLine("Bye");
                        return;
                    default:
                        break;
                }

                Console.WriteLine("Select another option or x to exit:");
                choise = Console.ReadLine();
            }
            
        }
    }
}
