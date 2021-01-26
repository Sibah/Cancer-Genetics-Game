using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordPair : MonoBehaviour
{
    [SerializeField]
    private string firstWord;
    [SerializeField]
    private List<string> secondWords;

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
        return firstWord.Length + secondWords.Count;
    }

    public override string ToString()
    {
        string words = firstWord;
        foreach(string text in secondWords)
        {
            words += " " + text;
        }
        return words;
    }

    public string GetFirstWord() { return firstWord; }
    public List<string> GetSecondWord() { return secondWords; }
}
