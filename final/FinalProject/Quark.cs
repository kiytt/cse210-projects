public class Quark : Matter
{
    private double _baryonNumber;
    private int _upness;
    private int _downness;
    private int _strangeness;
    private int _charm;
    private int _bottomness;
    private int _topness;

    public Quark(string line) : base(line)
    {
        foreach (string pair in line.Split(','))
        {
            string[] kv = pair.Split(':');
            if (kv.Length != 2) continue;
            string key = kv[0].Trim().ToLower();
            string val = kv[1].Trim();

            if (key == "baryonnumber") _baryonNumber = ParseNumber(val);
            else if (key == "up") _upness = int.Parse(val);
            else if (key == "down") _downness = int.Parse(val);
            else if (key == "strangeness") _strangeness = int.Parse(val);
            else if (key == "charm") _charm = int.Parse(val);
            else if (key == "bottomness") _bottomness = int.Parse(val);
            else if (key == "topness") _topness = int.Parse(val);
        }
    }

    public static string PromptAndBuild()
    {
        string baseLine = GetCommonInputs("quark");

        Console.Write("Flavor (up, down, charm, strange, top, bottom): ");
        string flavor = Console.ReadLine().Trim().ToLower();

        bool isAntiparticle = baseLine.Contains("isAntiparticle:True");

        string baryonNumber = "1/3";
        if (isAntiparticle)
        {
            baryonNumber = "-1/3";
        }

        int up = 0;
        int down = 0;
        int strangeness = 0;
        int charm = 0;
        int bottomness = 0;
        int topness = 0;

        if (flavor == "up")
        {
            up = 1;
            if (isAntiparticle)
            {
                up = -1;
            }
        }
        else if (flavor == "down")
        {
            down = 1;
            if (isAntiparticle)
            {
                down = -1;
            }
        }
        else if (flavor == "charm")
        {
            charm = 1;
            if (isAntiparticle)
            {
                charm = -1;
            }
        }
        else if (flavor == "strange")
        {
            strangeness = -1;
            if (isAntiparticle)
            {
                strangeness = 1;
            }
        }
        else if (flavor == "top")
        {
            topness = 1;
            if (isAntiparticle)
            {
                topness = -1;
            }
        }
        else if (flavor == "bottom")
        {
            bottomness = -1;
            if (isAntiparticle)
            {
                bottomness = 1;
            }
        }

        return $"{baseLine},baryonNumber:{baryonNumber},up:{up},down:{down},strangeness:{strangeness},charm:{charm},bottomness:{bottomness},topness:{topness}";
    }

    public override double GetBaryonNumber()
    {
        return _baryonNumber;
    }

    public override int GetUpNum()
    {
        return _upness;
    }

    public override int GetDownNum()
    {
        return _downness;
    }

    public override int GetStrangeness()
    {
        return _strangeness;
    }
    public int GetStrangeNum()
    {
        return -_strangeness;
    }

    public override int GetCharm()
    {
        return _charm;
    }
    public int GetCharmNum()
    {
        return _charm;
    }

    public override int GetBottomness()
    {
        return _bottomness;
    }
    public int GetBottomNum()
    {
        return -_bottomness;
    }

    public override int GetTopness()
    {
        return _topness;
    }
    public int GetTopNum()
    {
        return _topness;
    }
}