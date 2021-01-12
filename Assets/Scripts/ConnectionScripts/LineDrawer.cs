using UnityEngine;
using System.Collections;

public class LineDrawer : MonoBehaviour
{
    public Object linePrefab;
    public Camera mainCamera;
    public WordHandler currentWord;
    public float removalTime = 0.25f;

    public void DrawLine(WordHandler word)
    {
        if(currentWord != null && word != null)
        {
            if(currentWord.GetConnectedWord() == null)
            {
                if(word.GetConnectedWord() == null)
                {
                    if(currentWord.onRightSide != word.onRightSide)
                    {
                        currentWord.SetConnectedWord(word);
                        word.SetConnectedWord(currentWord);
                        if(currentWord.CheckIfConnectedToCorrectPair())
                        {
                            Vector3 startPosition = currentWord.GetLinePointPosition();
                            Vector3 endPosition = word.GetLinePointPosition();
                            LineRenderer line = ((GameObject)Instantiate(linePrefab, ((GameObject)GameObject.Find("Lines")).transform)).GetComponentInChildren<LineRenderer>();
                            Vector3[] positions = { startPosition, endPosition };
                            currentWord.SetConnectedLine(line.gameObject);
                            line.SetPositions(positions);
                            BroadcastMessage("IncrementScore", SendMessageOptions.RequireReceiver);
                            IEnumerator coroutine = currentWord.RemoveWordPair(removalTime);
                            StartCoroutine(coroutine);
                            currentWord = null;
                        }
                        else
                        {
                            //ADD SFX
                            BroadcastMessage("ReduceTime", 5, SendMessageOptions.RequireReceiver);
                            currentWord.SelectWord(false);
                            word.SelectWord(false);
                            currentWord.ResetConnection();
                            word.ResetConnection();
                        }
                    }
                }
            }
            else
            {
                currentWord.SelectWord(false);
                currentWord = null;
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