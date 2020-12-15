using UnityEngine;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{
    public Text answerText;
    public AnswerData answerData;
    public int correctClicks;
    private GameController gameController;

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
        gameController.correctClickCount++;
    }

    public void HandeClick()
    {
        if (answerData.isCorrect)
        {
            ButtonClick();
            GetComponent<Button>().image.color = Color.green;
        } else if (!answerData.isCorrect)
        {
            gameController.timeRemaining -= 5f;
            GetComponent<Button>().image.color = Color.red;
        }
    }

    private void Update()
    {
        if (gameController.correctClickCount == gameController.correctAnswers.Count)
        {
            gameController.correctAnswers.Clear();
            gameController.AnswerButtonClicked(answerData.isCorrect);
            gameController.correctClickCount = 0;
        }
    }
}
