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
                break;
            }

            // List options
            var quotes = library.GetQuotes();
            Console.Clear();

            for (int i = 0; i < quotes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {quotes[i].GetDisplayText().Split('\n')[0]}");
            }

            Console.Write($"\nEnter number\n> ");
            int index = int.Parse(Console.ReadLine());
            Console.Clear();

            Quote quote = quotes[index - 1];

            string input = "";

            // do the erasure thing
            while (input != "q")
            {
                Console.Clear();
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