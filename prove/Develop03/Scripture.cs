using System;
using System.Collections.Generic;
using System.Linq;

class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(string referenceText, string text)
    {
        _reference = new Reference(referenceText);
        _words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void Display()
    {
        Console.Clear();  // Clear the console before displaying

        Console.WriteLine(_reference.ToString());
        foreach (var word in _words)
        {
            Console.Write(word.GetRenderedText() + " ");
        }
        Console.WriteLine();
    }

    public void HideRandomWord()
    {
        var random = new Random();
        var visibleWords = _words.Where(word => !word.IsHidden()).ToList();

        if (visibleWords.Count > 0)
        {
            var wordToHide = visibleWords[random.Next(visibleWords.Count)];
            wordToHide.Hide();
        }
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(word => word.IsHidden());
    }
}