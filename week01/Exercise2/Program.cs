using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise2 Project.");

        Console.Write("What is your grade percentage? ");
        string input = Console.ReadLine();

        int grade = int.Parse(input);

        string letter = "";
        string message = "";
        string sign = "";

        // Determine letter grade and message
        if (grade >= 90)
        {
            letter = "A";
            message = "Congrats! you passed the course!";
        }
        else if (grade >= 80)
        {
            letter = "B";
            message = "Congrats! you passed the course!";
        }
        else if (grade >= 70)
        {
            letter = "C";
            message = "Congrats! you passed the course!";
        }
        else if (grade >= 60)
        {
            letter = "D";
            message = "We encourage you to try again this course.";
        }
        else
        {
            letter = "F";
            message = "We encourage you to try again this course.";
        }

        // Determine the sign (except for A+ or F+/-)
        int lastDigit = grade % 10;

        if (letter != "A" && letter != "F") // A+ is not valid, F+/- is not valid
        {
            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
        }
        else if (letter == "A" && lastDigit < 3)
        {
            sign = "-"; // A- is valid
        }

        // Output result
        Console.WriteLine($"You have a {letter}{sign} score");
        Console.WriteLine(message);
    }
}
