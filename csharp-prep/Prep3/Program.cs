using System;

class Program
{
    static void Main(string[] args)
    {
        int lower = 1;
        int upper = 101;

        int counter = 0;
        string playAgain = "";

        Random randomGenerator = new Random();
        int answer = randomGenerator.Next(lower, upper);

        Console.WriteLine("Guess.");
        int guess = int.Parse(Console.ReadLine());
        
        do
        {
            while (guess != answer)
            {
                counter +=1;

                if (guess < lower || guess >= upper)
                {
                    Console.WriteLine("You want a hint? Y/N");
                    string doHint = Console.ReadLine();
                    if (doHint == "Y" || doHint == "y" || doHint == "yes" || doHint == "Yes")
                    {
                        Console.WriteLine($"The answer is between {lower} and {upper - 1}.");
                    }
                    else if (doHint == "N" || doHint == "n" || doHint == "no" || doHint == "No")
                    {
                        Console.WriteLine("Your loss, I guess.");
                    }
                    else if (doHint == "What?" || doHint == "what?" || doHint == "What" || doHint == "what" || doHint == "What are you doing?" || doHint == "what are you doing?" || doHint == "What are you doing" || doHint == "what are you doing")
                    {
                        Console.WriteLine("It's more fun this way.\nWell, more fun for me when testing things, that is. You probably don't test these yourself. That sounds kind of boring. So I guess I'm trying to spice these up for naught.\nWell, back to guessing! And no hint.");
                    }
                    else
                    {
                        Console.WriteLine("Answer properly. No hint.");
                    }
                }
                else if (guess < answer)
                {
                    Console.WriteLine("Higher.");
                }
                else if (guess > answer)
                {
                    Console.WriteLine("Lower.");
                }
            guess = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Correct.");
            Console.WriteLine($"You made {counter} guesses.");

            Console.WriteLine("Play again? Y/N");
            playAgain = Console.ReadLine();
        } while (playAgain == "Y" || playAgain == "y" || playAgain == "yes" || playAgain == "Yes");

    }
}