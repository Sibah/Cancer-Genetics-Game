using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScores : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        // Tämän ajaminen pitäisi tapahtua ainoastaan kun peli käynnistetään, mutta se ajaa sen jopa myös silloin kun Quiz Gamen pelaamisen jälkeen tulee takaisin MainMenuun?!?!?!?!
        // Muuten homma pelittää
        //PlayerPrefs.DeleteAll();
    }
}
