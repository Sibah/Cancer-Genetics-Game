using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public Text quizScoreDisplayText;
    public Text connectionScoreDisplayText;
    public Text sentenceScoreDisplayText;
    public Button doctorPhaseButton;
    static MainMenuController instance;

    public int quizScore = 0;
    public int connectionScore = 0;
    public int sentenceScore = 0;
    public string sceneName = "MainMenu";

    private void Start()
    {
        SetSoundState();
    }

    void Awake()
    {
        quizScore = PlayerPrefs.GetInt("QuizScore");
        connectionScore = PlayerPrefs.GetInt("ConnectionScore");
        sentenceScore = PlayerPrefs.GetInt("HighScore");

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else if (instance != this)
        {
            Destroy(instance.gameObject);
            instance = this;
            DontDestroyOnLoad(gameObject);
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
        Application.Quit();
    }

    public void ResetPoints()
    {
        PlayerPrefs.DeleteKey("QuizScore");
        PlayerPrefs.DeleteKey("ConnectionScore");
        PlayerPrefs.DeleteKey("HighScore");

        quizScore = 0;
        connectionScore = 0;
        sentenceScore = 0;
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
        if (sceneName == SceneManager.GetActiveScene().name)
        {
            quizScoreDisplayText.text = "Kysymys: " + quizScore.ToString();
            connectionScoreDisplayText.text = "Yhdistely: " + connectionScore.ToString();

            if (quizScore >= 1 && sentenceScore >= 1 && connectionScore >= 1)
            {
                doctorPhaseButton.interactable = true;
            }
            else
            {
                doctorPhaseButton.interactable = false;
            }
        }
    }
}
