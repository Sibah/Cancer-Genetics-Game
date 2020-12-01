using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeSelector : MonoBehaviour
{
    public GameObject mode1;
    public GameObject selection;
    public WordLinePrototypeInitializer wordInit;
    
    public List<string[]> testWords = new List<string[]>();

    public void SelectMode1()
    {
        mode1.SetActive(true);
        selection.SetActive(false);
        BroadcastMessage("ResetTime", SendMessageOptions.RequireReceiver);
        BroadcastMessage("ResetScore", SendMessageOptions.RequireReceiver);
        string[] a = {"aaaa", "AAAA"};
        string[] b = {"bbbb", "BBBB"};
        string[] c = {"cccc", "CCCC"};
        string[] d = {"dddd", "DDDD"};
        string[] e = {"eeee", "EEEE"};
        string[] f = {"ffff", "FFFF"};
        string[] g = {"gggg", "GGGG"};
        testWords.Add(a);
        testWords.Add(b);
        testWords.Add(c);
        testWords.Add(d);
        testWords.Add(e);
        testWords.Add(f);
        testWords.Add(g);
        //CHANGE THIS!!
        foreach(string[] pair in testWords)
        {
            wordInit.pairs.Add(pair);
        }
        wordInit.PlaceWordsInSides();
        testWords.Clear();
    }
    
    public void BackToModeSelect()
    {
        mode1.SetActive(false);
        wordInit.pairs = new List<string[]>();
        selection.SetActive(true);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
