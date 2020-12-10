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
    public WordLinePrototypeInitializer initializer;

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
        for(int i = 0; i < lines.childCount; i++)
        {
            Destroy(lines.GetChild(i).gameObject);
        }
        
        for(int i = 0; i < rightSide.childCount; i++)
        {
            Destroy(rightSide.GetChild(i).gameObject);
            Destroy(leftSide.GetChild(i).gameObject);
        }

        initializer.PlaceWordsInSides();
    }

    public void IncrementScore()
    {
        scorePoints++;

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
