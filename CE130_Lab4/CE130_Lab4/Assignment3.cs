class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Age: {Age}");
    }
}
class Teacher : Person
{
    public string Subject { get; set; }
    public double Salary { get; set; }
    public override void DisplayInfo()
    {
        Console.WriteLine("Teacher Details");
        Console.WriteLine($"Name   : {Name}");
        Console.WriteLine($"Age    : {Age}");
        Console.WriteLine($"Subject: {Subject}");
        Console.WriteLine($"Salary : {Salary}");
    }
}
class Assignment3
{
    public static void Run()
    {
        Teacher teacher = new Teacher();
        teacher.Name = "Dr. Chintan Patel";
        teacher.Age = 40;
        teacher.Subject = "C# and .NET";
        teacher.Salary = 75000;
        teacher.DisplayInfo();
    }
}