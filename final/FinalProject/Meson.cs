public class Meson : Hadron
{
    public Meson(string line) : base(line) { }

    public static string PromptAndBuild()
    {
        string baseLine = PromptAndBuildHadron("meson");
        int baryonNumber = 0;

        return $"{baseLine},baryonNumber:{baryonNumber}";
    }
}