using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordLineInitializer : MonoBehaviour
{
    public Transform leftSide;
    public Transform rightSide;
    public Transform lines;
    public List<GameObject> rightSideWords = new List<GameObject>();
    public List<GameObject> leftSideWords = new List<GameObject>();
    public List<WordPair> pairs = new List<WordPair>();
    public Object wordPrefab;
    public int maxWordCount = 4, roundAmount = 2, roundCounter = 0;

    public void PlaceWordsInSides()
    {
        if(pairs == null)
        {
            Debug.LogError("wordPair array is null");
            return;
        }

        ClearOldWords();
        HandleWordCreation();
        PutWordsToSides();
        roundCounter++;
    }

    private void HandleWordCreation()
    {
        int count = 0;

        if(pairs.Count > maxWordCount)
        {
            count = maxWordCount;
        }
        else
        {
            count = pairs.Count;
        }

        if(count == 0 || roundCounter >= roundAmount)
        {
            SendMessage("BackToModeSelect");
        }
        else
        {
            for(int i = 0; i < count; i++)
            {
                int index = Random.Range(0, pairs.Count);
                WordPair pair = pairs[index];
                pairs.RemoveAt(index);
                CreateWords(pair);
                if(leftSide.childCount >= count || rightSide.childCount >= count)
                {
                    break;
                }
            }
        }
    }

    private void CreateWords(WordPair pair)
    {
        GameObject firstWord;
        List<GameObject> secondWords = new List<GameObject>();
        
        firstWord = CreateWord(pair, pair.GetFirstWord());

        foreach(string secondWord in pair.GetSecondWords())
        {
            secondWords.Add(CreateWord(pair, secondWord));
        }

        if(Random.Range(0, 2) == 0 || firstWord.GetComponent<WordHandler>().isJoinableToMultiple)
        {
            AddWordsToSides(firstWord, secondWords, true);
        }
        else
        {
            AddWordsToSides(firstWord,secondWords, false);
        }
    }

    private GameObject CreateWord(WordPair pair, string text)
    {
        GameObject word;
        WordHandler handler;

        word = (GameObject)(Instantiate(wordPrefab));
        handler = word.GetComponent<WordHandler>();
        handler.wordText = text;
        handler.SetSavedWordPair(pair);

        return word;
    }

    private void AddWordsToSides(GameObject firstWord, List<GameObject> secondWords, bool isLeftside)
    {
        if(isLeftside)
        {
            firstWord.GetComponent<WordHandler>().SetLinePoint(firstWord.transform.GetChild(2).GetComponent<RectTransform>());
            leftSideWords.Add(firstWord);
            foreach(GameObject word in secondWords)
            {
                word.GetComponent<WordHandler>().SetLinePoint(word.transform.GetChild(1).GetComponent<RectTransform>());
                rightSideWords.Add(word);
            }
        }
        else
        {
            firstWord.GetComponent<WordHandler>().SetLinePoint(firstWord.transform.GetChild(1).GetComponent<RectTransform>());
            rightSideWords.Add(firstWord);
            foreach(GameObject word in secondWords)
            {
                word.GetComponent<WordHandler>().SetLinePoint(word.transform.GetChild(2).GetComponent<RectTransform>());
                leftSideWords.Add(word);
            }
        }
    }

    private void PutWordsToSides()
    {
        ShuffleGameObjectList(rightSideWords);
        ShuffleGameObjectList(leftSideWords);

        foreach(GameObject word in rightSideWords)
        {
            word.transform.parent = rightSide;
            word.transform.localScale = new Vector3(1, 1, 1);
            word.transform.localPosition = Vector3.zero;
        }
        foreach(GameObject word in leftSideWords)
        {
            word.transform.parent = leftSide;
            word.transform.localScale = new Vector3(1, 1, 1);
            word.transform.localPosition = Vector3.zero;
        }
        rightSideWords = new List<GameObject>();
        leftSideWords = new List<GameObject>();
    }

    private void ShuffleGameObjectList(List<GameObject> list)
    {
        for(int i = list.Count - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            GameObject temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }

    public void ClearOldWords()
    {
        int lineCount = lines.childCount;
        int rightCount = rightSide.childCount;
        int leftCount = leftSide.childCount;
        for(int i = 0; i < lineCount; i++)
        {
            Destroy(lines.GetChild(i).gameObject);
        }
        
        for(int i = 0; i < rightCount; i++)
        {
            Destroy(rightSide.GetChild(i).gameObject);
        }

        for(int i = 0; i < leftCount; i++)
        {
            Destroy(leftSide.GetChild(i).gameObject);
        }
    }

    private void CheckIfAllPairsDeleted()
    {
        if(rightSide.childCount <= 1 && leftSide.childCount <= 1)
        {
            BroadcastMessage("FinishRound", SendMessageOptions.DontRequireReceiver);
        }
    }
}
