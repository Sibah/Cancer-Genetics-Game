using UnityEngine;
using System.Collections;

public class LineDrawer : MonoBehaviour
{
    public Object linePrefab;
    public Transform lines;
    public Camera mainCamera;
    public WordHandler currentWord;
    public float removalTime = 0.25f;

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
                        LineRenderer line = ((GameObject)Instantiate(linePrefab, lines)).GetComponent<LineRenderer>();
                        line.SetPositions(new Vector3[] { currentWord.GetLinePointPosition(), word.GetLinePointPosition() } );
                    }
                    else
                    {
                        currentWord.WronglyConnected(true);
                        if(currentWord.GetSavedWordPair().connectionCount == 1)
                        {
                            currentWord.WronglyConnected(false);
                            currentWord = null;
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