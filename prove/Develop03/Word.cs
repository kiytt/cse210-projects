using System;
using System.Collections.Concurrent;


public class Word
{
    // Attributes
    private string _text; 
    private bool _isHidden;


    // Constructors
    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    // Methods
    public void HideWord()
    {
        _isHidden = true;
    }

    public void ShowWord()
    {
        _isHidden = false;
    }

    public string Render()
    {
        if (_isHidden)
        {
            return new string('_', _text.Length);
        }
        else
        {
            return _text;
        }
    }
    public bool IsHidden()
    {
        return _isHidden;
    }
}
