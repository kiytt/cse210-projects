using System;
using System.IO;
using System.Net;

public class Entry
{
    // Attributes
    public string _date;
    public string _prompt;
    public string _response;

    // Constructor
    public Entry()
    {
    }

    // Methods

    // display prompt, get input, store it
    public void WriteEntry(string prompt)
    {
        DateTime theCurrentTime = DateTime.Now;
        string dateText = theCurrentTime.ToShortDateString();

        _prompt = prompt;
        _date = dateText;

        Console.WriteLine(_prompt);
        _response = Console.ReadLine();
    }

    // display entry
    public void Display()
    {
        Console.WriteLine(_date);
        Console.WriteLine($"Prompt: {_prompt}");
        Console.WriteLine(_response);
        Console.WriteLine();
    }
    
}
