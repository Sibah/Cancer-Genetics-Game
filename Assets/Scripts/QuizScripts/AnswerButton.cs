using UnityEngine;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{
    public Text answerText;
    public AnswerData answerData;
    private GameController gameController;
    public QuizAudio quizAudio;

    void Start()
    {
        quizAudio = FindObjectOfType<QuizAudio>();
        gameController = FindObjectOfType<GameController>();
    }

    public void Setup(AnswerData data)
    {
        answerData = data;
        answerText.text = answerData.answerText;
        GetComponent<Button>().image.color = Color.white;
        GetComponent<Button>().interactable = true;
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
            GetComponent<Button>().interactable = false;
            quizAudio.CorrectClick();
        } else if (!answerData.isCorrect)
        {
            gameController.timeRemaining -= 5f;
            GetComponent<Button>().image.color = Color.red;
            GetComponent<Button>().interactable = false;
            quizAudio.InCorrectClick();
        }
    }
}
