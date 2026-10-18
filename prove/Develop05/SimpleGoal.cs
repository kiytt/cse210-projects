using System;
using System.Collections.Concurrent;


public class SimpleGoal : Goal
{
    // attributes
    private bool _isComplete;


    // constructors
    public SimpleGoal(string name, string desc, int points) : base(name, desc, points)
    {
        _isComplete = false;
    }
    public SimpleGoal(string[] parts) : base(parts[1], parts[2], int.Parse(parts[3])) // recall return $"SimpleGoal|{GetName()}|{GetDesc()}|{GetPoints()}|{_isComplete}";
    {
        _isComplete = bool.Parse(parts[4]);
    }

    // methods
    public override string ToFileString()
    {
        return $"SimpleGoal|{GetName()}|{GetDesc()}|{GetPoints()}|{_isComplete}";
    }

    public override string GetDisplayString()
    {
        string box = "[ ]";
        if (_isComplete)
        {
            box = "[x]";
        }
        return $"{box} {GetName()} ({GetDesc()})";
    }

    public override int RecordEvent()
    {
        _isComplete = true;
        return GetPoints();
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }
    

}