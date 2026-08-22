class AsyncCalculator
{
    public static async Task Run()
    {
        Console.WriteLine("Asynchronous Calculator");
        Console.WriteLine("1. Addition");
        Console.WriteLine("2. Subtraction");
        Console.WriteLine("3. Multiplication");
        Console.WriteLine("4. Division");
        Console.WriteLine("5. Run All Simultaneously");
        Console.Write("\nChoose an option (1-5): ");
        string choice = Console.ReadLine();
        if (choice != "1" && choice != "2" &&
            choice != "3" && choice != "4" &&
            choice != "5")
        {
            Console.WriteLine("Invalid option.");
            return;
        }
        double num1 = GetNumberInput("Enter the first number: ");
        double num2 = GetNumberInput("Enter the second number: ");
        Console.WriteLine("\nProcessing...");
        try
        {
            switch (choice)
            {
                case "1":
                    double addResult = await AddAsync(num1, num2);
                    Console.WriteLine(
                        $"Addition: {num1} + {num2} = {addResult}");
                    break;
                case "2":
                    double subResult = await SubtractAsync(num1, num2);
                    Console.WriteLine(
                        $"Subtraction: {num1} - {num2} = {subResult}");
                    break;
                case "3":
                    double mulResult = await MultiplyAsync(num1, num2);
                    Console.WriteLine(
                        $"Multiplication: {num1} * {num2} = {mulResult}");
                    break;
                case "4":
                    double divResult = await DivideAsync(num1, num2);
                    Console.WriteLine(
                        $"Division: {num1} / {num2} = {divResult}");
                    break;
                case "5":
                    await RunAllOperationsAsync(num1, num2);
                    break;
            }
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
    static async Task<double> AddAsync(double a, double b)
    {
        await Task.Delay(2000);
        return a + b;
    }
    static async Task<double> SubtractAsync(double a, double b)
    {
        await Task.Delay(2000);
        return a - b;
    }
    static async Task<double> MultiplyAsync(double a, double b)
    {
        await Task.Delay(2000);
        return a * b;
    }
    static async Task<double> DivideAsync(double a, double b)
    {
        await Task.Delay(2000);
        if (b == 0)
        {
            throw new DivideByZeroException(
                "Cannot divide by zero.");
        }
        return a / b;
    }
    static async Task RunAllOperationsAsync(double a, double b)
    {
        Task<double> addTask = AddAsync(a, b);
        Task<double> subtractTask = SubtractAsync(a, b);
        Task<double> multiplyTask = MultiplyAsync(a, b);
        Task<double> divideTask = DivideAsync(a, b);
        await Task.WhenAll(
            addTask,
            subtractTask,
            multiplyTask,
            divideTask
        );
        Console.WriteLine();
        Console.WriteLine("=== All Results ===");
        Console.WriteLine(
            $"Addition       : {a} + {b} = {addTask.Result}");
        Console.WriteLine(
            $"Subtraction    : {a} - {b} = {subtractTask.Result}");
        Console.WriteLine(
            $"Multiplication : {a} * {b} = {multiplyTask.Result}");
        Console.WriteLine(
            $"Division       : {a} / {b} = {divideTask.Result}");
    }
    static double GetNumberInput(string prompt)
    {
        double result;
        while (true)
        {
            Console.Write(prompt);
            if (double.TryParse(Console.ReadLine(), out result))
            {
                return result;
            }
            Console.WriteLine(
                "Invalid input. Please enter a valid number.");
        }
    }
}