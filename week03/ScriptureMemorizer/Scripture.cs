using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        _random = new Random();

        foreach (string word in text.Split(' '))
        {
            _words.Add(new Word(word));
        }
    }

    // ⭐ NEW: only hide words that are NOT already hidden
    public void HideRandomWords(int count)
    {
        List<Word> visibleWords = _words.Where(w => !w.IsHidden()).ToList();

        for (int i = 0; i < count && visibleWords.Count > 0; i++)
        {
            int index = _random.Next(visibleWords.Count);
            visibleWords[index].Hide();

            visibleWords.RemoveAt(index); // prevent double selection
        }
    }

    // ⭐ NEW: count progress
    public int GetHiddenCount()
    {
        return _words.Count(w => w.IsHidden());
    }

    public int GetTotalWords()
    {
        return _words.Count;
    }

    public bool AllHidden()
    {
        return _words.All(w => w.IsHidden());
    }

    public string GetDisplayText()
    {
        string result = _reference.GetDisplayText() + "\n\n";

        foreach (Word word in _words)
        {
            result += word.GetDisplayText() + " ";
        }

        return result;
    }
}