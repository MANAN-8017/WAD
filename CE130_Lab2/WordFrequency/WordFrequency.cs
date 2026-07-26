using System;
using System.Collections.Generic;

static string InputHandler()
{
    string input = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(input))
    {
        Console.Write("Enter a valid input: ");
        return InputHandler();
    }
    return input;
}

Console.WriteLine("Check The Frequency of Words in a String");

bool exit = true;

Console.Write("\nEnter a string: ");
string input = InputHandler();
while(exit) {
    Dictionary<string, int> wordFrequency = new Dictionary<string, int>();

    string[] words = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

    foreach (string w in words) {
        string lowerWord = w.ToLower();

        if (wordFrequency.ContainsKey(lowerWord))
            wordFrequency[lowerWord]++;
        else
            wordFrequency.Add(lowerWord, 1);
    }
    Console.WriteLine("");

    foreach (KeyValuePair<string, int> kvp in wordFrequency)
        Console.WriteLine($"Word: {kvp.Key}, Frequency: {kvp.Value}");

    Console.Write("\nEnter input or exit by pressing 'N': ");
    input = InputHandler();
    if (input == "n" || input == "N")
        exit = false;
}