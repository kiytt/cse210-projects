public abstract class Hadron : Particle
{
    private int _baryonNumber;

    public Hadron(string line) : base(line)
    {
        foreach (string pair in line.Split(','))
        {
            string[] kv = pair.Split(':');
            if (kv.Length != 2) continue;
            if (kv[0].Trim().ToLower() == "baryonnumber") _baryonNumber = int.Parse(kv[1].Trim());
        }
    }

    public override int GetBaryonNumber()
    {
        return _baryonNumber;
    }
}