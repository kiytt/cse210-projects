public class Lepton : Matter
{
    private int _leptonNumber;

    public Lepton(string line) : base(line)
    {
        foreach (string pair in line.Split(','))
        {
            string[] kv = pair.Split(':');
            if (kv.Length != 2) continue;
            if (kv[0].Trim().ToLower() == "leptonnumber") _leptonNumber = int.Parse(kv[1].Trim());
        }
    }

    public override int GetLeptonNumber()
    {
        return _leptonNumber;
    }
}