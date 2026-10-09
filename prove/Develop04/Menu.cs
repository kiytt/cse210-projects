using System;

public class Menu
{
    // This is the first thing I've built that I hope is truly reusable. As such:

    // HEY ME
    // I KNOW YOU'VE FORGOTTEN HOW THIS WORKS

    // CREATE MENU OBJECT
    // menu.AddOption("ITEM IN MENU LIST", new string[] {"ALIAS 1", "ALIAS 2"}); // THIS WILL RETURN "ALIAS 1"
    // CHOICE IS AN EMPTY STRING
    //     WHILE CHOICE AIN'T THE QUITTING OPTION
    //     {
    //         choice = menu.GetChoice();
    //         IF CHOICE IS THE FIRST ALIAS IN THE ALIASES LIST
    //         {
    //             DO THAT
    //         }
    // ELSE IFS DOWN TO AN ELSE THATS BASICALLY LIKE - WHAT ARE YOU DOING WITH YOUR LIFE INPUT A VALID OPTION

    // Attributes/member variables
    private List<string> _displayNames = new List<string>();
    private List<string[]> _aliases = new List<string[]>(); // string[] array of strings

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
}