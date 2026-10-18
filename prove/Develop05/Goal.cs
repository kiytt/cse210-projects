using System;

public abstract class Goal
{
    // attributes
    private string _name;
    private string _desc;
    private int _points;


    // constructors
    public Goal(string name, string desc, int points)
    {
        _name = name;
        _desc = desc;
        _points = points;
    }

    // methods
    public string GetName() {return _name;}
    public string GetDesc() {return _desc;}
    public int GetPoints() {return _points;}

    public abstract int RecordEvent();
    public abstract bool IsComplete();
    public abstract string ToFileString();
    public abstract string GetDisplayString();


    

}