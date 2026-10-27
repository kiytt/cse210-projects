public class GaugeBoson : ForceCarrier
{
    public GaugeBoson(string line) : base(line) { }

    public static string PromptAndBuild()
    {
        string baseLine = GetCommonInputs("gaugeBoson");

        Console.Write("Mediated Force (electromagnetism, strong, or weak): ");
        string force = Console.ReadLine().Trim();

        return $"{baseLine},mediatedForce:{force}";
    }
}