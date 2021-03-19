using UnityEngine;
using UnityEngine.SceneManagement;

public class StudyController : MonoBehaviour
{
    private MainMenuController mainMenuController;

    private void Start()
    {
        mainMenuController = FindObjectOfType<MainMenuController>();
    }

    public void BackToMainMenuFromStudy()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Mute()
    {
        mainMenuController.GetComponent<MainMenuController>().ToggleSound();
    }
}
