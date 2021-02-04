﻿using System.Collections;
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
    public WordLineInitializer initializer;

    private void Update() 
    {
        time -= Time.deltaTime;
        timer.text = ((int)time).ToString();  
        if((int)time <= 0)
        {
            //UPDATE TO CONNECT TO MAIN PROJECT!
            SendMessageUpwards("BackToModeSelect", SendMessageOptions.RequireReceiver);
        }  
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
        scorePoints += 5;

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
