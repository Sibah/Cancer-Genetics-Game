using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{
    public Text answerText;
    public AnswerData answerData;
    public int correctClicks;
    private GameController gameController;
    public int perQuestionCount;

    private AnswerButton instance;

    void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }

    public void Setup(AnswerData data)
    {
        answerData = data;
        answerText.text = answerData.answerText;
        correctClicks = 0;
        GetComponent<Button>().image.color = Color.white;
    }

    public void ButtonClick()
    {
        correctClicks++;
    }

    public void HandeClick()
    {
        if (answerData.isCorrect)
        {
            ButtonClick();
            GetComponent<Button>().image.color = Color.green;
        } else if (!answerData.isCorrect)
        {
            GetComponent<Button>().image.color = Color.red;
        }
    }

    private void Update()
    {
        if (correctClicks == gameController.correctAnswers.Count)
        {
            gameController.correctAnswers.Clear();
            gameController.AnswerButtonClicked(answerData.isCorrect);
        }
    }
}
