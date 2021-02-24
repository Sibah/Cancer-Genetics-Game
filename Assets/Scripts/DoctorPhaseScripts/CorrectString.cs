using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectString : MonoBehaviour
{
    public string correctString;
    public string[] synonyms;

    public bool CheckIfCorrect(string text)
    {
        if(correctString.ToLower().Equals(text.ToLower()))
        {
            return true;
        }

        foreach(string word in synonyms)
        {
            if(text.ToLower().Equals(word.ToLower()))
            {
                return true;
            }
        }
        
        return false;
    }
}
