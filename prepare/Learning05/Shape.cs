using System;

public abstract class Shape
{
    // attr
    private string _color;


    // cons
    public Shape(string color)
    {
        _color = color;
    }

    // meth
    public string GetColor()
    {
        return _color;
    }

    public void SetColor(string color)
    {
        _color = color;

    }
    public abstract double GetArea();

    private string ansiCode()
    {
        string colorCheck = _color.ToLower();

        if (colorCheck == "black")
        {
            return "\x1b[30m";
        }
        else if (colorCheck == "red")
        {
            return "\x1b[31m";
        }
        else if (colorCheck == "green")
        {
            return "\x1b[32m";
        }
        else if (colorCheck == "yellow")
        {
            return "\x1b[33m";
        }
        else if (colorCheck == "blue")
        {
            return "\x1b[34m";
        }
        else if (colorCheck == "magenta")
        {
            return "\x1b[35m";
        }
        else if (colorCheck == "cyan")
        {
            return "\x1b[36m";
        }
        else if (colorCheck == "white")
        {
            return "\x1b[37m";
        }

        return "";
    }

    // \x1b[0m
    public string GetColoredColor()
    {
        return $"{ansiCode()}{_color}\x1b[0m";
    }

}