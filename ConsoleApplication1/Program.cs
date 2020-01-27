using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;


namespace ConsoleApplication1
{
    internal class Program
    {
        private static List<Student> _dataStudents;
        public static void Main(string[] args)
        {

            _dataStudents = JsonConvert.DeserializeObject<List<Student>>(File.ReadAllText("students.json"));
            Console.Clear();

            StartProgram();
            
        }

        public static void StartProgram()
        {
            Console.WriteLine("Enter the commands (help, list, exit, add student, remove student, clear): ");
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
            } else if (result.ToLower() == "remove student")
            {
                RemoveStudent();
            } else if (result.ToLower() == "clear")
            {
                ClearConsole();
            } else
            {
                Console.WriteLine("Program command: help, list, exit, add student, remove student, clear");
                StartProgram();
            }
            
        }

        public static void Help()
        {
            Console.Clear();
            Console.WriteLine("This program keeps a list of students");
            Console.WriteLine("Program commands:");
            Console.WriteLine("help, list, exit, add student, remove student, clear");
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
            } else if (helpCommand.ToLower() == "remove student")
            {
                RemoveStudent();
            } else if (helpCommand.ToLower() == "clear")
            {
                ClearConsole();
            } else
            {
                Console.WriteLine("Program command: help, list, exit, add student, remove student, clear");
                StartProgram();
            }
        }
        
        public static void ListStudent() 
        {
            Console.Clear();
            foreach (var student in _dataStudents)
            {
                student.Print();
            }
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
            Console.Clear();
            Console.WriteLine("Enter the Full name for student:");
            string fullName = Console.ReadLine();
            Console.WriteLine("Enter the Course for student: ");
            int course = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Enter the Grant for student (true/false): ");
            bool grant = Convert.ToBoolean(Console.ReadLine());
            Guid id = Guid.NewGuid();
            
            _dataStudents.Add(new Student(id, fullName, course, grant ));

            var convertedJson = JsonConvert.SerializeObject(_dataStudents, Formatting.Indented);
            
            File.WriteAllText("students.json", convertedJson);
            
            Console.Clear();
            Console.WriteLine("Successfully!");
                
            StartProgram();
        }

        public static void RemoveStudent()
        {
            Console.Clear();
            Console.WriteLine("Enter the student GUID (seven first char): ");
            string guidStudent = Console.ReadLine();
            foreach (Student student in _dataStudents)
            {
                if (guidStudent == student.id.ToString().Substring(0, 8))
                {
                    _dataStudents.Remove(student);
                    
                    var convertedJson = JsonConvert.SerializeObject(_dataStudents, Formatting.Indented);
            
                    File.WriteAllText("students.json", convertedJson);
                    
                    Console.WriteLine("Student " + student.fullName + " successfully removed.");
                    break;
                }
            }
            
            StartProgram();
        }

        public static void ClearConsole()
        {
            Console.Clear();
            StartProgram();
        }
    }

    public class Student
    {
        public static int countStudents = 0;
        public string fullName { get; set; }
        public int course { get; set; }
        public bool grant { get; set; }
        public Guid id { get; set; }

        public Student(Guid id, string fullName, int course, bool grant)
        {
            countStudents++;
            this.id = id;
            this.fullName = fullName;
            this.course = course;
            this.grant = grant;
            Print();
        }

        public void Print()
        {
            Console.WriteLine("Student GUID - " + id);
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