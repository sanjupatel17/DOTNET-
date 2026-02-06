using System;
using System.Collections.Generic;

namespace StudentOOPApp
{
    class Student
    {
        // Encapsulation using properties
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public int Year { get; set; }
        public int Marks { get; set; }

        // Constructor
        public Student(int studentId, string name, string department, int year, int marks)
        {
            this.StudentId = studentId;
            this.Name = name;
            this.Department = department;
            this.Year = year;
            this.Marks = marks;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 4. Create multiple student objects
            List<Student> students = new List<Student>
            {
                new Student(1, "Sanju", "CSE", 3, 82),
                new Student(2, "Diya", "IT", 2, 91),
                new Student(3, "Sanjay", "CSE", 4, 76),
                new Student(4, "Jihan", "ECE", 3, 68),
                new Student(5, "Sam", "IT", 4, 88)
            };

            // 5. Display all student records
            Console.WriteLine("\nAll Student Records");
            foreach (Student s in students)
            {
                Console.WriteLine($"{s.StudentId} | {s.Name} | {s.Department} | {s.Year} | {s.Marks}");
            }

            // 6. Find students with marks > 75
            Console.WriteLine("\nStudents with Marks > 75 ");
            foreach (Student s in students)
            {
                if (s.Marks > 75)
                {
                    Console.WriteLine($"{s.Name} | {s.Marks}");
                }
            }

            // 7. Sort students by marks (Descending)
            for (int i = 0; i < students.Count - 1; i++)
            {
                for (int j = i + 1; j < students.Count; j++)
                {
                    if (students[i].Marks < students[j].Marks)
                    {
                        Student temp = students[i];
                        students[i] = students[j];
                        students[j] = temp;
                    }
                }
            }

            Console.WriteLine("\nStudents Sorted by Marks (Descending) ");
            foreach (Student s in students)
            {
                Console.WriteLine($"{s.Name} | {s.Marks}");
            }

            // 8. Display top 3 scorers
            Console.WriteLine("\nTop 3 Scorers ");
            for (int i = 0; i < 3 && i < students.Count; i++)
            {
                Console.WriteLine($"{students[i].Name} | {students[i].Department} | {students[i].Marks}");
            }

            Console.WriteLine("\nProgram completed.");
        }
    }
}
