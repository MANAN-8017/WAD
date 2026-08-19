using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
    public int StudentId { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
    public int Semester { get; set; }
    public int Age { get; set; }
    public double CGPA { get; set; }
}

class Student_Record
{
    public static void Run()
    {
        List<Student> students = new List<Student>
        {
            new Student { StudentId = 101, Name = "Rahul", Department = "Computer Engineering", Semester = 5, Age = 20, CGPA = 8.7 },
            new Student { StudentId = 102, Name = "Priya", Department = "Information Technology", Semester = 5, Age = 21, CGPA = 9.1 },
            new Student { StudentId = 103, Name = "Amit", Department = "Computer Engineering", Semester = 3, Age = 19, CGPA = 8.2 },
            new Student { StudentId = 104, Name = "Neha", Department = "Electronics", Semester = 7, Age = 22, CGPA = 7.8 },
            new Student { StudentId = 105, Name = "Karan", Department = "Computer Engineering", Semester = 5, Age = 20, CGPA = 9.3 },
            new Student { StudentId = 106, Name = "Sneha", Department = "Mechanical", Semester = 3, Age = 19, CGPA = 8.5 },
            new Student { StudentId = 107, Name = "Vivek", Department = "Information Technology", Semester = 7, Age = 22, CGPA = 8.9 },
            new Student { StudentId = 108, Name = "Riya", Department = "Computer Engineering", Semester = 3, Age = 19, CGPA = 7.9 },
            new Student { StudentId = 109, Name = "Harsh", Department = "Mechanical", Semester = 5, Age = 21, CGPA = 8.1 },
            new Student { StudentId = 110, Name = "Pooja", Department = "Electronics", Semester = 7, Age = 22, CGPA = 9.0 }
        };

        Console.WriteLine("Students with CGPA greater than 8.0:");

        var highCgpaStudents = students
            .Where(s => s.CGPA > 8.0)
            .Select(s => s.Name);

        foreach (var name in highCgpaStudents)
        {
            Console.WriteLine(name);
        }

        Console.WriteLine("\nComputer Engineering students sorted by CGPA:");

        var computerStudents = students
            .Where(s => s.Department == "Computer Engineering")
            .OrderByDescending(s => s.CGPA);

        foreach (var student in computerStudents)
        {
            Console.WriteLine(
                $"{student.Name} - CGPA: {student.CGPA}"
            );
        }

        Console.WriteLine("\nTop 3 students based on CGPA:");

        var topThreeStudents = students
            .OrderByDescending(s => s.CGPA)
            .Take(3);

        foreach (var student in topThreeStudents)
        {
            Console.WriteLine(
                $"{student.Name} - {student.Department} - CGPA: {student.CGPA}"
            );
        }

        Console.WriteLine("\nNumber of students in each department:");

        var departmentCount = students
            .GroupBy(s => s.Department)
            .Select(g => new
            {
                Department = g.Key,
                Count = g.Count()
            });

        foreach (var department in departmentCount)
        {
            Console.WriteLine(
                $"{department.Department}: {department.Count}"
            );
        }
    }
}