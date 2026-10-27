public class Baryon : Hadron
{
    public Baryon(string line) : base(line) { }


    public static string PromptAndBuild()
    {
        string baseLine = PromptAndBuildHadron("baryon");

        bool isAntiparticle = baseLine.Contains("isAntiparticle:True");
        int baryonNumber = 1;
        if (isAntiparticle)
        {
            baryonNumber = -1;
        }

        return $"{baseLine},baryonNumber:{baryonNumber}";
    }
}