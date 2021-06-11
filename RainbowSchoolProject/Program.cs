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


            StoreData(FileLines, teachers);
            DisplayData(teachers);


        }

        static void StoreData(List<String> FileLines, List<Teacher> teachers)
        {

            foreach (var line in FileLines)
            {
                string[] enteries = line.Split(',');

                Teacher newTeacher = new Teacher();

                newTeacher.ID = Convert.ToInt32(enteries[0]);
                newTeacher.name = enteries[1];
                newTeacher.ClassesAndSections = enteries[2].Split('-');

                teachers.Add(newTeacher);

            }
        }

        static void DisplayData(List<Teacher> teachers)
        {

            foreach (var teacher in teachers)
            {
                Console.Write($"Id: {teacher.ID} | Name: {teacher.name} | Class(Section): ");

                foreach (var classSec in teacher.ClassesAndSections)
                {
                    Console.Write($" {classSec} ");
                }

                Console.WriteLine();
            }
        }
    }
}
