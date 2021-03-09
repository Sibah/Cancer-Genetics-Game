using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class WordHandler : MonoBehaviour
{
    private WordPair savedWordPair;
    private RectTransform linePoint;
    private List<WordHandler> connectedWords = new List<WordHandler>();
    private List<GameObject> connectedLine = new List<GameObject>();
    public Color previousColor;
    public Color normalColor = Color.white;
    public Color wrongColor = Color.red;
    public Color correctColor = Color.green;
    public float waitTimer = 1f;
    public bool onRightSide { get{ return transform.parent.name.Equals("RightSide"); } set{}}
    public bool animationEnded = false;
    public bool isJoinableToMultiple
    {
        get
        {
            return GetComponentInChildren<UnityEngine.UI.Text>().text.Equals(savedWordPair.GetFirstWord()) && savedWordPair.connectionCount != 1;
        }
    }
    public string wordText
    {
        set
        {
            GetComponentInChildren<UnityEngine.UI.Text>().text = value;
        }
    }

    private void Start() {
        print(GetComponent<Image>());
    }

    public void SendPositionData()
    {
        SendMessageUpwards("DrawLine", this, SendMessageOptions.RequireReceiver);
    }

    public bool CheckIfCorrectlyFinished()
    {
        if(connectedWords == null || connectedWords.Count == 0)
        {
            return false;
        }
        if(connectedWords.Count == 1)
        {
            if(connectedWords.Count != savedWordPair.connectionCount)
            {
                List<WordHandler> handlers = connectedWords[0].GetConnectedWords();
                foreach(WordHandler word in handlers)
                {
                    if(!savedWordPair.Equals(word.savedWordPair))
                    {
                        return false;
                    }
                }
            }
            return savedWordPair.Equals(connectedWords[0].savedWordPair);
        }
        else
        {
            foreach(WordHandler word in connectedWords)
            {
                if(!savedWordPair.Equals(word.savedWordPair))
                {
                    return false;
                }
            }
        }
        return true;
    }

    public void ResetConnection()
    {
        connectedWords = null;
    }

    public IEnumerator RemoveWordPair(float time)
    {
        if(isJoinableToMultiple || savedWordPair.GetSecondWords().Count == 1)
        {
            // SelectWord(false);
            yield return new WaitForSeconds(waitTimer);
            DestroyWords(this);
        }
        else
        {
            WordHandler mainWord = connectedWords[0];
            // mainWord.SelectWord(false);
            yield return new WaitForSeconds(waitTimer);
            DestroyWords(mainWord);
        }
    }

    private void DestroyWords(WordHandler currentWord)
    {
        if(currentWord.connectedWords != null)
        {
            foreach(WordHandler word in currentWord.connectedWords)
            {
                Destroy(word.gameObject);
            }
        }
        foreach(GameObject line in currentWord.connectedLine)
        {
            Destroy(line);
        }
        Destroy(currentWord.gameObject);
    }
    
    public void SelectWord(bool selected)
    {
        if(selected)
        {
            ChangeColor(correctColor);
        }
        else
        {
            ChangeColor(normalColor);
        }
        ChangeInteractability(!selected);
    }

    public void WronglyConnected(bool isMultiConnectable)
    {
        ChangeColor(wrongColor);
        ChangeInteractability(false);
        StartCoroutine(ReturnToNormalColor());
    }

    private IEnumerator ReturnToNormalColor()
    {
        yield return new WaitForSeconds(1);
        ChangeInteractability(true);
        if(isJoinableToMultiple)
        {
            ChangeColor(correctColor);
        }
        else
        {
            ChangeColor(normalColor);
        }
    }

    private void ChangeColor(Color color)
    {
        previousColor = GetComponent<Image>().color;
        GetComponent<Image>().color = color;
        foreach(WordHandler word in connectedWords)
        {
            word.previousColor = GetComponent<Image>().color;
            word.GetComponent<Image>().color = color;
        }
    }

    private void ChangeInteractability(bool value)
    {
        GetComponent<Button>().interactable = value;
        foreach(WordHandler word in connectedWords)
        {
            word.GetComponent<Button>().interactable = value;
        }

    }

    public bool CheckIfFullyConnected()
    {
        if(savedWordPair.connectionCount == connectedWords.Count) return true;
        foreach(WordHandler word in connectedWords)
        {
            if(word.GetSavedWordPair().connectionCount == word.connectedWords.Count) return true;
        }
        return false;
    }

    public void AddConnectedWord(WordHandler word) { connectedWords.Add(word); }

    public WordPair GetSavedWordPair() { return savedWordPair; }
    public Transform GetLinePoint() { return linePoint; }
    public List<WordHandler> GetConnectedWords() { return connectedWords; }
    public void SetSavedWordPair(WordPair newPair) { savedWordPair = newPair; }
    public void SetLinePoint(RectTransform point) {linePoint = point;}
    public void SetconnectedWords(WordHandler word) { connectedWords[0] = word; }
    public void AddConnectedLine(GameObject line) { connectedLine.Add(line); }

    private void OnDestroy() 
    {
        SendMessageUpwards("IncrementScore", SendMessageOptions.DontRequireReceiver);
        SendMessageUpwards("CheckIfAllPairsDeleted", SendMessageOptions.DontRequireReceiver);    
    }
}
