using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeSelector : MonoBehaviour
{
    public GameObject mode1;
    public GameObject selection;
    public GameObject instructions;
    public WordLineInitializer wordInit;
    public WordDatabase currentDatabase;

    public void SelectMode1()
    {
        mode1.SetActive(true);
        selection.SetActive(false);
        instructions.SetActive(false);
        BroadcastMessage("ResetTime", SendMessageOptions.RequireReceiver);
        BroadcastMessage("ResetScore", SendMessageOptions.RequireReceiver);

        //CHANGE TO BE EASIER TO CHANGE "DATABASE"
        // currentDatabase = database.GetChild(0).GetComponent<WordDatabase>();
        wordInit.pairs = currentDatabase.GetWordPairs();

        wordInit.PlaceWordsInSides();
    }
    
    public void BackToModeSelect()
    {
        wordInit.roundCounter = 0;
        wordInit.ClearOldWords();
        mode1.SetActive(false);
        wordInit.pairs = new List<WordPair>();
        selection.SetActive(true);
        instructions.SetActive(true);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
