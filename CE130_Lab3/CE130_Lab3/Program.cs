class Program
{
    static void Main()
    {
        Console.WriteLine("WAD LAB 3");
        Console.WriteLine("1. Student Record LINQ");
        Console.WriteLine("2. Calculator");
        Console.WriteLine("3. Sample Program");
        Console.Write("Enter choice: ");

        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1:
                Student_Record.Run();
                break;

            case 2:
                Calculator.Run();
                break;

            case 3:
                Sample_prog.Run(); 
                break;

            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }
}