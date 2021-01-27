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
                if(Random.Range(0, 2) == 0)
                {
                    CreateWords(true, pair);
                }
                else
                {
                    CreateWords(false, pair);
                }
            }
        }
    }

    private void CreateWords(bool isLeftSide, WordPair pair)
    {
        GameObject word;
        if(isLeftSide)
        {
            word = (GameObject)(Instantiate(wordPrefab, leftSide));
        }
        else
        {
            word = (GameObject)(Instantiate(wordPrefab, rightSide));
        }
        WordHandler handler = word.GetComponent<WordHandler>();
        handler.wordText = pair.GetFirstWord();
        handler.SetSavedWordPair(pair);

        foreach(string secondWord in pair.GetSecondWords())
        {
            if(isLeftSide)
            {
                word = (GameObject)(Instantiate(wordPrefab, rightSide));
            }
            else
            {
                word = (GameObject)(Instantiate(wordPrefab, leftSide));
            }
            handler = word.GetComponent<WordHandler>();
            handler.wordText = secondWord;
            handler.SetSavedWordPair(pair);
        }
    }

    private void PutWordToSide(GameObject wordObject, Transform parent)
    {
        if(parent.name.Equals("RightSide"))
        {
            wordObject.GetComponentInChildren<WordHandler>().SetLinePoint(wordObject.transform.GetChild(1).GetComponent<RectTransform>());
        }
        else
        {
            wordObject.GetComponentInChildren<WordHandler>().SetLinePoint(wordObject.transform.GetChild(2).GetComponent<RectTransform>());
        }
        wordObject.transform.parent = parent;
        Vector3 currentPosition = wordObject.transform.localPosition;
        wordObject.transform.localPosition = new Vector3(currentPosition.x, currentPosition.y, 0);
        wordObject.transform.localScale = new Vector3(1, 1, 1);
    }

    private void ClearOldWords()
    {
        if(lines.childCount > 0)
        {
            for(int i = 0; i < lines.childCount; i++)
            {
                Destroy(lines.GetChild(i).gameObject);
            }
        }
        
        if(rightSide.childCount > 0)
        {
            for(int i = 0; i < rightSide.childCount; i++)
            {
                Destroy(rightSide.GetChild(i).gameObject);
                Destroy(leftSide.GetChild(i).gameObject);
            }
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
