using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RainbowSchoolProject
{
    public class TeachersData
    {
        private string _fileName = "TeacherData.txt";

        private List<Teacher> _teachers { get; set; } = new List<Teacher>();

        public TeachersData()
        {
            FindFileOrCreate();
            RetrieveData();

        }

        private void FindFileOrCreate()
        {
            if (!File.Exists(_fileName))
            {
                File.CreateText(_fileName);

            }
        }

        //get the data form the text file and store it in Teacher List
        private void RetrieveData()
        {
            List<String> FileLines = File.ReadAllLines(_fileName).ToList();

            foreach (var line in FileLines)
            {
                string[] enteries = line.Split(',');

                Teacher newTeacher = new Teacher();

                newTeacher.ID = Convert.ToInt32(enteries[0]);
                newTeacher.Name = enteries[1];
                newTeacher.ClassesAndSections = enteries[2].Split('-');

                _teachers.Add(newTeacher);

            }
        }


        //Store the teachers' data to the text file
        private void StoreData()
        {

            List<string> output = new List<string>();

            foreach (var teacher in _teachers)
            {


                output.Add($"{teacher.ID},{teacher.Name},{teacher.JoinClassesAndSections()}");

            }

            File.WriteAllLines(_fileName, output);

        }

        //Display the teachers' data to the console
        public void DisplayAllTeachers()
        {

            foreach (var teacher in _teachers)
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
        public void AddnewTeacher()
        {
            Teacher newTeacher = new Teacher();

            newTeacher.ID = _teachers.Count + 1;

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

            _teachers.Add(newTeacher);

            Console.WriteLine("New teacher added successfully");

            //Store the data after adding new teacher
            StoreData();

        }

        //Update teacher's data (Ask the user which data to update)
        public void UpdateTeacher()
        {
            Console.WriteLine("Enter the id of the teacher");

            int enteredTeacherId = Convert.ToInt32(Console.ReadLine());

            //Check if entered teacher id is exists
            if (!_teachers.Exists(x => x.ID == enteredTeacherId))
            {
                Console.WriteLine("The id is not vaild");
            }

            Teacher teacherToUodate = FindTeacherById(enteredTeacherId);

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

            //Store the data after updating data
            StoreData();
        }

        //Update teacher's data (update the the name)
        private void UpdateTeacherName(Teacher teacherToUodate)
        {
            string oldTeacherName = teacherToUodate.Name;

            Console.WriteLine("Enetr the new name");
            string newTeacherName = Console.ReadLine();

            teacherToUodate.Name = newTeacherName;

            Console.WriteLine("Teacher name updated successfully.");
            Console.WriteLine($"Old name: {oldTeacherName}, New name: {newTeacherName}");

        }

        //Update teacher's data (update the classes and sections)
        private void UpdateTeacherClassesAndSections(Teacher teacherToUodate)
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
        private Teacher FindTeacherById(int teacherID)
        {
            return _teachers.Find(x => x.ID == teacherID);
        }

    }
}
