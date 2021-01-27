using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordDatabase : MonoBehaviour
{
    public WordPair[] wordPairs
    {
        get
        {
            return GetComponentsInChildren<WordPair>();
        }
    }

    public List<WordPair> GetWordPairs()
    {
        WordPair[] pairs = wordPairs;

        List<WordPair> pairList = new List<WordPair>();
        foreach(WordPair pair in pairs)
        {
            pairList.Add(pair);
        }

        return pairList;
    }

}
