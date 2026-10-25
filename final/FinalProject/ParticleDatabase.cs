using System;
using System.Collections.Generic;
using System.IO;

public class ParticleDatabase
{
    private string _filePath = "particlelist.txt";

    public void Save(string line)
    {
        File.AppendAllLines(_filePath, new[] { line });
    }

    public List<string> Find(string searchKey, string searchValue)
    {
        List<string> matches = new List<string>();
        if (!File.Exists(_filePath)) return matches;

        string targetKey = searchKey.Trim().ToLower();
        string targetVal = searchValue.Trim().ToLower();

        foreach (string line in File.ReadAllLines(_filePath))
        {
            foreach (string pair in line.Split(','))
            {
                string[] kv = pair.Split(':');
                if (kv.Length == 2 && 
                    kv[0].Trim().ToLower() == targetKey && 
                    kv[1].Trim().ToLower() == targetVal)
                {
                    matches.Add(line);
                    break;
                }
            }
        }

        return matches;
    }
}