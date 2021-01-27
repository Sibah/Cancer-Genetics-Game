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
            if(currentWord.GetConnectedWords() == null)
            {

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