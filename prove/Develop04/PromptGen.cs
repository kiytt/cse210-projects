using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Enumeration;
using System.Runtime.InteropServices;


public class PromptGen // new and improved (mostly the same but it uses Menu now and allows for different file names)
{
    // Attributes
    string _filename = "prompts.txt";
    public List<string> _prompts = new List<string>();

    // Constructor
    public PromptGen(string filename)
    {
        _filename = filename;
        LoadPrompts();
    }

    // Methods

    // Random prompt selection
    public string GetRandom()
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
        LoadPrompts();
    }

    public void RemovePrompt()
    {
        int increment = 5;
        int i = 0;
        string choice = "";

        while (choice != "return")
        {
            Menu menu = new Menu();

            // add items for the current page
            int startIndex = i;
            int endIndex = Math.Min(i + increment, _prompts.Count);

            for (int j = startIndex; j < endIndex; j++)
            {
                int displayNum = (j - i) + 1;
                menu.AddOption($"{displayNum}. {_prompts[j]}", new string[] { displayNum.ToString() });
            }

            // menu nav
            menu.AddOption("\x1b[4mN\x1b[24mext", new string[] { "next", "n" });
            menu.AddOption("\x1b[4mP\x1b[24mrevious", new string[] { "previous", "prev", "p" });
            menu.AddOption("\x1b[4mR\x1b[24meturn", new string[] { "return", "r" });

            choice = menu.GetChoice();

            if (choice == "next")
            {
                if (i + increment < _prompts.Count)
                {
                    i += increment;
                }
            }
            else if (choice == "previous")
            {
                if (i - increment >= 0)
                {
                    i -= increment;
                }
                else
                {
                    i = 0;
                }
            }
            else if (choice != "return")
            {
                // number choice representing the index relative to current page
                int selectedIndex = i + int.Parse(choice) - 1;
                if (selectedIndex < _prompts.Count)
                {
                    _prompts.RemoveAt(selectedIndex);

                    // adjust index if deleted the last item on a page
                    if (i >= _prompts.Count && i > 0)
                    {
                        i -= increment;
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
        }
    }

    public void LoadPrompts()
    {
        _prompts = new List<string>(System.IO.File.ReadAllLines(_filename));
    }

    public void RunEditor() // annoying to implement in main so made thing here
    {
        string choice = "";
        while (choice != "return")
        {
            Console.Clear();
            Menu menu = new Menu();
            menu.AddOption("\x1b[4mA\x1b[24mdd prompt", new string[] { "add", "a", "1" });
            menu.AddOption("\x1b[4mD\x1b[24melete prompt", new string[] { "delete", "d", "2" });
            menu.AddOption("\x1b[4mR\x1b[24meturn", new string[] { "return", "r", "3" });

            choice = menu.GetChoice();

            if (choice == "add")
            {
                AddPrompt();
            }
            else if (choice == "delete")
            {
                RemovePrompt();
            }
        }
    }
}
