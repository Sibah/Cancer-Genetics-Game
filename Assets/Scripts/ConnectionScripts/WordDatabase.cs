using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordDatabase : MonoBehaviour
{
    public List<string> firstWordList = new List<string>();
    public List<string> secondWordList = new List<string>();

    public List<WordPair> GetWordPairs()
    {
        if(firstWordList.Count != secondWordList.Count)
        {
            Debug.LogError("Word counts are different");
            return null;
        }

        List<WordPair> words = new List<WordPair>();

        for(int i = 0; i < firstWordList.Count; i++)
        {
            words.Add(new WordPair(firstWordList[i], secondWordList[i]));
        }

        return words;
    }

}
