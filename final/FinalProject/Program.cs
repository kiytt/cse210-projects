using System;

class Program
{
    static void Main(string[] args)
    {
        Menu menu = new Menu();

        menu.AddOption($"{menu.Next()}. \x1b[4mI\x1b[24mnteraction validation", new string[] {"interaction validation", "interaction", "i", $"{menu.Current()}"});
        menu.AddOption($"{menu.Next()}. \x1b[4mP\x1b[24marticle lookup", new string[] {"particle lookup", "particle", "p","lookup", $"{menu.Current()}"});
        menu.AddOption($"{menu.Next()}. \x1b[4mQ\x1b[24muit", new string[] {"quit", "q", $"{menu.Current()}"});

        string choice = "";

        while (choice != "quit")
        {
            choice = menu.GetChoice();

            if (choice == "interaction validation") // from old testing
            {
                Console.WriteLine("Interaction validation");
                Thread.Sleep(1000*1);
                
                Validate validate = new Validate("photon electron", "photon electron");
                Console.WriteLine(validate.MediatingForce());

                Console.ReadLine();
            }
            else if (choice == "particle lookup")
            {
                Console.WriteLine("Particle Lookup");
                Thread.Sleep(1000*1);

                Menu lookupMenu = new Menu();
                lookupMenu.AddOption($"{lookupMenu.Next()}. \x1b[4mS\x1b[24mearch", new string[] {"search", "s", $"{lookupMenu.Current()}"});
                lookupMenu.AddOption($"{lookupMenu.Next()}. \x1b[4mA\x1b[24mdd particle", new string[] {"add", "a", $"{lookupMenu.Current()}"});
                lookupMenu.AddOption($"{lookupMenu.Next()}. \x1b[4mQ\x1b[24muit", new string[] {"quit", "q", $"{lookupMenu.Current()}"});

                string lookupChoice = "";

                while (lookupChoice != "quit")
                {
                    lookupChoice = lookupMenu.GetChoice();
                    if (lookupChoice == "search")
                    {
                        {
                        Console.Write("Search by (name, charge, classification):\n> ");
                        string field = Console.ReadLine();
                        Console.Write("Search for:\n> ");
                        string query = Console.ReadLine();

                        ParticleDatabase db = new ParticleDatabase();
                        List<string> matches = db.Find(field, query.Trim().ToLower());

                        if (matches.Count > 0)
                        {
                            foreach (string match in matches)
                            {
                                Console.WriteLine("\n----------------------------------------");
                                foreach (string kv in match.Split(','))
                                {
                                    string[] parts = kv.Split(':');
                                    if (parts.Length == 2)
                                    {
                                        Console.WriteLine($"  {parts[0].Trim(),-16} : {parts[1].Trim()}");
                                    }
                                }
                                Console.WriteLine("----------------------------------------");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No match found.");
                        }
                        Console.ReadLine();
                        }
                    }
                    else if (lookupChoice == "add")
                    {
                        Console.WriteLine("Enter information:\n");
                        Console.Write("Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Charge: ");
                        string charge = Console.ReadLine();
                        Console.Write("Spin: ");
                        string spin = Console.ReadLine();
                        Console.Write("Mass (MeV): ");
                        string mass = Console.ReadLine();
                        Console.Write("Classification: ");
                        string classification = Console.ReadLine();
                        Console.Write("Interacts with these forces (i.e. electromagnetism weak): ");
                        string interactsWith = Console.ReadLine();
                        Console.Write("Is an antiparticle (i.e. false): ");
                        string isAntiparticle = Console.ReadLine();
                        Console.Write("Constituents: (i.e. none or uds): ");
                        string constituents = Console.ReadLine();
                        Console.Write("Baryon Number: ");
                        string baryonNumber = Console.ReadLine();
                        Console.Write("Lepton Number: ");
                        string leptonNumber = Console.ReadLine();

                        string rawLine = $"name:{name},charge:{charge},spin:{spin},mass:{mass},classification:{classification},interactsWith:{interactsWith},isAntiparticle:{isAntiparticle},constituents:{constituents},baryonNumber:{baryonNumber},leptonNumber:{leptonNumber}";

                        if (!string.IsNullOrWhiteSpace(rawLine))
                        {
                            ParticleDatabase db = new ParticleDatabase();
                            db.Save(rawLine.Trim());
                            Console.WriteLine("Saved to database.");
                        }
                        Console.ReadLine();
                    }
                    
                }

            }
        }
    }
}
