public class Quark : Matter
{
    private int _baryonNumber;
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

            if (key == "baryonnumber") _baryonNumber = int.Parse(val);
            else if (key == "upness") _upness = int.Parse(val);
            else if (key == "downness") _downness = int.Parse(val);
            else if (key == "strangeness") _strangeness = int.Parse(val);
            else if (key == "charm") _charm = int.Parse(val);
            else if (key == "bottomness") _bottomness = int.Parse(val);
            else if (key == "topness") _topness = int.Parse(val);
        }
    }

    public override int GetBaryonNumber()
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

    public override int GetCharm()
    {
        return _charm;
    }

    public override int GetBottomness()
    {
        return _bottomness;
    }

    public override int GetTopness()
    {
        return _topness;
    }
}