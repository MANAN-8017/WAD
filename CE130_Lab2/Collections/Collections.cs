using System;
using System.Collections.Generic;

List<int> numbersList = new List<int>{
    10,
    20,
    30,
    40,
    50
};

Console.WriteLine("List:\n");

foreach (int number in numbersList)
    Console.WriteLine(number);

Stack<int> numbersStack = new Stack<int>();

numbersStack.Push(10);
numbersStack.Push(20);
numbersStack.Push(30);
numbersStack.Push(40);
numbersStack.Push(50);

Console.WriteLine("\nStack:\n");

while (numbersStack.Count > 0)
    Console.WriteLine(numbersStack.Pop());

Queue<int> numbersQueue = new Queue<int>();

numbersQueue.Enqueue(10);
numbersQueue.Enqueue(20);
numbersQueue.Enqueue(30);
numbersQueue.Enqueue(40);
numbersQueue.Enqueue(50);

Console.WriteLine("\nQueue:\n");

while (numbersQueue.Count > 0)
    Console.WriteLine(numbersQueue.Dequeue());

Dictionary<int, int> numbersDictionary = new Dictionary<int, int>{
    { 1, 10 },
    { 2, 20 },
    { 3, 30 },
    { 4, 40 },
    { 5, 50 }
};

Console.WriteLine("\nDictionary:\n");

foreach (KeyValuePair<int, int> item in numbersDictionary)
    Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");