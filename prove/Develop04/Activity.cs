using System;
using System.Diagnostics;

public class Activity
{

    // Attributes/member variables
    private string _activityName = "";
    private string _description = "";
    private int _duration = 0;



    // Constructors
    public Activity(string activityName, string description)
    {
        _activityName = activityName;
        _description = description;
    }
    
    // Methods

    public int GetDuration()
    {
        return _duration;
    }

    public void Start()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_activityName} Activity.");
        Console.WriteLine(_description);
        Console.Write("How long would you like your session (in seconds)?\n> ");
        _duration = int.Parse(Console.ReadLine());
    }

    public void End(Spinner spinner)
    {
        Console.Clear();
        Console.WriteLine($"Nice. You endured the {_activityName} for {_duration} seconds.");
        spinner.Play(5);
    }

    public void Prepare(string message, Spinner spinner)
    {
        Console.Clear();
        Console.WriteLine(message);
        Console.WriteLine();

        spinner.Play(5);
    }

    public void Run(Spinner spinner)
    {
        Console.Clear();
        spinner.Play(_duration); // in s
    }


}