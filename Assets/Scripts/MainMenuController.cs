using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public Text quizScoreDisplayText;
    //public Text connectionScoreDisplayText;
    //public Text sentenceScoreDisplayText;
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
        SceneManager.LoadScene("StartScreen");
    }

    public void StartInteractiveImages()
    {
        SceneManager.LoadScene("SoluScene");
    }

    public void StartBonusGame()
    {
        SceneManager.LoadScene("DinoGame");
    }

    public void QuitGame()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.DeleteAll();
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
        //int connectionScore = PlayerPrefs.GetInt("ConnectionScore");
        //int sentenceScore = PlayerPrefs.GetInt("SentenceScore");

        quizScoreDisplayText.text = "Quiz: " + quizScore.ToString();
        //connectionScoreDisplayText.text = "Quiz: " + connectionScore.ToString();
        //sentenceScoreDisplayText.text = "Quiz: " + sentenceScore.ToString();

        if (quizScore >= 0) // (quizScore >= 200 && connectionScore >= 100 && sentenceScore >= 15) What are the high enough highscores?
        {
            doctorPhaseButton.interactable = true;
        } else
        {
            doctorPhaseButton.interactable = false;
        }
    }
}
