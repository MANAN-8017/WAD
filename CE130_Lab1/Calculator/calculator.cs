Console.WriteLine("Enter The First Number");
double x = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("Enter The Second Number");
double y = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("\nMenu:\n1. Addition\n2. Subtraction\n3. Multiplication\n4. Division\n5. Modulus\n");
Console.WriteLine("Enter The Operation Number to Perform");
int op = Convert.ToInt32(Console.ReadLine());

Double result = 0;

switch (op){
    case 1:
        result = x + y;
        break;
    case 2:
        result = x - y;
        break;
    case 3:
        result = x * y;
        break;
    case 4:
        result = x / y;
        break;
    case 5:
        result = x % y;
        break;
    default:
        Console.WriteLine("Enter Valid Operation Number");
        break;
}

Console.WriteLine("\nAnswer: " + result);