using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public Text quizScoreDisplayText;
    public Text connectionScoreDisplayText;
    public Text sentenceScoreDisplayText;
    public Button doctorPhaseButton;

    private void Start()
    {
        SetSoundState();
        DontDestroyOnLoad(this.gameObject);
        if(FindObjectsOfType<MainMenuController>().Length > 1)
        {
            Destroy(this.gameObject);
        }
    }

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

    public void ToggleSound()
    {
        if (PlayerPrefs.GetInt("Muted", 0) == 0)
        {
            PlayerPrefs.SetInt("Muted", 1);
        } else
        {
            PlayerPrefs.SetInt("Muted", 0);
        }
        SetSoundState();
    }

    private void SetSoundState()
    {
        if(PlayerPrefs.GetInt("Muted", 0) == 0)
        {
            AudioListener.volume = 1;
        } else
        {
            AudioListener.volume = 0;
        }
    }

    private void Update()
    {
        int quizScore = PlayerPrefs.GetInt("QuizScore");
        int connectionScore = PlayerPrefs.GetInt("ConnectionScore");
        int sentenceScore = PlayerPrefs.GetInt("HighScore");

        quizScoreDisplayText.text = "Kysymys: " + quizScore.ToString();
        connectionScoreDisplayText.text = "Yhdistely: " + connectionScore.ToString();

        if (quizScore >= 0 && sentenceScore >= 0 && connectionScore >= 0)
        {
            doctorPhaseButton.interactable = true;
        } else
        {
            doctorPhaseButton.interactable = false;
        }
    }
}
