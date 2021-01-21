using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void StartQuizGame()
    {
        SceneManager.LoadScene("Persistent");
    }

    public void StartSecondMiniGame()
    {
        SceneManager.LoadScene("ConnectionGame");
    }

    public void StartThirdMiniGame()
    {
        print("3");
    }

    public void StartInteractiveImages()
    {
        SceneManager.LoadScene("SoluScene");
    }

    public void StartBonusGame()
    {
        SceneManager.LoadScene("EndlessRunner");
    }

    public void QuitGame()
    {
        print("game quit");
        Application.Quit();
    }
    public void Study()
    {
        SceneManager.LoadScene("StudyScene");
    }
}
