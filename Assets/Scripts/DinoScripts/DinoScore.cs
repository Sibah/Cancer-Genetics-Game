using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DinoScore : MonoBehaviour
{
    public Text HIScoreText;
    int score;
    Text scoreText;
    float timer;
    float maxTime;
    //AudioSource scoreSound;

    // Start is called before the first frame update
    void Start()
    {
        //HIScoreText.text = "HI     " + PlayerPrefs.GetInt("highscore", 0).ToString("00000");
        score = 0;
        scoreText = GetComponent<Text>();
        maxTime = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= maxTime)
        {
            score++;
            scoreText.text = score.ToString("00000");
            timer = 0;
            //if(score % 100 == 0)
            //{
                //scoreSound.Play();
            //}
        }
    }
}
