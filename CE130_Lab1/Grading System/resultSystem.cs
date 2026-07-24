using System.Collections;
using System.Reflection.Metadata;

List<int> marks =  new List<int>();

int obtainedMarks = 0;
for(int i = 0; i < 5; i++){
    Console.WriteLine("Enter Marks of Subject " + (i+1));
    marks.Add(Convert.ToInt32(Console.ReadLine()));
    obtainedMarks += marks[i];
}

int percentage = obtainedMarks / 5;

String grade;

if(percentage >= 90)
    grade = "A+";
else if (percentage >= 80 && percentage < 90)
    grade = "A";
else if(percentage >= 70 && percentage < 80)
    grade = "B";
else if (percentage >= 60 && percentage < 70)
    grade = "C";
else if (percentage >= 50 && percentage < 60)
    grade = "D";
else
    grade = "F";

Console.WriteLine("Obtained Marks: " + obtainedMarks);
Console.WriteLine("\nPercentage: " + percentage + "%");
Console.WriteLine("Grade: " + grade);