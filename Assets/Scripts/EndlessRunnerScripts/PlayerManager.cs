using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public static bool gameOver;
    public GameObject gameOverPanel;

    public static bool isRunning;
    public GameObject startButton;

    void Start()
    {
        gameOver = false;
        Time.timeScale = 1;
        isRunning = false;
    }

    void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }

        if (SwipeManager.tap)
        {
            isRunning = true;
            Destroy(startButton);
        }
    }
}
