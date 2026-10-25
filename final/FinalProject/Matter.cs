public abstract class Matter : Fundamental
{
    private string _flavor;

    public Matter(string line) : base(line)
    {
        foreach (string pair in line.Split(','))
        {
            string[] kv = pair.Split(':');
            if (kv.Length != 2) continue;
            if (kv[0].Trim().ToLower() == "flavor") _flavor = kv[1].Trim();
        }
    }
}