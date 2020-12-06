using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeSelector : MonoBehaviour
{
    public GameObject mode1;
    public GameObject selection;
    public Transform database;
    public WordLinePrototypeInitializer wordInit;

    public void SelectMode1()
    {
        mode1.SetActive(true);
        selection.SetActive(false);
        BroadcastMessage("ResetTime", SendMessageOptions.RequireReceiver);
        BroadcastMessage("ResetScore", SendMessageOptions.RequireReceiver);

        //CHANGE TO BE EASIER TO CHANGE "DATABASE"
        wordInit.pairs = database.GetChild(0).GetComponent<WordDatabase>().GetWordPairs();

        wordInit.PlaceWordsInSides();
    }
    
    public void BackToModeSelect()
    {
        mode1.SetActive(false);
        wordInit.pairs = new List<WordPair>();
        selection.SetActive(true);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
