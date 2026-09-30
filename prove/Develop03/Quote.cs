using System;
using System.Collections.Generic;


public class Quote
{
    // Attributes
    private Reference _reference;
    private List<Word> _words;
    private Random randomGenerator = new Random();

    // Constructors
    public Quote(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        string[] splitWords = text.Split(" ");
        foreach (string i in splitWords)
        {
            Word newWord = new Word(i);
            _words.Add(newWord);
        }
    }

    // Methods

    public void RemoveWords(int numToHide)
    {
        List<int> available = new List<int>();
        for (int i = 0; i < _words.Count; i++)
        {
            if (_words[i].IsHidden() == false)
            {
                available.Add(i);
            }
        }

        int countHidden = 0;
        int shrinkNumToHide = Math.Min(numToHide, available.Count);

        while (countHidden < shrinkNumToHide && available.Count > 0)
        {
            int index = randomGenerator.Next(available.Count);
            int availableIndex = available[index];
            _words[availableIndex].HideWord();
            available.RemoveAt(index);
            countHidden ++;
        }
    }

    public string ReconQuote()
    {
        List<string> renderedWords = new List<string>();

        foreach (Word word in _words)
        {
            renderedWords.Add(word.Render());
        }
        return string.Join(" ", renderedWords);
    }

    public string GetDisplayText()
    {
        return $"{_reference.GetReference()}\n{ReconQuote()}";
    }

        public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (word.IsHidden() == false) return false;
        }
        return true;
    }

    public void Reset()
    {
        foreach (Word word in _words)
        {
            word.ShowWord();
        }
    }
}
