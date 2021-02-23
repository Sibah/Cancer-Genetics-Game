using UnityEngine;

public class QuizAudio : MonoBehaviour
{
    public AudioSource source;
    public AudioClip correctClick;
    public AudioClip inCorrectClick;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void CorrectClick()
    {
        source.PlayOneShot(correctClick, 0.5f);
    }

    public void InCorrectClick()
    {
        source.PlayOneShot(inCorrectClick, 1.5f);
    }
}
