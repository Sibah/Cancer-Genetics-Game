using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{
    public Text answerText;
    private AnswerData answerData;
    private GameController gameController;

    public static AnswerButton _instace;

    private void Awake()
    {
        _instace = this;
    }

    void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }

    public void Setup(AnswerData data)
    {
        answerData = data;
        answerText.text = answerData.answerText;
    }

    IEnumerator ReturnButtonColor()
    {
        yield return new WaitForSeconds(2.9f);
        GetComponent<Button>().image.color = Color.white;
    }

    public void HandeClick()
    {
        gameController.AnswerButtonClicked(answerData.isCorrect);

        if (gameController.IsCorrected())
        {
            GetComponent<Button>().image.color = Color.green;
            StartCoroutine(ReturnButtonColor());
        }
        else
        {
            GetComponent<Button>().image.color = Color.red;
            StartCoroutine(ReturnButtonColor());
        }
    }
}
