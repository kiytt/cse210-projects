using System;

class Program
{
    static void Main(string[] args)
    {
        Menu menu = new Menu(); // I find this syntax amusing

        menu.AddOption("1. Start \x1b[4mb\x1b[24mreathing activity", new string[] {"breathe", "b", "1"});
        menu.AddOption("2. Start \x1b[4mr\x1b[24meflecting activity", new string[] {"reflect", "r", "2"});
        menu.AddOption("3. Start \x1b[4ml\x1b[24misting activity", new string[] {"listen", "l", "3"});
        menu.AddOption("4. Start \x1b[4mq\x1b[24muitting activity", new string[] {"quit", "q", "4"}); // i am hilarious

        string choice = "";

        while (choice != "quit")
        {
            choice = menu.GetChoice();

            if (choice == "breathe")
            {
                Console.WriteLine("Breathing.");

                Spinner countdown = new Spinner();
                countdown.PlayCountdown(5);

            }
            else if (choice == "reflect")
            {
                Activity test = new Activity("test", "test description");
                Spinner ball = new Spinner("ball", 100);

                Console.WriteLine("Reflecting.");

                test.Start();
                test.Prepare("PREPARE THYSELF", ball);

                test.Run(ball);

                test.End(ball);
            }
            else if (choice == "list")
            {
                Console.WriteLine("Listing.");
                Thread.Sleep(1000);
            }
            else if (choice == "quit")
            {
                Console.WriteLine("Quitting.");
            }
            else
            {
                Console.WriteLine("\nInvalid. Try again.\n");
            }
        }

    }
}