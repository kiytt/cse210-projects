using System;
using System.ComponentModel.DataAnnotations;

public class BreathingActivity : Activity
{

    // Attributes/member variables
    private string _variation = "";


    // Constructors
    public BreathingActivity(string variation = "inhale exhale") : base("Breathing Activity", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
        _variation = variation;
    }

    
    // Methods
    public void Run()
    {
        Spinner spinner = new Spinner();
        int duration = GetDuration(); // s
        int elapsed = 0;

        Console.Clear();

        int cycleLength = 0;

        do
        {
            Console.Clear();

            if (_variation == "box")
            {
                int length = 4;
                cycleLength = length*4;

                Console.WriteLine("Inhale");
                spinner.PlayCountdown(length);
                Console.Clear();
                Console.WriteLine("Hold");
                spinner.PlayCountdown(length);
                Console.Clear();
                Console.WriteLine("Exhale");
                spinner.PlayCountdown(length);
                Console.Clear();
                Console.WriteLine("Hold");
                spinner.PlayCountdown(length);
            }

            else if (_variation == "inhale exhale")
            {
                int length = 4;
                cycleLength = length*2;

                Console.WriteLine("Inhale");
                spinner.PlayCountdown(length);
                Console.Clear();
                Console.WriteLine("Exhale");
                spinner.PlayCountdown(length);
            }
            else if (_variation == "asymmetric")
            {
                cycleLength = 4+7+8;

                Console.WriteLine("Inhale");
                spinner.PlayCountdown(4);
                Console.Clear();
                Console.WriteLine("Hold");
                spinner.PlayCountdown(7);
                Console.Clear();
                Console.WriteLine("Exhale");
                spinner.PlayCountdown(8);
            }
            elapsed += cycleLength;

        } while (elapsed < duration);
    }
    


}
