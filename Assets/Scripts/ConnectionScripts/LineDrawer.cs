using UnityEngine;
using System.Collections;

public class LineDrawer : MonoBehaviour
{
    public Object linePrefab;
    public Camera mainCamera;
    public WordHandler currentWord;
    // Update is called once per frame
    void Update()
    {

    }

    private Vector3 ScreenToWorld(Vector3 position)
    {
        Vector3 newPosition = mainCamera.ScreenToWorldPoint(position);
        newPosition.z = -898f;
        return newPosition;
    }

    public void HandleNewPositionData(WordHandler word)
    {
        if(currentWord != null && word != null)
        {
            if(currentWord.GetConnectedWord() == null)
            {
                if(word.GetConnectedWord() == null)
                {
                    if(currentWord.onRightSide != word.onRightSide)
                    {
                        Vector3 startPosition = currentWord.GetLinePointPosition();
                        Vector3 endPosition = word.GetLinePointPosition();
                        LineRenderer line = ((GameObject)Instantiate(linePrefab, ((GameObject)GameObject.Find("Lines")).transform)).GetComponentInChildren<LineRenderer>();
                        Vector3[] positions = { startPosition, endPosition };
                        line.SetPositions(positions);
                        currentWord.SetConnectedWord(word);
                        word.SetConnectedWord(currentWord);
                        currentWord = null;
                    }
                }
            }
            else
            {
                currentWord = null;
            }
        }
        else
        {
            currentWord = word;
        }
    }
}