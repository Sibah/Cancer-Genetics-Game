using UnityEngine;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{
    public Text answerText;
    public AnswerData answerData;
    private GameController gameController;

    void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }

    public void Setup(AnswerData data)
    {
        answerData = data;
        answerText.text = answerData.answerText;
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
}
