using System;
using System.Collections.Generic;
using System.IO;

public class ParticleDatabase
{
    private string _filePath = "particlelist.txt";

    public void Save(string line)
    {
        File.AppendAllLines(_filePath, new[] {line});
    }

    public List<Particle> Find(string searchKey, string searchValue)
    {
        List<Particle> matches = new List<Particle>();
        if (!File.Exists(_filePath)) 
        {
            return matches;
        }

        string targetKey = searchKey.Trim().ToLower();
        string targetVal = searchValue.Trim().ToLower();

        if (targetKey == "interactswith")
        {
            foreach (string line in File.ReadAllLines(_filePath))
            {
                foreach (string pair in line.Split(','))
                {
                    string[] kv = pair.Split(':');
                    if (kv.Length == 2 && 
                        kv[0].Trim().ToLower() == targetKey && 
                        kv[1].Trim().ToLower().Contains(targetVal))
                    {
                        matches.Add(CreateParticle(line));
                        break;
                    }
                }
            }
        }
        else
        {
            foreach (string line in File.ReadAllLines(_filePath))
            {
                foreach (string pair in line.Split(','))
                {
                    string[] kv = pair.Split(':');
                    if (kv.Length == 2 && 
                        kv[0].Trim().ToLower() == targetKey && 
                        kv[1].Trim().ToLower() == targetVal)
                    {
                        matches.Add(CreateParticle(line));
                        break;
                    }
                }
            }
        }
        return matches;
    }

    private Particle CreateParticle(string line)
    {
        string classification = "";
        foreach (string pair in line.Split(','))
        {
            string[] kv = pair.Split(':');
            if (kv.Length == 2 && kv[0].Trim().ToLower() == "classification")
            {
                classification = kv[1].Trim().ToLower();
                break;
            }
        }

        if (classification == "quark")
        {
            return new Quark(line);
        }
        else if (classification == "lepton")
        {
            return new Lepton(line);
        }
        else if (classification == "baryon")
        {
            return new Baryon(line);
        }
        else if (classification == "meson")
        {
            return new Meson(line);
        }
        else if (classification == "gaugeboson")
        {
            return new GaugeBoson(line);
        }
        else if (classification == "scalarboson")
        {
            return new ScalarBoson(line);
        }
        else
        {
            Console.WriteLine($"Unknown {classification}");
            return null;
        }
    }

    public Particle PromptAndAdd(string name)
    {
        Console.Write($"\n'{name}' not found in database.\n\nClassification: ");
        string classification = Console.ReadLine().Trim().ToLower();

        string rawLine = "";
        if (classification == "scalarboson")
        {
            rawLine = ScalarBoson.PromptAndBuild();
        }
        else if (classification == "gaugeboson")
        {
            rawLine = GaugeBoson.PromptAndBuild();
        }
        else if (classification == "lepton")
        {
            rawLine = Lepton.PromptAndBuild();
        }
        else if (classification == "baryon")
        {
            rawLine = Baryon.PromptAndBuild();
        }
        else if (classification == "meson")
        {
            rawLine = Meson.PromptAndBuild();
        }
        else if (classification == "quark")
        {
            rawLine = Quark.PromptAndBuild();
        }

        if (!string.IsNullOrEmpty(rawLine))
        {
            Save(rawLine);
            List<Particle> matches = Find("name", name);
            if (matches.Count > 0)
            {
                return matches[0];
            }
        }
        return null;
    }

    public List<Particle> ListAll()
    {
        List<Particle> entries = new List<Particle>();
        if (!File.Exists(_filePath)) 
        {
            return entries;
        }
        foreach (string line in File.ReadAllLines(_filePath))
        {
            Particle particle = CreateParticle(line);
                if (particle != null)
                {
                    entries.Add(particle);
                }
        }
        return entries;
    }
}