using System;
using System.Collections.Generic;

void PrintMenu(){
    Console.WriteLine(
        "\nStudent Management Menu:\n"
        + "\n1. Search Student Name"
        + "\n2. Display Student Names"
        + "\n3. Add Student Name"
        + "\n4. Update Student Name"
        + "\n5. Delete Student Name"
        + "\n6. Exit Application\n"
    );
}

List<string> names = new List<string> { "Manan", "Sam", "Jay", "Ved", "Sanghani", "Shiv", "Prit" };

names.Sort();

int InputHandler(){
    while (true){
        Console.Write("Enter a Number: ");

        string input = Console.ReadLine() ?? "";

        if (int.TryParse(input, out int number))
            return number;

        Console.WriteLine("\nPlease Enter a Valid Number.\n");
    }
}

bool SearchStudentName(string name){
    if (string.IsNullOrWhiteSpace(name))
        return false;

    foreach (var student in names)
        if (student.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0)
            return true;
    return false;
}

void DisplayStudentNames(){
    if (names.Count == 0){
        Console.WriteLine("\nStudent List is Empty!");
        return;
    }

    for (int i = 0; i < names.Count; i++)
        Console.WriteLine($"{i + 1}. {names[i]}");
}

void AddStudentName(string name){
    if (string.IsNullOrWhiteSpace(name)){
        Console.WriteLine("\nStudent Name Cannot Be Empty!");
        return;
    }

    names.Add(name);
    names.Sort();

    Console.WriteLine($"\n{name} Successfully Added!");
}

void UpdateStudentName(string oldName, string newName){
    int index = names.FindIndex(name => name.Equals(oldName, StringComparison.OrdinalIgnoreCase));

    if (index == -1){
        Console.WriteLine("\nStudent Name Not Found!");
        return;
    }

    if (string.IsNullOrWhiteSpace(newName)){
        Console.WriteLine("\nNew Student Name Cannot Be Empty!");
        return;
    }

    names[index] = newName;
    names.Sort();

    Console.WriteLine("\nStudent Name Updated Successfully!");
}

void DeleteStudentName(string name){
    int index = names.FindIndex( studentName => studentName.Equals( name, StringComparison.OrdinalIgnoreCase ));

    if (index == -1){
        Console.WriteLine("\nStudent Name Not Found!");
        return;
    }

    names.RemoveAt(index);

    Console.WriteLine("\nStudent Name Deleted Successfully!");
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
            Console.Write("Enter The Student Name To Search: ");

            string name = Console.ReadLine() ?? "";
            if (SearchStudentName(name))
                Console.WriteLine($"\n{name} Found In The List.");
            else 
                Console.WriteLine("\nStudent Name Not Found In The List.");
            break;

        case 2:
            Console.WriteLine("\nStudent Name List:");
            DisplayStudentNames();
                break;

        case 3:
            Console.Write("\nEnter The Student Name To Add: ");
            name = Console.ReadLine() ?? "";

            AddStudentName(name);
            break;

        case 4:
            Console.Write("\nEnter The Student Name To Update: ");
            string oldName = Console.ReadLine() ?? "";
            if (!SearchStudentName(oldName)){
                Console.WriteLine("\nStudent Name Not Found In The List.");
                break;
            }
            Console.Write($"Enter The New Student Name For {oldName}: ");
            string newName = Console.ReadLine() ?? "";

            UpdateStudentName(oldName, newName);
            break;

        case 5:
            Console.Write("\nEnter The Student Name To Delete: ");
            name = Console.ReadLine() ?? "";
            
            Console.Write("Press Y to confirm: ");
            string confirmationInput = Console.ReadLine() ?? "";

            if (confirmationInput.Length > 0 && ( confirmationInput[0] == 'y' || confirmationInput[0] == 'Y'))
                DeleteStudentName(name);
            else
                Console.WriteLine("\nStudent Name Deletion Cancelled!");
            break;

        case 6:
            Console.WriteLine("\nExiting Application...");
            exit = false;
            break;

        default:
            Console.WriteLine("\nEnter Valid Operation.");
            break;
    }

    if (exit){
        Console.Write("\nPress Enter To Access Full Menu " + "Or Enter a Number To Continue: ");
        string input = Console.ReadLine() ?? "";

        if (string.IsNullOrEmpty(input)){
            PrintMenu();
            choice = 0;
        }

        else if (int.TryParse(input, out int number))
            switch (number){
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

        else
            Console.WriteLine("\nPlease Enter Valid Number.");
    }
}