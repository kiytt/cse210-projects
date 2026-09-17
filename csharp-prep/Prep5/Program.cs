using System;

class Program
{
    // Functions
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());
        return number;
    }

    static void PromptUserBirthYear(out int year)
    {
        Console.Write("Please enter your birth year: ");
        year = int.Parse(Console.ReadLine());
    }

    static int SquareNumber(int number)
    {
        return number * number;
    }

    static void DisplayResult(string name, int squaredNum, int birthYear)
    {
        Console.WriteLine($"{name}, your favorite number squared is {squaredNum}.");
        Console.WriteLine($"{name}, you will turn (or are) {DateTime.Now.Year - birthYear} this year.");
    }

    static void Main(string[] args)
    {

        DisplayWelcome();

        string name = PromptUserName();
        int favNum = PromptUserNumber();
        PromptUserBirthYear(out int birthYear);
        int squaredNum = SquareNumber(favNum);

        DisplayResult(name, squaredNum, birthYear);

    }
}