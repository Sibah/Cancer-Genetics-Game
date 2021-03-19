using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteButton : MonoBehaviour
{
    private MainMenuController mainMenuController;

    private void Start() 
    {
        mainMenuController = FindObjectOfType<MainMenuController>();    
    }

    public void Mute()
    {
        mainMenuController.GetComponent<MainMenuController>().ToggleSound();
    }
}
