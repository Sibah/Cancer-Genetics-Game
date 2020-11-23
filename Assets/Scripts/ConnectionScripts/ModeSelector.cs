using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeSelector : MonoBehaviour
{
    public GameObject mode1;
    public GameObject mode2;
    public GameObject mode3;
    public WordLinePrototypeInitializer wordInit;
    
    public List<string[]> testWords = new List<string[]>();

    public void SelectMode1()
    {
        mode1.SetActive(true);
        mode2.SetActive(false);
        mode3.SetActive(false);
        gameObject.SetActive(false);
        string[] a = {"aaaa", "AAAA"};
        string[] b = {"bbbb", "BBBB"};
        string[] c = {"cccc", "CCCC"};
        string[] d = {"dddd", "DDDD"};
        testWords.Add(a);
        testWords.Add(b);
        testWords.Add(c);
        testWords.Add(d);
        //CHANGE THIS!!
        wordInit.pairs = testWords;
        wordInit.PlaceWordsInSides();
    }

    public void SelectMode2()
    {
        mode1.SetActive(false);
        mode2.SetActive(true);
        mode3.SetActive(false);
        gameObject.SetActive(false);
    }

    public void SelectMode3()
    {
        mode1.SetActive(false);
        mode2.SetActive(false);
        mode3.SetActive(true);
        gameObject.SetActive(false);
    }

    private void test(){}
}
