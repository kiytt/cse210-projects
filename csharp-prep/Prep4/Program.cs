using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int sum = 0;
        float avg = 0;
        int max = 0;

        Console.WriteLine("Enter integers one by one, type 0 when finished.");
        int input = int.Parse(Console.ReadLine());

        while (input != 0 )
        {
            numbers.Add(input);
            input = int.Parse(Console.ReadLine());
        }

        foreach (int number in numbers)
        {
            sum += number;

            int len = numbers.Count;
            avg = (float)sum / len;

            max = numbers.Max();
        }
        Console.WriteLine($"Sum: {sum}\nAverage: {avg:F2}\nMaximum: {max}");
    }
} // I really shouldn't be spending as much time as I had been on these.