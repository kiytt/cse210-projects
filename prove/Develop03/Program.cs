using System;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello Develop03 World!");

        Library library = new Library();

        string option = "";

        while (option != "q")
        {
            // main menu
            Console.Clear();

            Console.Write("\x1b[4mC\x1b[24mhoose | \x1b[4mQ\x1b[24muit\n> ");

            option = Console.ReadLine().ToLower();

            if (option == "q")
            {
                Console.Clear();
                break;
            }

            // List options
            var quotes = library.GetQuotes();
            Console.Clear();

            Console.WriteLine("\nChoose\n");

            for (int i = 0; i < quotes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {quotes[i].GetDisplayText().Split('\n')[0]}");
            }

            Console.Write($"\nEnter number\n> ");
            int index = int.Parse(Console.ReadLine());

            // FORCE the terminal to reset ALL THE WAY
            Console.Clear();
            Console.WriteLine("\x1b[3J\x1b[H"); // I have tried everything. And finally, like the sun rising over the hills, something that actually works!

            Quote quote = quotes[index - 1];

            string input = "";

            // do the erasure thing
            while (input != "q")
            {
                // Console.Clear();
                Console.WriteLine(quote.GetDisplayText());

                // Check if fully hidden
                if (quote.IsCompletelyHidden())
                {
                    Console.Clear();
                    Console.Write("\x1b[4mR\x1b[24medo | \x1b[4mQ\x1b[24muit\n> ");
                    string answer = Console.ReadLine().ToLower();

                    if (answer == "q")
                    {
                        quote.Reset();
                        break;
                    }
                    else if (answer == "r")
                    {
                        quote.Reset();
                        continue; 
                    }
                    continue;
                }

                input = Console.ReadLine().ToLower();
                Console.Clear();

                if (input == "q") 
                {
                    quote.Reset();
                    break; 
                }

                int numToHide;

                if (input == "") 
                {
                    numToHide = 3;
                }
                else
                {
                    numToHide = int.Parse(input);
                }

                quote.RemoveWords(numToHide);
            }
        }
    }
}