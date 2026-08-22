using System;
using System.Threading.Tasks;

namespace WADLab
{
    class Program
    {
        static async Task Main(string[] args)
        {
            bool run = true;
            while (run)
            {
                Console.WriteLine("WAD LAB 5\n");
                Console.WriteLine("1. Discount Management");
                Console.WriteLine("2. Asynchronous Calculator");
                Console.WriteLine("5. Exit\n");

                Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                Console.Clear();

                switch (choice)
                {
                    case 1:
                        DiscountManagement.Run();
                        break;

                    case 2:
                        await AsyncCalculator.Run();
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
}