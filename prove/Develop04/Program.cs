using System;

class Program
{
    static void Main(string[] args)
    {
        Menu menu = new Menu(); // I find this syntax amusing

        menu.AddOption("1. Start \x1b[4mb\x1b[24mreathing activity", new string[] {"breathe", "b", "1"});
        menu.AddOption("2. Start \x1b[4mr\x1b[24meflecting activity", new string[] {"reflect", "r", "2"});
        menu.AddOption("3. Start \x1b[4ml\x1b[24misting activity", new string[] {"list", "l", "3"});
        menu.AddOption("4. \x1b[4mO\x1b[24mptions", new string[] {"options", "o", "4"});
        menu.AddOption("5. Start \x1b[4mq\x1b[24muitting activity", new string[] {"quit", "q", "5"}); // i am hilarious
        menu.AddOption("", new string[] {"abigail why did you do this"}); // pay no mind

        string choice = "";

        while (choice != "quit")
        {
            choice = menu.GetChoice();

            if (choice == "breathe")
            {
                Menu breathingMenu = new Menu();
                breathingMenu.AddOption("1. \x1b[4mB\x1b[24mox breathing", new string[] {"box", "b", "1"});
                breathingMenu.AddOption("2. \x1b[4mI\x1b[24mnhale/exhale", new string[] {"inhale exhale", "i", "2", "inhale", "ie"});
                breathingMenu.AddOption("3. \x1b[4mA\x1b[24msymmetric", new string[] {"asymmetric", "a", "3", "asym"});
                breathingMenu.AddOption("4. \x1b[4mR\x1b[24meturn", new string[] {"return", "r", "4"});

                string breathingChoice = "";

                while (breathingChoice != "return")
                {
                    breathingChoice = breathingMenu.GetChoice();

                    if (breathingChoice == "return")
                    {
                        break;
                    }
                    else
                    {
                        BreathingActivity breathing = new BreathingActivity(breathingChoice);
                        breathing.Start();
                        breathing.Prepare("Still the beating of thy heart", 3, new Spinner("bar", 200));
                        breathing.Run();
                        breathing.End(4, new Spinner("oh", 250));
                    }
                }
            }
            else if (choice == "reflect")
            {
                ReflectionActivity reflecting = new ReflectionActivity();
                reflecting.Start();
                reflecting.Prepare("Steel thy nerves", 3, new Spinner("bar", 200));
                reflecting.Run();
                reflecting.End(4, new Spinner("dots", 250));
            }
            else if (choice == "list")
            {
                ListingActivity listing = new ListingActivity();
                listing.Start();
                listing.Prepare("Prepare thyself", 3, new Spinner("bar", 200));
                listing.Run();
                listing.End(4, new Spinner("wait", 250));
            }
            else if (choice == "options")
            {
                string optionsChoice = "";

                Console.Clear();
                Menu options = new Menu();
                options.AddOption("1. Edit reflection \x1b[4mp\x1b[24mrompts", new string[] {"prompts", "p", "1"});
                options.AddOption("2. Edit reflection \x1b[4mq\x1b[24muestions", new string[] {"questions", "q", "2"});
                options.AddOption("3. Edit \x1b[4ml\x1b[24misting prompts", new string[] {"listing", "l", "3"});
                options.AddOption("4. \x1b[4mR\x1b[24meturn", new string[] {"return", "r", "4"});

                optionsChoice = "";

                while (optionsChoice != "return")
                {
                    optionsChoice = options.GetChoice();

                    if (optionsChoice == "prompts")
                    {
                        new PromptGen("ReflectionPrompts/prompts.txt").RunEditor();
                    }
                    else if (optionsChoice == "questions")
                    {
                        new PromptGen("ReflectionPrompts/questions.txt").RunEditor();
                    }
                    else if (optionsChoice == "listing")
                    {
                        new PromptGen("ListingPrompts/prompts.txt").RunEditor();
                    }                                        
                }
            }
            else if (choice == "abigail why did you do this")
            {
                new Spinner("raven", 1500).PlayAllFrames();
            }
            else if (choice == "quit")
            {
                Console.WriteLine("Quitting.");
            }
        }
    }
}