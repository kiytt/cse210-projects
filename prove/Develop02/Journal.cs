using System;
using System.IO;

public class Journal
{
    // Attributes
    public List<Entry> _entries = new List<Entry>();


    // Constructor
    public Journal()
    {
    }

    // Methods

    // display journal iterativly through entries
    public void Display()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    // save journal to user specified file
    public string Save()
    {
        // get file name
        Console.Write("File name: ");
        string filename = Console.ReadLine().Split('.')[0] + ".txt";
        
        // write
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine("NEW_ENTRY");
                outputFile.WriteLine(entry._date);
                outputFile.WriteLine(entry._prompt);
                outputFile.WriteLine(entry._response);
            }
        }
        return filename;
    }

    // // load journal from file
    // // " Prompt the user for a filename and then load the journal (a complete list of entries) from that file. 
    // // This should replace any entries currently stored in the journal."
    public string Load()
    {
        // get file name
        Console.Write("File name: ");
        string filename = Console.ReadLine().Split('.')[0] + ".txt";

        string[] lines = System.IO.File.ReadAllLines(filename);

        _entries.Clear();

        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i] == "NEW_ENTRY")
            {
                Entry newEntry = new Entry();
                newEntry._date = lines[i + 1];
                newEntry._prompt = lines[i + 2];
                newEntry._response = lines[i + 3];
                
                _entries.Add(newEntry);
            }
        }
        return filename;
    }
}