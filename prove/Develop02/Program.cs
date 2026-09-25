using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.IO.Enumeration;
using System.ComponentModel;
class Program
{
    static void Main(string[] args)
    {
        // Well, no one's replying to me. Guess I'm on my own.

        // Initialization
        PromptGenerator promptGen = new PromptGenerator();
        Journal journal = new Journal();

        // Menu
        // LOOK WHAT I FOUND I CAN UNDERLINE STUFF WOW \x1b[4m \x1b[24m
        // that is hard to read. Even using WriteLine instead of \n doesn't help much.
        Console.WriteLine("\n1 \x1b[4mW\x1b[24mrite");
        Console.WriteLine("2 \x1b[4mD\x1b[24misplay");
        Console.WriteLine("3 \x1b[4mL\x1b[24moad");
        Console.WriteLine("4 \x1b[4mS\x1b[24mave");
        Console.WriteLine("5 \x1b[4mE\x1b[24mdit prompts");
        Console.WriteLine("6 \x1b[4mQ\x1b[24muit");
        Console.Write("\n> ");

        string option = Console.ReadLine();

        while (option != "6" && option != "Quit" && option != "quit" && option != "q")
        {
            Console.WriteLine();

            if (option == "1" || option == "Write" || option == "write" || option == "w")
            {
                Entry newEntry = new Entry();
                newEntry.WriteEntry(promptGen.GetRandomPrompt());
                journal._entries.Add(newEntry);
            }
            else if (option == "2" || option == "Display" || option == "display" || option == "d")
            {
                journal.Display();
            }
            else if (option == "3" || option == "Load" || option == "load" || option == "l")
            {
                string filename = journal.Load();
                Console.WriteLine($"Loaded: {filename}");
            }
            else if (option == "4" || option == "Save" || option == "save" || option == "s")
            {
                string filename = journal.Save();
                Console.WriteLine($"Saved as: {filename}");
            }
            else if (option == "5" || option == "Edit prompts" || option == "edit prompts" || option == "e")
            {
                Console.Write("\x1b[4mA\x1b[24mdd or \x1b[4mr\x1b[24memove prompts?\n> ");
                string operation = Console.ReadLine();
                if (operation == "add" || operation == "Add" || operation == "a")
                {
                    promptGen.AddPrompt();
                }
                else
                {
                    promptGen.RemovePrompt();
                }
            }

        Console.WriteLine("\n1 \x1b[4mW\x1b[24mrite");
        Console.WriteLine("2 \x1b[4mD\x1b[24misplay");
        Console.WriteLine("3 \x1b[4mL\x1b[24moad");
        Console.WriteLine("4 \x1b[4mS\x1b[24mave");
        Console.WriteLine("5 \x1b[4mE\x1b[24mdit prompts");
        Console.WriteLine("6 \x1b[4mQ\x1b[24muit");
        Console.Write("\n> ");

        option = Console.ReadLine();
        }

    }
}