using System;

public class Spinner
{

    // Attributes/member variables
    private string[] _frames;
    private int _delay;
    private string _style;


    // Constructors
    // preset animations
    public Spinner(string style, int delay)
    {
        _style = style;
        _delay = delay;

        if (style == "ball")
        {
            _frames = new string[]
            {
                "|o            ",
                "| o           ",
                "|  o          ",
                "|   o         ",
                "|    o        ",
                "|     o       ",
                "|      o      ",
                "|       o     ",
                "|        o    ",
                "|         o   ",
                "|          o  ",
                "|           o ",
                "|            o",
                "|            |",
                "|            |",
                "|            o",
                "|           o ",
                "|          o  ",
                "|         o   ",
                "|        o    ",
                "|       o     ",
                "|      o      ",
                "|     o       ",
                "|    o        ",
                "|   o         ",
                "|  o          ",
                "| o           ",
                "|o            ",
                "||            ",
                "||            "
            };
        }

        else if (style == "bar")
        {
            _frames = new string[]
            {
                "-",
                "\\",
                "|",
                "/"
            };
        }

        else if (style == "oh")
        {
            _frames = new string[]
            {
                ".",
                "o",
                "O",
                "o"
            };
        }

        else if (style == "dots")
        {
            _frames = new string[]
            {
                ".",
                "..",
                "...",
            };
        }

        else
        {
            _frames = new string[]
            {
                "ANIMATION MISSING"
            };
        }

    }

    // custom animations
    public Spinner(string[] customFrames, int delay)
    {
        _style = "style";
        _delay = delay;
        _frames = customFrames;
    }

    // blank for countdown
    public Spinner()
    {
    }

    
    // Methods
    public void Play(int seconds)
    {
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int frameIdx = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write($"\r{_frames[frameIdx]}"); // returns to start line - if all strings same len (presets are), easier than \b
            Thread.Sleep(_delay);
            frameIdx = (frameIdx + 1) % _frames.Length; // goes from 0 to length then to 0 to length then...
        }
        Console.Write($"\r                                              \r"); // clears line unless REALLY long
    }

        public void PlayCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"\r{i}");
            Thread.Sleep(1000);
            Console.Write("\r                    \r");
        }
        Console.Write("\r                    \r");
    }

}