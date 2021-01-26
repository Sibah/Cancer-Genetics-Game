using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public Text quizScoreDisplayText;
    public Button doctorPhaseButton;

    public void StartQuizGame()
    {
        SceneManager.LoadScene("Persistent");
    }

    public void StartSecondMiniGame()
    {
        SceneManager.LoadScene("ConnectionGame");
    }

    public void StartThirdMiniGame()
    {
        print("3");
    }

    public void StartInteractiveImages()
    {
        SceneManager.LoadScene("SoluScene");
    }

    public void StartBonusGame()
    {
        SceneManager.LoadScene("EndlessRunner");
    }

    public void QuitGame()
    {
        print("game quit");
        Application.Quit();
    }
    public void Study()
    {
        SceneManager.LoadScene("StudyScene");
    }

    public void DoctorPhase()
    {
        SceneManager.LoadScene("DoctorPhase");
    }

    private void Update()
    {
        int quizScore = PlayerPrefs.GetInt("QuizScore");
        quizScoreDisplayText.text = "Quiz: " + quizScore.ToString();
        if (quizScore >= 500)
        {
            doctorPhaseButton.interactable = true;
        } else
        {
            doctorPhaseButton.interactable = false;
        }
    }
}
