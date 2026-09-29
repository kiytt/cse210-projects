using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello Learning03 World!");
        Random randomGenerator = new Random();

        for (int i = 1; i < 21; i++)
        {
            Fraction fraction = new Fraction();

            int doFraction = randomGenerator.Next(0, 2);
            // Console.WriteLine(doFraction); // debug

            // if (doFraction == 0) // wanted to check input options
            // {
            //     fraction.SetTop(randomGenerator.Next(0, 1001));
            // }
            // else
            // {
            //     fraction.SetTop(randomGenerator.Next(0, 1001));
            //     fraction.SetBottom(randomGenerator.Next(0, 1001));
            // }

            fraction.SetTop(randomGenerator.Next(0, 1001));
            fraction.SetBottom(randomGenerator.Next(0, 1001));

            Console.WriteLine($"{i}: Fraction: {fraction.GetFractionString()} | Number: {fraction.GetDecimalValue()}");
        }
    }
}