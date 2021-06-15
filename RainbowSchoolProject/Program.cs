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

            
            ConsoleColorMessage(ConsoleColor.Blue, "Select option:");
            ConsoleColorMessage(ConsoleColor.Blue, "Press 1 to display all teachers.");
            ConsoleColorMessage(ConsoleColor.Blue, "Press 2 to add new teacher.");
            ConsoleColorMessage(ConsoleColor.Blue, "Press 3 to update a teacher data.");
            ConsoleColorMessage(ConsoleColor.Blue, "Press x to exit.");

            string choise = Console.ReadLine();

            var teachersData = new TeachersData();

            while (true)
            {
                switch (choise)
                {
                    case "1":
                        ConsoleColorMessage(ConsoleColor.Magenta, "-----> All Teachers <-----");
                        teachersData.DisplayAllTeachers();
                        break;
                    case "2":
                        ConsoleColorMessage(ConsoleColor.Magenta, "-----> Adding New Teacher <-----");
                        teachersData.AddnewTeacher();
                        break;
                    case "3":
                        ConsoleColorMessage(ConsoleColor.Magenta, "-----> Updating Teacher's data <-----");
                        teachersData.DisplayAllTeachers();
                        teachersData.UpdateTeacher();
                        break;
                    case "x":
                        ConsoleColorMessage(ConsoleColor.Magenta, "Bye");
                        return;
                    default:
                        break;
                }
                ConsoleColorMessage(ConsoleColor.Blue, "---------------------------");
                ConsoleColorMessage(ConsoleColor.Blue, "Select another option:");
                ConsoleColorMessage(ConsoleColor.Blue, "1 to display all teachers.");
                ConsoleColorMessage(ConsoleColor.Blue, "2 to add new teacher.");
                ConsoleColorMessage(ConsoleColor.Blue, "3 to update a teacher data.");
                ConsoleColorMessage(ConsoleColor.Blue, "x to exit.");

                choise = Console.ReadLine();
            }
            
        }

        //Print colored message to the console
        static void ConsoleColorMessage(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;

            Console.WriteLine(message);

            Console.ResetColor();
        }
    }
}
