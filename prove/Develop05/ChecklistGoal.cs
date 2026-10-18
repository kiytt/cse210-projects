using System;
using System.Collections.Concurrent;


public class ChecklistGoal : Goal
{
    // attributes
    private bool _isComplete;
    private int _timesCompleted;
    private int _maxTimes;
    private int _bonus;


    // constructors
    public ChecklistGoal(string name, string desc, int points, int maxTimes, int bonus) : base(name, desc, points)
    {
        _isComplete = false;
        _timesCompleted = 0;
        _maxTimes = maxTimes;
        _bonus = bonus;
    }
    public ChecklistGoal(string[] parts) : base(parts[1], parts[2], int.Parse(parts[3]))
    {
        _isComplete = bool.Parse(parts[4]);
        _timesCompleted = int.Parse(parts[5]);
        _maxTimes = int.Parse(parts[6]);
        _bonus = int.Parse(parts[7]);
    }


    // methods
    public override string ToFileString()
    {
        return $"ChecklistGoal|{GetName()}|{GetDesc()}|{GetPoints()}|{_isComplete}|{_timesCompleted}|{_maxTimes}|{_bonus}";
    }
    public override string GetDisplayString()
    {
        string box = $"[{_timesCompleted}/{_maxTimes}]";
        if (IsComplete())
        {
            box = "[x]";
        }
        return $"{box} {GetName()} ({GetDesc()})";
    }

    public override int RecordEvent()
    {
        _timesCompleted += 1;
        if (_timesCompleted >= _maxTimes)
        {
            _isComplete = true;
        }
        return GetPoints();
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }
    
    

}