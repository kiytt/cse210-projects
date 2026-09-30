using System;
using System.Collections.Generic;
using System.IO;

public class Library
{
    // Attributes
    private List<Quote> _quotes = new List<Quote>();
    private string _filename = "quotes.txt";

    // Constructors
    public Library()
    {
        LoadQuotes(_filename);
    }

    // Methods
    public void LoadQuotes(string filename)
    {
        string[] lines = File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            string[] parts = line.Split('|'); // Split ref and text into list parts of strings
            string refString = parts[0].Trim(); // first part is ref + cut whitespaces at lead and trail
            string text = parts[1].Trim(); // second part is text

            Reference reference; // init empty ref

            if (refString.Contains(',')) // is book and author
            {
                string[] refParts = refString.Split(',');
                string author = refParts[0].Trim();
                string book = refParts[1].Trim();
                reference = new Reference(book, author);
            }
            else // verse structure
            {
                int index = refString.LastIndexOf(" "); // index of space between book and chapter/verses
                string book = refString[..index]; // slicing with .. and ^
                string chapVerse = refString[index..].Trim();

                string[] chapVerseParts = chapVerse.Split(':');
                int chapter = int.Parse(chapVerseParts[0]);

                if (chapVerse.Contains('-')) // multi
                {
                    string[] verses = chapVerseParts[1].Split('-');
                    reference = new Reference(book, chapter, int.Parse(verses[0]), int.Parse(verses[1]));
                }

                else // single
                {
                    reference = new Reference(book, chapter, int.Parse(chapVerseParts[1]));
                }
            }
            _quotes.Add(new Quote(reference, text));
        }
    }

    public List<Quote> GetQuotes()
    {
        return _quotes;
    }
    
}