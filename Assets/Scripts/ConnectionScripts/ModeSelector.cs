using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeSelector : MonoBehaviour
{
    public GameObject startScreen;
    public GameObject connectionMode;
    public GameObject resultScreen;
    public WordLineInitializer wordInit;
    public WordDatabase currentDatabase;

    public void SelectConnectionMode()
    {
        connectionMode.SetActive(true);
        startScreen.SetActive(false);
        BroadcastMessage("ResetTime", SendMessageOptions.RequireReceiver);
        BroadcastMessage("ResetScore", SendMessageOptions.RequireReceiver);

        //CHANGE TO BE EASIER TO CHANGE "DATABASE"
        // currentDatabase = database.GetChild(0).GetComponent<WordDatabase>();
        wordInit.pairs = currentDatabase.GetWordPairs();

        wordInit.PlaceWordsInSides();
    }
    
    public void BackToModeSelect()
    {
        resultScreen.SetActive(false);
        startScreen.SetActive(true);
    }

    public void ActivateResultScreen()
    {
        wordInit.roundCounter = 0;
        wordInit.ClearOldWords();
        connectionMode.SetActive(false);
        resultScreen.SetActive(true);
        wordInit.pairs = new List<WordPair>();
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
