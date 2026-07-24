int secretNumber = 1711;
int attempts = 0;

Console.WriteLine("Guess the Number");

while (true)
{
    int number = Convert.ToInt32(Console.ReadLine());

    if (number == secretNumber)
    {
        Console.WriteLine("Congratulations You made Guess!!");
        break;
    }

    else if (number - secretNumber > 0 && number - secretNumber <= 10)
        Console.Write("High! ");

    else if (number - secretNumber < -10)
        Console.Write("Too Low! ");

    else if (number - secretNumber >= -10 && number - secretNumber < 0)
        Console.Write("Less! ");

    else if (number - secretNumber > 10)
        Console.Write("Too High! ");

    attempts++;

    Console.WriteLine("Try Again!");    
}
Console.WriteLine("Total Attempts: " + attempts);