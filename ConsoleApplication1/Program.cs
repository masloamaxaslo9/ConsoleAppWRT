using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;


namespace ConsoleApplication1
{
    internal class Program
    {
        public static void Main(string[] args)
        {

            // foreach (var student in dataStudents.Students)
            // {
            //     // Student addStudent = new Student(student.fullName, student.course, student.grant);
            // }
            
            DataStudents dataStudents = JsonConvert.DeserializeObject<DataStudents>(File.ReadAllText("students.json"));
            Console.Clear();

            StartProgram();
            
        }

        public static void StartProgram()
        {
            Console.WriteLine("Enter the commands (help, list, exit, add student): ");
            string result = Console.ReadLine();
            
            if (result.ToLower() == "help")
            {
                Help();
            }
            else if (result.ToLower() == "list")
            {
                ListStudent();
            }
            else if (result.ToLower() == "exit")
            {
                Exit();
            }
            else if (result.ToLower() == "add student")
            {
                AddStudent();
            }
            else
            {
                Console.WriteLine("Program command: help, list, exit, add student");
                StartProgram();
            }
            
        }

        public static void Help()
        {
            Console.WriteLine("This program keeps a list of students");
            Console.WriteLine("Program commands:");
            Console.WriteLine("help, list, exit, add student");
            Console.WriteLine("Enter the command: ");
            string helpCommand = Console.ReadLine();
            if (helpCommand.ToLower() == "help")
            {
                    Help();
            } 
            else if (helpCommand.ToLower() == "list")
            {
                ListStudent();
            }
            else if (helpCommand.ToLower() == "exit")
            {
                Exit();
            }
            else if (helpCommand.ToLower() == "add student")
            {
                AddStudent();
            }
        }
        
        public static void ListStudent() 
        {
            Console.WriteLine("Not work");
            StartProgram();
        }
        
        public static void Exit()
        {
           Console.WriteLine("Good bye!");
           Console.WriteLine("(Enter key)");
           Console.ReadKey();
        }
        
        public static void AddStudent()
        {
            Console.WriteLine("Enter the Full name for student:");
            string fullName = Console.ReadLine();
            Console.WriteLine("Enter the Course for student: ");
            int course = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Enter the Grant for student (true/false): ");
            bool grant = Convert.ToBoolean(Console.ReadLine());

            Student newStudent = new Student(fullName, course, grant);
                
            StartProgram();
        }
    }

    public class Student
    {
        public static int countStudents = 0;
        public string fullName { get; set; }
        public int course { get; set; }
        public bool grant { get; set; }

        public Student(string fullName, int course, bool grant)
        {
            countStudents++;
            this.fullName = fullName;
            this.course = course;
            this.grant = grant;
            Print();
        }

        public void Print()
        {
            Console.WriteLine("Student ID - " + countStudents);
            Console.WriteLine("Full name: " + fullName);
            Console.WriteLine("Course: " + course);
            Console.WriteLine("Grant: " + grant);
            Console.WriteLine();
        }
    }

    public class DataStudents
    {
        public Student[] Students { get; set; }
        public List<Student> sstudents { get; set; }
    }
}