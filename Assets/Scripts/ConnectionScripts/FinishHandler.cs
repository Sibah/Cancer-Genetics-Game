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
    public float time;
    public int scorePoints;
    public WordLinePrototypeInitializer initializer;

    private void Update() 
    {
        time += Time.deltaTime;
        timer.text = ((int)time).ToString();    
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
        
        time = 0;
        scorePoints += GetAllCorrectAnswers();

        score.text = scorePoints.ToString();

        initializer.PlaceWordsInSides();
    }

    public int GetAllCorrectAnswers()
    {
        int counter = 0;
        for(int i = 0; i < rightSide.childCount; i++)
        {
            if(rightSide.GetChild(i).GetComponentInChildren<WordHandler>().CheckIfConnectedToCorrectPair())
            {
                counter++;
            }
        }
        return counter;
    }

}
