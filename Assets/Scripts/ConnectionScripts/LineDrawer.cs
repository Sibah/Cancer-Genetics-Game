using UnityEngine;
using System.Collections;

public class LineDrawer : MonoBehaviour
{
    public Object linePrefab;
    public Transform lines;
    public Camera mainCamera;
    public WordHandler currentWord;
    public float removalTime = 0.25f;

    private void Update() 
    {
        if(Input.GetMouseButtonDown(1))
        {
            currentWord.SelectWord(false);
            currentWord = null;
        }    
    }

    public void DrawLine(WordHandler word)
    {
        if(currentWord != null)
        {
            if(word != null && currentWord.onRightSide != word.onRightSide)
            {
                if(currentWord.GetConnectedWords().Count != currentWord.GetSavedWordPair().connectionCount)
                {
                    if(currentWord.GetSavedWordPair().Equals(word.GetSavedWordPair()))
                    {
                        LinePositionKeeper line = ((GameObject)Instantiate(linePrefab, lines)).GetComponent<LinePositionKeeper>();
                        line.SetPoints(currentWord.GetLinePoint(), word.GetLinePoint());
                        currentWord.AddConnectedWord(word);
                        currentWord.AddConnectedLine(line.gameObject);
                        word.SelectWord(true);
                        if(currentWord.CheckIfFullyConnected())
                        {
                            if(currentWord.CheckIfCorrectlyFinished())
                            {
                                IEnumerator coroutine = currentWord.RemoveWordPair(removalTime);
                                StartCoroutine(coroutine);
                            }
                            currentWord = null;
                        }
                    }
                    else
                    {
                        word.WronglyConnected(true);
                        if(!currentWord.isJoinableToMultiple)
                        {
                            currentWord.WronglyConnected(false);
                            currentWord = null;
                        }
                        else
                        {
                            currentWord.WronglyConnected(true);
                        }
                    }
                }
            }
            else
            {
                Debug.LogError("Selected word is null");
            }
        }
        else
        {
            currentWord = word;
            if(currentWord != null)
            {
                currentWord.SelectWord(true);
            }
        }
    }
}