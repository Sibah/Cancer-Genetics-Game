using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class TextButton : MonoBehaviour, IPointerClickHandler
{
    public GameObject wordPrefab;
    public Text newText;
    public Text answerText;



    

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        newText.text =  wordPrefab.GetComponent<Text>().text;
        Score.scoreAmount += 1;

        if (Score.scoreAmount > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", Score.scoreAmount);
        }
        
        StartCoroutine(CoroutineRemoveWord());
    }


    IEnumerator CoroutineRemoveWord()
{
    yield return new WaitForSeconds(1); // wait for 1 seconds      
        //Destroy(wordPrefab);
        DestroyImmediate (wordPrefab, true);
}

    public void Start()
    {
        
    }

    public void Update()
    {
        
    }

}