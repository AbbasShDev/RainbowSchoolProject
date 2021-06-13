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

            //get the data form the text file and store it in Teacher List
            RetrieveData(FileLines, teachers);

            Console.WriteLine("Enter 1 to display all teachers.");
            Console.WriteLine("Enter 2 to add new teacher.");
            Console.WriteLine("Enter 3 to update a teacher data.");

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
                case "3":
                    DisplayData(teachers);
                    UpdateTeacher(teachers);
                    StoreData(fileName, teachers);
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

        //Display the teachers' data to the console
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

        //Add new teacher's data
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

        //Store the teachers' data to the text file
        static void StoreData(string fileName, List<Teacher> teachers)
        {

            List<string> output = new List<string>();

            foreach (var teacher in teachers)
            {
                

                output.Add($"{teacher.ID},{teacher.Name},{teacher.JoinClassesAndSections()}");

            }

            File.WriteAllLines(fileName, output);

        }

        //Update teacher's data (Ask the user which data to update)
        static void UpdateTeacher(List<Teacher> teachers)
        {
            Console.WriteLine("Enter the id of the teacher");

            int enteredTeacherId = Convert.ToInt32(Console.ReadLine());

            //Check if entered teacher id is exists
            if (! teachers.Exists(x => x.ID == enteredTeacherId))
            {
                Console.WriteLine("The id is not vaild");
            }

            Teacher teacherToUodate = FindTeacherById(enteredTeacherId, teachers);

            Console.WriteLine("Enter 1 to update teacher's name.");
            Console.WriteLine("Enter 2 to update teacher's classes and sections.(this will remove all old classes and sections)");

            string choise = Console.ReadLine();
            switch (choise)
            {
                case "1":
                    UpdateTeacherName(teacherToUodate);
                    break;
                case "2":
                    UpdateTeacherClassesAndSections(teacherToUodate);
                    break;
                default:
                    break;
            }


        }

        //Update teacher's data (update the the name)
        static void UpdateTeacherName(Teacher teacherToUodate)
        {
            string oldTeacherName = teacherToUodate.Name;

            Console.WriteLine("Enetr the new name");
            string newTeacherName = Console.ReadLine();

            teacherToUodate.Name = newTeacherName;

            Console.WriteLine("Teacher name updated successfully.");
            Console.WriteLine($"Old name: {oldTeacherName}, New name: {newTeacherName}");

        }

        //Update teacher's data (update the classes and sections)
        static void UpdateTeacherClassesAndSections(Teacher teacherToUodate)
        {
            string oldClassSec = teacherToUodate.JoinClassesAndSections();

            Console.WriteLine("Enter how many class and section to add: ");
            int numOfClassSec = Convert.ToInt32(Console.ReadLine());

            string[] newClassSecArray = new string[numOfClassSec];

            for (int i = 0; i < numOfClassSec; i++)
            {
                Console.WriteLine($"Enter the name of class#{i + 1}: ");

                string className = Console.ReadLine();

                Console.WriteLine($"Enter the section number of class#{i + 1}: ");

                string sectionNum = Console.ReadLine();

                newClassSecArray[i] = $"{className}({sectionNum})";
            }

            teacherToUodate.ClassesAndSections = newClassSecArray;

            string newClassSec = teacherToUodate.JoinClassesAndSections();

            Console.WriteLine("Teacher classes and sections updated successfully.");
            Console.WriteLine($"Old classes: {oldClassSec}, New classes: {newClassSec}");
        }

        //Find the teacher data by the given Id and return it
        static Teacher FindTeacherById(int teacherID, List<Teacher> teachers)
        {
            return teachers.Find(x => x.ID == teacherID);
        }
    }
}
