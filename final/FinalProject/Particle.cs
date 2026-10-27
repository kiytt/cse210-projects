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
    private string _rawLine;

    public Particle(string line)
    {
        _rawLine = line;
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

    public double ParseNumber(string str)
    {
        if (str.Contains('/'))
        {
            string[] split = str.Split('/');
            return double.Parse(split[0]) / double.Parse(split[1]);
        }
        return double.Parse(str);
    }

    public static string GetCommonInputs(string classification)
    {
        Console.Write("Name: ");
        string name = Console.ReadLine().Trim();
        
        Console.Write("Charge: ");
        string charge = Console.ReadLine().Trim();

        Console.Write("Spin: ");
        string spin = Console.ReadLine().Trim();

        Console.Write("Mass (MeV): ");
        string mass = Console.ReadLine().Trim();

        Console.Write("Is an antiparticle (true/false): ");
        bool isAntiparticle = bool.Parse(Console.ReadLine().Trim());

        List<string> forces = new List<string> {};
        if (charge != "0") forces.Add("electromagnetism");
        if (classification.Contains("quark") || classification.Contains("baryon") || classification.Contains("meson"))
            forces.Add("strong");
        if (classification.Contains("lepton"))
            forces.Add("weak");

        return $"name:{name},charge:{charge},spin:{spin},mass:{mass},classification:{classification},interactsWith:{string.Join(" ", forces)},isAntiparticle:{isAntiparticle}";
    }
    public string GetRawLine()
    {
        return _rawLine;
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
    public virtual double GetBaryonNumber()
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