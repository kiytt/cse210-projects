using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;


public class PromptGenerator
{
    // Attributes
    string _filename = "prompts.txt";
    public List<string> _prompts = new List<string>();

    // Constructor // what even is this for
    public PromptGenerator()
    {
        LoadPrompts(); // Oh, THAT'S what this thing is for! Yay, no PromptGenerator.LoadPrompts()!
    }

    // Methods

    // Random prompt selection
    public string GetRandomPrompt()
    {
        Random random = new Random();
        int promptIndex = random.Next(_prompts.Count);
        return _prompts[promptIndex];
    }

    public void AddPrompt()
    {   
        // write
        using (StreamWriter outputFile = new StreamWriter(_filename, true)) // so true makes it not overwrite the file.. nice to know :/
        {
            Console.WriteLine("Enter 'q' to stop.");
            string input = Console.ReadLine();

            while (input != "q")
            {
                outputFile.WriteLine(input);
                input = Console.ReadLine();
            }
        }
        LoadPrompts(); // so funny thing, i forgot to update it in memory // only realized once I wrote the parser for remove, lol
    }

    public void RemovePrompt()
    {
        int increment = 5;
        // Console.WriteLine("\nNescit vox missa reverti.");  
        // Console.WriteLine("Ok fine. You win. I'll do it.");  
        string input = "";
        int i = 0;
        do
        {
            Console.WriteLine("\n\x1b[4mN\x1b[24mext\n\x1b[4mP\x1b[24mrevious\n\x1b[4mQ\x1b[24muit");

            for (int j = 1; j<=increment && (i + j - 1) < _prompts.Count(); j++)
            {
                Console.WriteLine($"{j}. {_prompts[i + j - 1]}");
            }

            input = Console.ReadLine();

            if (input == "n")
            {
                if (i + increment > _prompts.Count())
                {
                    if (_prompts.Count() < increment)
                    {
                        i = 0; // so you can remove too many prompts..
                    }
                    else
                    {
                        i = _prompts.Count - increment;
                    }
                }
                else
                {
                    i += increment;
                }
            }
            else if (input == "p")
            {
                if (i - increment < 0)
                {
                    i = 0;
                }
                else
                {
                    i -= increment;
                }
            }
            else if (input == "1" || input == "2" || input == "3" || input == "4" || input == "5")
            {
                int index = i + int.Parse(input) - 1; // i gets to that 5, int.Parse(input) to which of 5, - 1 for offset starting at 1 not 0
                if (index < _prompts.Count())
                {
                    _prompts.RemoveAt(index);

                    if (i >= _prompts.Count() && i > 0)
                    {
                        i -= increment; // and you can get OOB if deleting the only (last) entry on page
                    }
                }
                else
                {
                    Console.WriteLine("Invalid.");
                }
                using (StreamWriter outputFile = new StreamWriter(_filename))
                {
                    foreach (string line in _prompts)
                    {
                        outputFile.WriteLine(line);

                    }
                }
            }
        }
        while (input != "q");
    }

    public void LoadPrompts()
    {
        _prompts = new List<string>(System.IO.File.ReadAllLines(_filename));
    }
}
