using System;
using System.Collections.Concurrent;


public class Reference
{
    // Attributes
    private string _book;
    private int _chapter = 0;
    private string _author = "None";

    private int _verse = 0;
    private int _endVerse = 0;


    // Constructors
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;        
    }

    public Reference(string book, int chapter, int verse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = endVerse;
    }

    public Reference(string book, string author)
    {
        _book = book;
        _author = author;
    }

    // Methods
    public string GetReference()
    {
        if (_author != "None")
        {
            return $"{_author}, {_book}";
        }
        else if (_endVerse > 0)
        {
            return $"{_book} {_chapter}:{_verse}-{_endVerse}";
        }
        else
        {
            return $"{_book} {_chapter}:{_verse}";
        }
    }
    
}
