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
    public int connectionCount
    {
        get
        {
            return 1 + secondWords.Count;
        }
    }

    public override bool Equals(object obj)
    {
        if(obj == null || !(obj is WordPair))
        {
            return false;
        }
        WordPair secondPair = (WordPair)obj;
        if(this.secondWords.Count != secondPair.secondWords.Count)
        {
            return false;
        }

        for(int i = 0; i <= secondWords.Count; i++)
        {
            if(!secondWords[i].Equals(secondPair.secondWords[i]))
            {
                return false;
            }
        }
        return firstWord.Equals(secondPair.firstWord);
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
    public List<string> GetSecondWords() { return secondWords; }
}
