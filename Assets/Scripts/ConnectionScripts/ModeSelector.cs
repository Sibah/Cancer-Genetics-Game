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

    // Values Item1 == time
    // Values Item2 == score
    // Values Item3 == correct connection count
    public void ActivateResultScreen(System.Tuple<int, int, int> values)
    {
        wordInit.roundCounter = 0;
        wordInit.ClearOldWords();
        connectionMode.SetActive(false);
        resultScreen.SetActive(true);

        ResultHandler result = resultScreen.GetComponentInChildren<ResultHandler>();
        result.scoreValue = values.Item2;
        result.timeValue = values.Item1;
        result.connectionValue = values.Item3;

        wordInit.pairs = new List<WordPair>();
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
