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
        //TODO: CHANGE HOW WORD PAIRS ARE STORED IN UNITY

        return null;
    }

}
