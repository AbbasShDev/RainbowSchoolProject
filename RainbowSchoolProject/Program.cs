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

            string fileName = "TeacherData.txt";

            if (! File.Exists(fileName))
            {
                File.CreateText(fileName);

            }

            //create list of teachers
            List<Teacher> teachers = new List<Teacher>();

            //read the text file lines and convert id to a list
            List<String> FileLines = File.ReadAllLines(fileName).ToList();

            //get the data form the text file
            RetrieveData(FileLines, teachers);

            Console.WriteLine("Enter 1 to display all teachers.");
            Console.WriteLine("Enter 2 to add new teacher.");

            string choise = Console.ReadLine();
            switch (choise)
            {
                case "1":
                    DisplayData(teachers);
                    break;
                case "2":
                    AddnewTeacher(teachers);
                    StoreData(fileName, teachers);
                    DisplayData(teachers);
                    break;
                default:
                    break;
            }


        }

        static void RetrieveData(List<String> FileLines, List<Teacher> teachers)
        {

            foreach (var line in FileLines)
            {
                string[] enteries = line.Split(',');

                Teacher newTeacher = new Teacher();

                newTeacher.ID = Convert.ToInt32(enteries[0]);
                newTeacher.Name = enteries[1];
                newTeacher.ClassesAndSections = enteries[2].Split('-');

                teachers.Add(newTeacher);

            }
        }

        static void DisplayData(List<Teacher> teachers)
        {

            foreach (var teacher in teachers)
            {
                Console.Write($"Id: {teacher.ID} | Name: {teacher.Name} | Class(Section): ");

                foreach (var classSec in teacher.ClassesAndSections)
                {
                    Console.Write($" {classSec} ");
                }

                Console.WriteLine();
            }
        }

        static void AddnewTeacher(List<Teacher> teachers)
        {
            Teacher newTeacher = new Teacher();

            newTeacher.ID = teachers.Count + 1;

            Console.WriteLine("Enter the name of the teacher: ");

            newTeacher.Name = Console.ReadLine();


            Console.WriteLine("Enter how many class and section to add: ");
            int numOfClassSec = Convert.ToInt32(Console.ReadLine());

            string[] newClassSec = new string[numOfClassSec];

            for (int i = 0; i < numOfClassSec; i++)
            {
                Console.WriteLine($"Enter the name of class#{i + 1}: ");

                string className = Console.ReadLine();

                Console.WriteLine($"Enter the section number of class#{i + 1}: ");

                string sectionNum = Console.ReadLine();

                newClassSec[i] = $"{className}({sectionNum})";
            }

            newTeacher.ClassesAndSections = newClassSec;

            teachers.Add(newTeacher);

            Console.WriteLine("New teacher added successfully");

        }

        static void StoreData(string fileName, List<Teacher> teachers)
        {

            List<string> output = new List<string>();

            foreach (var teacher in teachers)
            {
                

                output.Add($"{teacher.ID},{teacher.Name},{teacher.JoinClassesAndSections()}");

            }

            File.WriteAllLines(fileName, output);

        }
    }
}
