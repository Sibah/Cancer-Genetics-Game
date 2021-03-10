using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectString : MonoBehaviour
{
    public string correctString;
    public string[] synonyms;

    public bool Contains(string text)
    {
        if(correctString.ToLower().Contains(text.ToLower()))
        {
            return true;
        }

        foreach(string word in synonyms)
        {
            if(word.ToLower().Contains(text.ToLower()))
            {
                return true;
            }
        }

        return false;
    }

    public bool CheckIfCorrect(string text)
    {
        if(correctString.ToLower().Equals(text.ToLower()))
        {
            return true;
        }

        foreach(string word in synonyms)
        {
            if(word.ToLower().Equals(text.ToLower()))
            {
                return true;
            }
        }
        
        return false;
    }
}
