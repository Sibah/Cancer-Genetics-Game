using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishHandler : MonoBehaviour
{
    public Transform rightSide;
    public Transform leftSide;
    public Transform lines;
    public Text score;
    public Text timer;
    public float startTime = 5;
    public float time;
    public int scorePoints;
    public int pointGain = 5;
    public WordLineInitializer initializer;

    private void Update() 
    {
        time -= Time.deltaTime;
        timer.text = ((int)time).ToString();  
        if((int)time <= 0)
        {
            FinishGame();
        }  
    }

    public void FinishGame()
    {
        // Values Item1 == time
        // Values Item2 == score
        print(time);
        System.Tuple<int, int> values = new System.Tuple<int, int>((int)(startTime-time), scorePoints);
        print(values);

        SendMessageUpwards("ActivateResultScreen", values, SendMessageOptions.RequireReceiver);
    }

    public void FinishRound()
    {
        int lineCount = lines.childCount;
        int rightCount = rightSide.childCount;
        int leftCount = leftSide.childCount;
        for(int i = 0; i < lineCount; i++)
        {
            Destroy(lines.GetChild(0).gameObject);
        }
        
        for(int i = 0; i < rightCount; i++)
        {
            Destroy(rightSide.GetChild(0).gameObject);
        }

        for(int i = 0; i < leftCount; i++)
        {
            Destroy(leftSide.GetChild(0).gameObject);
        }

        initializer.PlaceWordsInSides();
    }

    public void IncrementScore()
    {
        scorePoints += pointGain;

        score.text = scorePoints.ToString();
    }

    public void ResetTime()
    {
        time = startTime;
    }

    public void ResetScore()
    {
        scorePoints = 0;
        score.text = scorePoints.ToString();
    }

    public void ReduceTime(int value)
    {
        time -= value;
    }
}
