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
    
    public static string PromptAndBuild()
    {
        string baseLine = GetCommonInputs("lepton");

        Console.Write("Flavor (i.e. electron, muon, tauon): ");
        string flavor = Console.ReadLine().Trim();

        bool isAntiparticle = baseLine.Contains("isAntiparticle:True");
        int leptonNumber = 1;
        if (isAntiparticle)
        {
            leptonNumber = -1;
        }        
        return $"{baseLine},flavor:{flavor},leptonNumber:{leptonNumber}";
    }

    public override int GetLeptonNumber()
    {
        return _leptonNumber;
    }
}