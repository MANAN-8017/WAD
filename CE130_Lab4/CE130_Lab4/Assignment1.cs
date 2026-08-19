class Student
{
    public string Name;
    public int RollNumber;
    public string Course;
    public void DisplayDetails()
    {
        Console.WriteLine("Student Details");
        Console.WriteLine($"Name       : {Name}");
        Console.WriteLine($"Roll Number: {RollNumber}");
        Console.WriteLine($"Course     : {Course}");
        Console.WriteLine();
    }
}

class Assignment1
{
    public static void Run()
    {
        Student student1 = new Student();
        student1.Name = "Manan Patel";
        student1.RollNumber = 101;
        student1.Course = "Computer Engineering";
        Student student2 = new Student();
        student2.Name = "Prit Patel";
        student2.RollNumber = 102;
        student2.Course = "Information Technology";
        student1.DisplayDetails();
        student2.DisplayDetails();
    }
}