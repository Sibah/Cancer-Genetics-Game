using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordLinePrototypeInitializer : MonoBehaviour
{
    public Transform leftSide;
    public Transform rightSide;
    public List<GameObject> rightSideWords = new List<GameObject>();
    public List<GameObject> leftSideWords = new List<GameObject>();
    public List<string[]> pairs = new List<string[]>();

    public Object wordPrefab;

    public void PlaceWordsInSides()
    {
        List<string[]> wordPairs = new List<string[]>();
        foreach(string[] pair in pairs)
        {
            wordPairs.Add(pair);
        }
        
        int count = wordPairs.Count;
        for(int i = 0; i < count; i++)
        {
            int rand = Random.Range(0, wordPairs.Count);
            WordPair pair = new WordPair(wordPairs[rand][0], wordPairs[rand][1]);
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

            wordPairs.RemoveAt(rand);
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
}
