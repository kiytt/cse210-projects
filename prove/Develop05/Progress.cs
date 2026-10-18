using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public class Progress
{
    // attributes
    private int _points;
    private List<string> _badges;
    private string _filepath;


    // constructors
    public Progress(string filepath)
    {
        _points = 0;
        _badges = new List<string>();
        _filepath = filepath;

        List<string> lines = FileParser.ReadLines(_filepath);
        if (lines.Count > 0)
        {
            if (lines.Count > 0)
            {
                _points = int.Parse(lines[0]);
                for (int i = 1; i < lines.Count; i++) 
                {
                    _badges.Add(lines[i]);
                }
            }
        }
    }

    // methods
    public void AddPoints(int amount)
    {
        _points += amount;
        CheckBadges();
    }

    public void CheckBadges()
    {
        if (_points >= 50 && !_badges.Contains("What's the Point?"))
        {
            _badges.Add("What's the Point?");
        }
        if (_points >= 100 && !_badges.Contains("On Point"))
        {
            _badges.Add("On Point");
        }
        if (_points >= 200 && !_badges.Contains("Point Break"))
        {
            _badges.Add("Point Break");
        }
        if (_points >= 500 && !_badges.Contains("Point of No Return"))
        {
            _badges.Add("Point of No Return");
        }
        if (_points >= 1000 && !_badges.Contains("Point Lord"))
        {
            _badges.Add("Point Lord");
        }
        if (_points >= 2000 && !_badges.Contains("Straight to the Point"))
        {
            _badges.Add("Straight to the Point");
        }
        if (_points >= 1000000 && !_badges.Contains("Points Icon")) // Lindon???
        {
            _badges.Add("Points Icon");
        }
    }

    public string[] GetProgress()
    {
        List<string> lines = new List<string> {_points.ToString()};
        lines.AddRange(_badges); // appends individual badges
        return lines.ToArray(); // for writing
    }

    public void ViewProgress()
    {
       FileParser.GetPagedIndex(_badges, $"Total Points: {_points}\nBadges earned:");
    }

    
    

}