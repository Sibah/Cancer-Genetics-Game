using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeSelector : MonoBehaviour
{
    public GameObject startScreen;
    public GameObject connectionMode;
    public GameObject resultScreen;
    public GameObject dataObjects;
    public GameObject startPhase1;
    public GameObject startPhase2;
    public GameObject startPhase3;
    public WordLineInitializer wordInit;
    public WordDatabase currentDatabase;

    public void SelectBasisOfGenetics()
    {
        GoToPhase1();
        currentDatabase = dataObjects.transform.GetChild(1).GetComponent<WordDatabase>();
        SelectConnectionMode();
    }

    public void SelectCancerGenetics()
    {
        GoToPhase1();
        currentDatabase = dataObjects.transform.GetChild(0).GetComponent<WordDatabase>();
        SelectConnectionMode();
    }

    public void GoToPhase1()
    {
        startPhase1.SetActive(true);
        startPhase2.SetActive(false);
        startPhase3.SetActive(false);
    }

    public void GoToPhase2()
    {
        startPhase1.SetActive(false);
        startPhase2.SetActive(true);
        startPhase3.SetActive(false);
    }

    public void GoToPhase3()
    {
        startPhase1.SetActive(false);
        startPhase2.SetActive(false);
        startPhase3.SetActive(true);
    }

    public void SelectRoundAmount(int amount)
    {
        switch(amount)
        {
            case 0:
                return;
            case 1:
                wordInit.roundAmount = 0;
                break;
            case 2:
                wordInit.roundAmount = 2;
                break;
            case 3:
                wordInit.roundAmount = 3;
                break;
            case 4: 
                wordInit.roundAmount = 4;
                break;
            case 5:
                wordInit.roundAmount = 5;
                break;
            default:
                Debug.LogError($"Unknown value given from dropdown field in start screen phase 2: {amount}");
                break;
        }
        startPhase2.GetComponentInChildren<UnityEngine.UI.Dropdown>().value = 0;
        GoToPhase3();
    }

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
        GoToPhase1();
        resultScreen.SetActive(false);
        connectionMode.SetActive(false);
        startScreen.SetActive(true);
    }

    // Values Item1 == time
    // Values Item2 == score
    // Values Item3 == correct connection count
    public void ActivateResultScreen(System.Tuple<int, int> values)
    {
        wordInit.roundCounter = 0;
        wordInit.ClearOldWords();
        connectionMode.SetActive(false);
        resultScreen.SetActive(true);

        ResultHandler result = resultScreen.GetComponentInChildren<ResultHandler>();
        result.scoreValue = values.Item2;
        result.timeValue = values.Item1;

        wordInit.pairs = new List<WordPair>();
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
