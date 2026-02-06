using System;
using System.Collections.Generic;
using System.Linq;

namespace StundetApp
{
    class studentdetalis
    {
        public int studentid;
        public string Name;
        public string Department;
        public int marks;
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<studentdetalis> students = new List<studentdetalis>();
            int choice;

            do
            {
                Console.WriteLine("\n===== STUDENT DETAILS MENU =====");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Display All Students");
                Console.WriteLine("3. Display Name and Department");
                Console.WriteLine("4. Students with Marks > 75");
                Console.WriteLine("5. Students from Specific Department");
                Console.WriteLine("6. Sort Students by Marks (Descending)");
                Console.WriteLine("7. Display Top Scorer");
                Console.WriteLine("8. Exit");
                Console.Write("Enter your choice: ");

                int.TryParse(Console.ReadLine(), out choice);

                switch (choice)
                {
                    case 1:
                        studentdetalis s = new studentdetalis();

                        Console.Write("Student ID: ");
                        int.TryParse(Console.ReadLine(), out s.studentid);

                        Console.Write("Name: ");
                        s.Name = Console.ReadLine();

                        Console.Write("Department: ");
                        s.Department = Console.ReadLine();

                        Console.Write("Marks: ");
                        int.TryParse(Console.ReadLine(), out s.marks);

                        students.Add(s);
                        Console.WriteLine("Student added successfully.");
                        break;

                    case 2:
                        Console.WriteLine("\n--- All Student Records ---");
                        foreach (var st in students)
                        {
                            Console.WriteLine($"{st.studentid} | {st.Name} | {st.Department} | {st.marks}");
                        }
                        break;

                    case 3:
                        Console.WriteLine("\n--- Name and Department ---");
                        foreach (var st in students)
                        {
                            Console.WriteLine($"{st.Name} | {st.Department}");
                        }
                        break;

                    case 4:
                        Console.WriteLine("\n--- Students with Marks > 75 ---");
                        foreach (var st in students)
                        {
                            if (st.marks > 75)
                                Console.WriteLine($"{st.Name} | {st.marks}");
                        }
                        break;

                    case 5:
                        Console.Write("Enter Department: ");
                        string dept = Console.ReadLine();

                        Console.WriteLine($"\n--- Students from {dept} Department ---");
                        foreach (var st in students)
                        {
                            if (st.Department.Equals(dept, StringComparison.OrdinalIgnoreCase))
                                Console.WriteLine($"{st.Name} | {st.marks}");
                        }
                        break;

                    case 6:
                        Console.WriteLine("\n--- Students Sorted by Marks (Descending) ---");

                        var sortedStudents = students.OrderByDescending(x => x.marks);

                        foreach (var st in sortedStudents)
                        {
                            Console.WriteLine($"{st.Name} | {st.marks}");
                        }
                        break;

                    case 7:
                        if (students.Count == 0)
                        {
                            Console.WriteLine("No records available.");
                            break;
                        }

                        int maxMarks = students.Max(x => x.marks);

                        Console.WriteLine("\n--- Top Scorer ---");
                        foreach (var st in students)
                        {
                            if (st.marks == maxMarks)
                            {
                                Console.WriteLine($"{st.Name} | {st.Department} | {st.marks}");
                            }
                        }
                        break;

                    case 8:
                        Console.WriteLine("Exiting program...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }

            } while (choice != 8);
        }
    }
}
