using System;

class Program
{
    // static void Main(string[] args)
    // {
    //     Console.WriteLine("Hello Prep1 World!");
    // }


    static void Main(string[] args)
    {
        // The actual assignment
        bool doAssignment = true;
        if (doAssignment == true)
        {
            Console.Write("What is your first name? ");
            string firstName = Console.ReadLine().Trim(['.', '!', '?']);
            Console.Write("What is your last name? ");
            string lastName = Console.ReadLine().Trim(['.', '!', '?']);
            Console.WriteLine();
            Console.WriteLine($"Your name is {lastName}, {firstName} {lastName}.");

        }
        else
        // Messing around with things before I see the assignment
        {
            Console.WriteLine("Wha- Who are you??");
            string name = Console.ReadLine().Trim(['.', '!', '?']);
            if (name == "Abigail")
            {
                Console.WriteLine("Oh, it's you.");
            }
            else
            {
                Console.WriteLine($"{name}, what an odd name.");
            }
        }
    }

    // The actual assignment

}