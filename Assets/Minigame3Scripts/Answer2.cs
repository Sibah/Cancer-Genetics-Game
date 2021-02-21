using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Answer2 : MonoBehaviour
{
    public Text answerText;
    public static int answernumb;
    public Text sentence;
    public static int sentencenumb;
    public Text pressedText;
    

    public static string[] sentenceList = {"This is second sentence 1 with ? missing", "This is second sentence 2 with ? missing",
     "This is second sentence 3 with ? missing", "This is second sentence 4 with ? missing", "This is second sentence 5 with ? missing", "This is second sentence 6 with ? missing"};

    private static string[] answers = {"2answer1", "2answer2", "2answer3", "2answer4", "2answer5", "2answer6"};



    // Start is called before the first frame update
    void Start()
    {
        sentencenumb = 0;
        answernumb = 1;
        answerText.text = answers[0];
        answerText.color = Color.black;

        sentence.text = sentenceList[0];
    }

    // Update is called once per frame
    void Update()
    {
        //if the clicked answer gives points the this will be done
        if (Score.scoreAmount == answernumb)
        {
            if (pressedText.text == answerText.text)
            {
                answerText.color = Color.green;
                answernumb += 1;
                sentencenumb +=1;
            }
            else
            {
                Score.scoreAmount -= 2;
                answerText.color = Color.red;
                answernumb -= 1;
                sentencenumb +=1;
            }

            //update sentence and change answer back to black
            StartCoroutine(CoroutineChangeVariables());
        }
    }



    IEnumerator CoroutineChangeVariables()
{
    
    yield return new WaitForSeconds(1); // wait for 1 seconds

    //cheks if it was the last sentence of the array, if was returns to main screen
    //otherwise gives next sentence
    if (sentencenumb == sentenceList.Length)
    {
        
        SceneManager.LoadScene(0);
    }
    else
    {
        sentence.text = sentenceList[sentencenumb];
        answerText.color = Color.black;
        answerText.text = answers[sentencenumb];
    
    }
}





}