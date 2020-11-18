using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    public void StartFirstMiniGame()
    {
        print(1);
    }

    public void StartSecondMiniGame()
    {
        print(2);
    }

    public void StartThirdMiniGame()
    {
        print(3);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
