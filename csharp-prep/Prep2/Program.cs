using System;
using System.Diagnostics.Tracing;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please read this in Terry Gilliam's voice.");
        Console.WriteLine("Cloaked figure: WHAT is your grade (as a percentage)?");
        string userInput = Console.ReadLine();
        int grade = int.Parse(userInput);

        string success = "Right, you pass. Off you go.";
        string failure = "Cloaked figure: ...\nYou: AUGHHHH!!"; // I mean, I'd find my friend getting thrown into the Gorge of Eternal 
                                                                //  Peril to be rather good motivation to do better.
        string letter = "";
        string message = "";

        if (grade >= 70)
        {
            message = success;

            if (grade >= 90)
            {
            letter = "A";
            }
            else if (grade >= 80)
            {
            letter = "B";
            }
            else
            {
            letter = "C";
            }
        }
        else if (grade < 70)
        {
            message = failure;

            if (grade >= 60)
            {
            letter = "D";
            }
            else
            {
            letter = "F";
            }
        }

        // Begin stretch
        if (grade < 97 && grade > 53)
        {
            if (grade%10 >= 7 && grade/10 != 5)
            {
                letter += "+";
            }
            else if (grade%10 <= 3)
            {
                letter += "-";
            }
        }

        // End stretch

        Console.WriteLine($"Your grade is {letter}");
        Console.WriteLine(message);
    }
}