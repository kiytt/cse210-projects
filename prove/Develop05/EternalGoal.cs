using System;
using System.Collections.Concurrent;


public class EternalGoal : Goal
{
    // attributes
    private int _timesCompleted;
    private bool _isComplete = false;


    // constructors
    public EternalGoal(string name, string desc, int points) : base(name, desc, points)
    {
        _timesCompleted = 0;
    }
    public EternalGoal(string[] parts) : base(parts[1], parts[2], int.Parse(parts[3]))
    {
        _timesCompleted = int.Parse(parts[5]);
    }


    // methods
    public override string ToFileString()
    {
        return $"EternalGoal|{GetName()}|{GetDesc()}|{GetPoints()}|{_isComplete}|{_timesCompleted}";
    }
    public override string GetDisplayString()
    {
        string box = $"[{_timesCompleted}]";
        return $"{box} {GetName()} ({GetDesc()})";
    }

    public override int RecordEvent()
    {
        _timesCompleted += 1;
        return GetPoints();
    }

    public override bool IsComplete()
    {
        return false;
    }
    

}