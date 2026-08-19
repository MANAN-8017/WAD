class Student2
{
    private string name;
    private int rollNumber;
    private string course;
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public int RollNumber
    {
        get { return rollNumber; }
        set
        {
            if (value <= 0)
            {
                Console.WriteLine("Roll Number must be positive.");
            }
            else
            {
                rollNumber = value;
            }
        }
    }
    public string Course
    {
        get { return course; }
        set { course = value; }
    }
    public void DisplayDetails()
    {
        Console.WriteLine("Student Details");
        Console.WriteLine($"Name       : {Name}");
        Console.WriteLine($"Roll Number: {RollNumber}");
        Console.WriteLine($"Course     : {Course}");
    }
}
class Assignment2
{
    public static void Run()
    {
        Student2 student = new Student2();
        student.Name = "Manan Patel";
        student.RollNumber = 101;
        student.Course = "Computer Engineering";
        student.DisplayDetails();
        Console.WriteLine("\nTesting invalid Roll Number:");
        student.RollNumber = -5;
    }
}