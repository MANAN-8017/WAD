using System;
using System.Collections.Generic;

void PrintMenu()
{
    Console.WriteLine(
        "\nBrowser History Menu:\n"
        + "\n1. Visit a new webpage"
        + "\n2. Go back"
        + "\n3. View current page"
        + "\n4. Display browsing history"
        + "\n5. Exit the application\n"
    );
}

Stack<string> browserHistory = new Stack<string>();

browserHistory.Push("https://www.google.com");
browserHistory.Push("https://www.github.com");
browserHistory.Push("https://stackoverflow.com");
browserHistory.Push("https://learn.microsoft.com");
browserHistory.Push("https://www.reddit.com");

int InputHandler(){
    while (true){
        Console.Write("Enter a number: ");

        string input = Console.ReadLine() ?? "";

        if (int.TryParse(input, out int number))
            return number;

        Console.WriteLine("\nPlease enter a valid number.\n");
    }
}

void VisitNewWebpage(String webpage){
    browserHistory.Push(webpage);
    Console.WriteLine($"\nVisited: {webpage}");
}

void GoBack(){
    string back = browserHistory.Pop();
    Console.WriteLine($"\nWent Back From: {back} To {browserHistory.Peek()}"); 
}

void ViewCurrentPage(){
    Console.WriteLine($"\nCurrent Page: {browserHistory.Peek()}");
}

void DisplayBrowsingHistory(){
    Console.WriteLine("\nBrowsing History:\n");
    foreach (string webpage in browserHistory)
        Console.WriteLine(webpage);
}

PrintMenu();

bool exit = true;

int choice = InputHandler();

while (exit){

    switch (choice){
        case 0:
            choice = InputHandler();
            continue;
        case 1:
            Console.Write("Enter The Webpage To Visit: ");
            String webpage = Console.ReadLine() ?? "";
            VisitNewWebpage(webpage);
            break;

        case 2:
            GoBack();
            break;

        case 3:
            ViewCurrentPage();
            break;

        case 4:
            DisplayBrowsingHistory();
            break;

        case 5:
            Console.WriteLine("\nExiting Application...");
            exit = false;
            break;

        default:
            Console.WriteLine("\nEnter a Valid Operation.");
            break;
    }

    if (exit) {
        Console.Write("\nPress Enter To Access Full Menu " + "Or Enter a Number To Continue: ");
        string input = Console.ReadLine() ?? "";

        if (string.IsNullOrEmpty(input)) {
            PrintMenu();
            choice = 0;
        }

        else if (int.TryParse(input, out int number)){
            switch (number) {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                    choice = number;
                    break;

                default:
                    Console.WriteLine("\nPlease Enter Valid Menu Number.");
                    break;
            }
        }

        else
            Console.WriteLine("\nPlease Enter Valid Number.");
    }
}