using System;

delegate double ArithmeticOperation(double a, double b);

class Calculator
{
    static double Add(double a, double b)
    {
        return a + b;
    }

    static double Subtract(double a, double b)
    {
        return a - b;
    }

    static double Multiply(double a, double b)
    {
        return a * b;
    }

    static double Divide(double a, double b)
    {
        return a / b;
    }

    public static void Run()
    {
        Console.Write("Enter first number: ");
        double num1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter second number: ");
        double num2 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("\n1. Addition");
        Console.WriteLine("2. Subtraction");
        Console.WriteLine("3. Multiplication");
        Console.WriteLine("4. Division");

        Console.Write("Enter choice: ");
        int choice = Convert.ToInt32(Console.ReadLine());

        ArithmeticOperation operation;

        switch (choice)
        {
            case 1:
                operation = Add;
                break;

            case 2:
                operation = Subtract;
                break;

            case 3:
                operation = Multiply;
                break;

            case 4:
                if (num2 == 0)
                {
                    Console.WriteLine("Cannot divide by zero.");
                    return;
                }

                operation = Divide;
                break;

            default:
                Console.WriteLine("Invalid choice.");
                return;
        }

        Console.WriteLine($"Result: {operation(num1, num2)}");
    }
}