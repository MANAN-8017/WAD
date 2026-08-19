class Program
{
    static void Main(string[] args)
    {
        bool run = true;
        while (run)
        {
            Console.WriteLine("WAD LAB 4\n");
            Console.WriteLine("1. Assignment 1 - Classes and Objects");
            Console.WriteLine("2. Assignment 2 - Encapsulation");
            Console.WriteLine("3. Assignment 3 - Inheritance and Polymorphism");
            Console.WriteLine("4. Assignment 4 - Abstraction");
            Console.WriteLine("5. Exit\n");
            Console.Write("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            switch (choice)
            {
                case 1:
                    Assignment1.Run();
                    break;
                case 2:
                    Assignment2.Run();
                    break;
                case 3:
                    Assignment3.Run();
                    break;
                case 4:
                    Assignment4.Run();
                    break;
                case 5:
                    run = false;
                    Console.WriteLine("Exiting the program.");
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
            Console.WriteLine("\n");
        }
    }
}