public abstract class Hadron : Particle
{
    private double _baryonNumber;

    public Hadron(string line) : base(line)
    {
        foreach (string pair in line.Split(','))
        {
            string[] kv = pair.Split(':');
            if (kv.Length != 2)
            {
                continue;
            }
            if (kv[0].Trim().ToLower() == "baryonnumber") 
            {
                _baryonNumber = ParseNumber(kv[1].Trim());
            }
        }
    }

    public static string PromptAndBuildHadron(string classification)
    {
        string baseLine = GetCommonInputs(classification);

        Console.Write("Constituent Quarks (i.e. up up down, down antiup): ");
        string constituentQuarks = Console.ReadLine().Trim();

        return $"{baseLine},constituentQuarks:{constituentQuarks}";
    }

    public override double GetBaryonNumber()
    {
        return _baryonNumber;
    }
}