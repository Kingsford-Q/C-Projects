using System;
using System.Collections.Generic;

class Program
{
    static readonly string[] CourseNames =
    {
        "Programming with C#",
        "Database Systems",
        "Computer Networks",
        "Web Development",
        "Mathematics for Computing"
    };

    static List<Student> students = new List<Student>();

    static void Main()
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine();
            Console.WriteLine("===== STUDENT RESULTS PROCESSING SYSTEM =====");
            Console.WriteLine("1. Enter Student Results");
            Console.WriteLine("2. View Student Report");
            Console.WriteLine("3. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    EnterStudentResults();
                    break;
                case "2":
                    ViewStudentReport();
                    break;
                case "3":
                    Console.WriteLine("Thank you for using the Student Results Processing System.");
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please choose 1, 2 or 3.");
                    break;
            }
        }
    }

    static void EnterStudentResults()
    {
        int studentNumber = 1;

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine($"Enter details for Student {studentNumber}");
            Console.WriteLine("(Type 'exit' instead of the name to stop entering students)");

            Student student = new Student();

            Console.Write("Enter full name: ");
            student.FullName = Console.ReadLine();

            if (student.FullName != null && student.FullName.Trim().ToLower() == "exit")
            {
                break;
            }

            Console.Write("Enter student ID: ");
            student.StudentId = Console.ReadLine();

            Console.Write("Enter programme: ");
            student.Programme = Console.ReadLine();

            Console.Write("Enter level: ");
            student.Level = Console.ReadLine();

            for (int c = 0; c < CourseNames.Length; c++)
            {
                student.Scores[c] = ReadValidScore(CourseNames[c]);
            }

            student.CalculateResults();
            students.Add(student);
            studentNumber++;

            Console.Write("Add another student? (Y/N): ");
            string answer = Console.ReadLine();

            if (answer != null && answer.Trim().ToLower() == "n")
            {
                break;
            }
        }

        Console.WriteLine();
        Console.WriteLine($"{students.Count} student(s) entered.");
    }

    // Keeps asking for a score until the user enters a valid number between 0 and 100.
    static double ReadValidScore(string courseName)
    {
        while (true)
        {
            Console.Write($"Enter score for {courseName}: ");
            string input = Console.ReadLine();

            if (double.TryParse(input, out double score) && score >= 0 && score <= 100)
            {
                return score;
            }

            Console.WriteLine("Invalid score. Score must be between 0 and 100.");
        }
    }

    static void ViewStudentReport()
    {
        if (students.Count == 0)
        {
            Console.WriteLine();
            Console.WriteLine("No student results have been entered yet. Please choose option 1 first.");
            return;
        }

        Console.WriteLine();
        Console.WriteLine("===== STUDENT RESULTS REPORT =====");

        foreach (Student student in students)
        {
            Console.WriteLine();
            Console.WriteLine($"Student Name: {student.FullName}");
            Console.WriteLine($"Student ID: {student.StudentId}");
            Console.WriteLine($"Programme: {student.Programme}");
            Console.WriteLine($"Level: {student.Level}");

            for (int c = 0; c < CourseNames.Length; c++)
            {
                Console.WriteLine($"{CourseNames[c]}: {student.Scores[c]}");
            }

            Console.WriteLine($"Total Score: {student.Total}");
            Console.WriteLine($"Average Score: {student.Average:F1}");
            Console.WriteLine($"Grade: {student.Grade}");
            Console.WriteLine($"Status: {student.Status}");
        }

        DisplayClassSummary();
    }

    // Shows the best student, the weakest student, and the overall class average.
    static void DisplayClassSummary()
    {
        Student bestStudent = students[0];
        Student weakestStudent = students[0];
        double totalOfAverages = 0;

        foreach (Student student in students)
        {
            if (student.Average > bestStudent.Average)
            {
                bestStudent = student;
            }

            if (student.Average < weakestStudent.Average)
            {
                weakestStudent = student;
            }

            totalOfAverages += student.Average;
        }

        double classAverage = totalOfAverages / students.Count;

        Console.WriteLine();
        Console.WriteLine("===== CLASS SUMMARY =====");
        Console.WriteLine($"Best Student: {bestStudent.FullName} (Average: {bestStudent.Average:F1})");
        Console.WriteLine($"Lowest Average Student: {weakestStudent.FullName} (Average: {weakestStudent.Average:F1})");
        Console.WriteLine($"Class Average: {classAverage:F1}");
    }
}
