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
    public float roundTime;
    public int scorePoints;
    public int pointGain = 5;
    public WordLineInitializer initializer;
    private float totalTime;

    private void Update() 
    {
        roundTime -= Time.deltaTime;
        totalTime += Time.deltaTime;
        timer.text = ((int)roundTime).ToString();  
        if((int)roundTime <= 0)
        {
            FinishGame();
        }  
    }

    public void FinishGame()
    {
        // Values Item1 == totalTime
        // Values Item2 == score
        int connectionScore = PlayerPrefs.GetInt("ConnectionScore");
        if(connectionScore < scorePoints)
        {
            PlayerPrefs.SetInt("ConnectionScore", scorePoints);
        }
        System.Tuple<int, int> values = new System.Tuple<int, int>((int)(totalTime), scorePoints);

        SendMessageUpwards("ActivateResultScreen", values, SendMessageOptions.RequireReceiver);
    }

    public void FinishRound()
    {        
        ResetTime();
        initializer.PlaceWordsInSides();
    }

    public void IncrementScore()
    {
        scorePoints += pointGain;

        score.text = scorePoints.ToString();
    }

    public void ResetTime()
    {
        roundTime = startTime;
    }

    public void ResetScore()
    {
        scorePoints = 0;
        score.text = scorePoints.ToString();
    }

    public void ReduceTime(int value)
    {
        roundTime -= value;
    }
}
