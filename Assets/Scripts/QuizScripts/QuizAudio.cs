using UnityEngine;

public class QuizAudio : MonoBehaviour
{
    public AudioSource source;
    public AudioClip correctClick;
    public AudioClip inCorrectClick;
    private MainMenuController mainMenuController;

    void Start()
    {
        source = GetComponent<AudioSource>();
        mainMenuController = FindObjectOfType<MainMenuController>();
    }

    public void CorrectClick()
    {
        source.PlayOneShot(correctClick, 0.5f);
    }

    public void InCorrectClick()
    {
        source.PlayOneShot(inCorrectClick, 1.5f);
    }

    public void Mute()
    {
        mainMenuController.GetComponent<MainMenuController>().ToggleSound();
    }

}
