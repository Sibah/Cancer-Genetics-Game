using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGameLevel1()
    {
         SceneManager.LoadScene(11);
    }

    public void StartGameLevel2()
    {
         SceneManager.LoadScene(12);
    }

    public void StartMiniGame3()
    {
        SceneManager.LoadScene(10);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    
}
