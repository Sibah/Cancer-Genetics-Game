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

    public int maxWordCount = 4, roundAmount = 2, roundCounter = 0;

    public Object wordPrefab;

    public void PlaceWordsInSides()
    {
        ClearOldWords();
        
        int count = 0;
        if(pairs.Count > maxWordCount)
        {
            count = maxWordCount;
        }
        else
        {
            count = pairs.Count;
        }
        //CHECK FOR END OF THE ROUND
        if(count == 0 || roundCounter >= roundAmount)
        {
            SendMessage("BackToModeSelect");
        }
        else
        {
            
        }
        roundCounter++;
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
