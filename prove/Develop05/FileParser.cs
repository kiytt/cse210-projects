using System.Collections.Generic;
using System.IO;

public static class FileParser // found you could do this after seeing static methods in the prep. All methods here!
{
    // methods

    // file read and write
    public static void WriteLines(string filePath, List<string> lines)
    {
        File.WriteAllLines(filePath, lines.ToArray()); // this is so much shorter than streamwriter, though it does want an array
    }

    public static List<string> ReadLines(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return new List<string>();
        }
        return new List<string>(File.ReadAllLines(filePath));
    }

    // file display and remove things

    public static int GetPagedIndex(List<string> items, string header="") // follows from prompt generator paginator
    {
        int increment = 5;
        int i = 0;
        string choice = "";

        while (choice != "return")
        {
            Console.Clear();
            if (header != "")
            {
                Console.WriteLine(header);
                Console.WriteLine();
            }

            Menu menu = new Menu();

            int startIndex = i;
            int endIndex = Math.Min(i + increment, items.Count);

            for (int j = startIndex; j < endIndex; j++)
            {
                int displayNum = (j - i) + 1;
                menu.AddOption($"{displayNum}. {items[j]}", new string[] { displayNum.ToString() });
            }

            menu.AddOption("", new string[]{});
            menu.AddOption("\x1b[4mN\x1b[24mext", new string[] {"next", "n"});
            menu.AddOption("\x1b[4mP\x1b[24mrevious", new string[] {"previous", "prev", "p"});
            menu.AddOption("\x1b[4mR\x1b[24meturn", new string[] {"return", "r"});

            choice = menu.GetChoice();

            if (choice == "next")
            {
                if (i + increment < items.Count)
                {
                    i += increment;
                }
            }
            else if (choice == "previous")
            {
                if (i - increment >= 0)
                {
                    i -= increment;
                }
                else
                {
                    i = 0;
                }
            }
            else if (choice != "return")
            {
                int selectedIndex = i + int.Parse(choice) - 1;
                if (selectedIndex < items.Count)
                {
                    return selectedIndex;
                }
            }
        }
        return -1; // invalid index for "no choice"
    }

    public static void RemoveLine(string filePath, int index)
    {
        List<string> lines = ReadLines(filePath);
        
        if (index >= 0 && index < lines.Count)
        {
            lines.RemoveAt(index);
            WriteLines(filePath, lines);
        }
    }


}