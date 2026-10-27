using System;
using System.Diagnostics.Tracing;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Menu menu = new Menu();

        menu.AddOption($"{menu.Next()}. \x1b[4mI\x1b[24mnteraction validation", new string[] {"interaction validation", "interaction", "i", $"{menu.Current()}"});
        menu.AddOption($"{menu.Next()}. \x1b[4mP\x1b[24marticle lookup", new string[] {"particle lookup", "particle", "p","lookup", $"{menu.Current()}"});
        menu.AddOption($"{menu.Next()}. \x1b[4mQ\x1b[24muit", new string[] {"quit", "q", $"{menu.Current()}"});

        string choice = "";

        while (choice != "quit")
        {
            choice = menu.GetChoice();
            Console.Clear();

            if (choice == "interaction validation") // from old testing
            {
                Console.WriteLine("Interaction validation\n");
                
                Validate validate = new Validate();
                Console.WriteLine("Input like: particle1 particle2 -> particle3 particle4\n");
                // Console.Write("Initial particles: ");
                // string initialParticles = Console.ReadLine();
                // Console.Write("Final particles: ");
                // string finalParticles = Console.ReadLine();
                string initialParticles = Console.ReadLine();
                Console.Write($"\x1b[1A\x1b[2K\x1b[1G{initialParticles} -> ");  // esc is \x1b / [1A is move cursor up one line / [2K is erase entire line / [1G is move cursor to first column (start of line)
                // noting this here so I stop haveing to look it up https://gist.github.com/fnky/458719343aabd01cfb17a3a4f7296797
                string finalParticles = Console.ReadLine();
                Console.WriteLine(validate.MediatingForce(initialParticles, finalParticles));

                Console.ReadLine();
            }
            else if (choice == "particle lookup")
            {
                Console.WriteLine("Particle Lookup\n");

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
                        ParticleDatabase db = new ParticleDatabase();

                        Console.Write("Search by (name, charge, classification, all, etc.):\n> ");
                        string field = Console.ReadLine();

                        List<Particle> entries = new List<Particle>();

                        if (field == "all")
                        {
                            entries = db.ListAll();
                        }
                        else
                        {
                            Console.Write("Search for:\n> ");
                            string query = Console.ReadLine();
                            entries = db.Find(field, query);
                        }

                        if (entries.Count > 0)
                        {
                            Console.WriteLine("\n----------------------------------------");
                            foreach (Particle p in entries)
                            {
                                foreach (string kv in p.GetRawLine().Split(','))
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
                    Console.Clear();
                    }
                    else if (lookupChoice == "add")
                    {
                        Console.Write("Classification: ");
                        string classification = Console.ReadLine().Trim().ToLower();

                        string rawLine = "";
                        if (classification == "scalarboson")
                        {
                            rawLine = ScalarBoson.PromptAndBuild();
                        }
                        else if (classification == "gaugeboson")
                        {
                            rawLine = GaugeBoson.PromptAndBuild();
                        }
                        else if (classification == "lepton")
                        {
                            rawLine = Lepton.PromptAndBuild();
                        }
                        else if (classification == "baryon")
                        {
                            rawLine = Baryon.PromptAndBuild();
                        }
                        else if (classification == "meson")
                        {
                            rawLine = Meson.PromptAndBuild();
                        }
                        else if (classification == "quark")
                        {
                            rawLine = Quark.PromptAndBuild();
                        }
                        else
                        {
                            rawLine = null;
                        }

                        ParticleDatabase db = new ParticleDatabase();
                        if (!string.IsNullOrEmpty(rawLine))
                        {
                            db.Save(rawLine);
                        }
                    }
                    
                }

            }
        }
    }
}
