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
            for(int i = 0; i < count; i++)
            {
                int rand = Random.Range(0, pairs.Count);
                WordPair pair = pairs[rand];
                GameObject[] wordObjects = new GameObject[2];

                wordObjects[0] = ((GameObject)Instantiate(wordPrefab));
                wordObjects[0].GetComponentInChildren<WordHandler>().SetSavedWordPair(pair);

                wordObjects[1] = ((GameObject)Instantiate(wordPrefab));
                wordObjects[1].GetComponentInChildren<WordHandler>().SetSavedWordPair(pair);

                int sideRand = Random.Range(0, 2);
                if(sideRand == 0)
                {
                    wordObjects[0].GetComponentInChildren<Text>().text = pair.GetFirstWord();
                    wordObjects[1].GetComponentInChildren<Text>().text = pair.GetSecondWord();
                }
                else
                {
                    wordObjects[1].GetComponentInChildren<Text>().text = pair.GetFirstWord();
                    wordObjects[0].GetComponentInChildren<Text>().text = pair.GetSecondWord();
                }

                
                rightSideWords.Add(wordObjects[0]);
                leftSideWords.Add(wordObjects[1]);

                pairs.RemoveAt(rand);
            }
            for(int i = 0; i < count; i++)
            {
                int rightRand = Random.Range(0, rightSideWords.Count);
                int leftRand = Random.Range(0, leftSideWords.Count);

                PutWordToSide(rightSideWords[rightRand], rightSide);
                PutWordToSide(leftSideWords[leftRand], leftSide);

                rightSideWords.RemoveAt(rightRand);
                leftSideWords.RemoveAt(leftRand);
            }
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
