using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordPair
{
    private string firstWord;
    private string secondWord;

    public WordPair(string first, string second)
    {
        firstWord = first;
        secondWord = second;
    }

    public override bool Equals(object obj)
    {
        if(obj == null)
        {
            return false;
        }
        // if(!(obj is WordPair))
        // {
        //     return false;
        // }
        WordPair secondPair = (WordPair)obj;
        return secondPair.GetFirstWord().Equals(this.GetFirstWord()) && secondPair.GetSecondWord().Equals(this.GetSecondWord());
    }

    public override int GetHashCode()
    {
        return firstWord.Length + secondWord.Length;
    }

    public override string ToString()
    {
        return firstWord + " " + secondWord;
    }

    public string GetFirstWord() { return firstWord; }
    public string GetSecondWord() { return secondWord; }
}
