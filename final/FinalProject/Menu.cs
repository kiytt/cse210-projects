using System;

public class Menu
{
    // Attributes/member variables
    private List<string> _displayNames = new List<string>();
    private List<string[]> _aliases = new List<string[]>(); // string[] array of strings
    private int _current = 1;

    // Constructors
    public Menu(){}

    
    // Methods
    public void AddOption(string displayName, string[] aliases) // have to input aliases as new string[] {}
    {
        _displayNames.Add(displayName);
        _aliases.Add(aliases);
    }

    public string GetChoice() // returns first alias in aliases array
    {
        while (true)
        {
            // Console.WriteLine();
            Console.Clear();

            for (int i = 0; i < _displayNames.Count(); i++) // for all display names
            {
                Console.WriteLine(_displayNames[i]);
            }
            Console.Write("> ");
            string input = Console.ReadLine().Trim().ToLower();
            
            for (int i = 0; i < _aliases.Count(); i++) // for all groups of aliases
            {
                foreach (string alias in _aliases[i]) // for each alias per group (array) of aliases
                {
                    if (input == alias.ToLower()) // if the user input is one of the aliases in a group (still an array)
                    {
                        Console.Clear();
                        return _aliases[i][0]; // return the first alias in that group (...)
                    }
                }

            }
            Console.Clear();
            Console.WriteLine("Invalid option. Press any key to continue.");
            Console.ReadLine();
        }

    }

    // manual iterations of enumerated lists was getting repetitive
    public int Next() 
    {
        return _current++;
    }
    
    public int Current() 
    {
        return _current-1;
    }
}