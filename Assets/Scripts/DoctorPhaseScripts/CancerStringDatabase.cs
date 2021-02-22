using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancerStringDatabase : MonoBehaviour
{
    public string[] cancers;
    public int maxLevenshteinDistance = 4;
    
    public string FindClosestText(string searchWord)
    {
        string closest = searchWord;
        int distance = 1000;
        foreach(string word in cancers)
        {
            int newDistance = LevenshteinDistance(searchWord, word);
            if(newDistance < distance)
            {
                closest = word;
                distance = newDistance;
            }
        }

        if(distance > maxLevenshteinDistance)
        {
            return null;
        }
        return closest;
    }


    // Calculates the Levesthein distance in two strings
    private int LevenshteinDistance(string word, string checkedWord)
    {
        int wordLength = word.Length;
        int checkedWordLength = checkedWord.Length;
        int[,] levenshteinArray = new int[wordLength + 1, checkedWordLength + 1];

        if(wordLength == 0)
        {
            return checkedWordLength;
        }
        
        if(checkedWordLength == 0)
        {
            return wordLength;
        }

        for(int i = 0; i <= wordLength; levenshteinArray[i, 0] = i++){}
        for(int j = 0; j < checkedWordLength; levenshteinArray[0, j] = j++){}

        for(int i = 1; i <= wordLength; i++)
        {
            for(int j = 1; j <= checkedWordLength; j++)
            {
                int cost = 0;
                if(!(checkedWord[j - 1] == word[i - 1]))
                {
                    cost = 1;
                }
                int firstValue = System.Math.Min(levenshteinArray[i-1, j] + 1, levenshteinArray[i, j-1]+1);
                int secondValue = levenshteinArray[i-1, j-1] + cost;
                levenshteinArray[i,j] = System.Math.Min(firstValue, secondValue);
            }
        }

        return levenshteinArray[wordLength, checkedWordLength];
    }
}
