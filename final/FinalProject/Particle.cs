using System.Collections.Generic;
public abstract class Particle
{
    private string _name;
    private double _charge;
    private double _spin;
    private double _mass;
    private string _classification;
    private List<string> _interactsWith;
    private bool _isAntiparticle;

    public Particle(string line)
    {
        _interactsWith = new List<string>();
        foreach (string pair in line.Split(','))
        {
            string[] kv = pair.Split(':');
            if (kv.Length != 2) continue;
            string key = kv[0].Trim().ToLower();
            string val = kv[1].Trim();

            if (key == "name") _name = val;
            else if (key == "charge") _charge = ParseNumber(val);
            else if (key == "spin") _spin = ParseNumber(val);
            else if (key == "mass") _mass = ParseNumber(val);
            else if (key == "classification") _classification = val;
            else if (key == "isantiparticle") _isAntiparticle = bool.Parse(val);
            else if (key == "interactswith") _interactsWith.Add(val);
        }
    }

    protected double ParseNumber(string str)
    {
        if (str.Contains('/'))
        {
            string[] split = str.Split('/');
            return double.Parse(split[0]) / double.Parse(split[1]);
        }
        return double.Parse(str);
    }

    public double GetCharge()
    {
        return _charge;
    }

    public string GetClassification()
    {
        return _classification.ToLower();
    }

    public string GetName()
    {
        return _name.ToLower();
    }
    public virtual int GetBaryonNumber()
    {
        return 0;
    }

    public virtual int GetLeptonNumber()
    {
        return 0;
    }
    public virtual int GetUpNum()
    {
        return 0;
    }
    public virtual int GetDownNum()
    {
        return 0;
    }
    public virtual int GetStrangeness()
    {
        return 0;
    }
    public virtual int GetCharm()
    {
        return 0;
    }
    public virtual int GetBottomness()
    {
        return 0;
    }
    public virtual int GetTopness()
    {
        return 0;
    }
}