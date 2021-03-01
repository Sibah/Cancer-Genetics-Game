using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void Mute()
    {
        source.mute = !source.mute;
    }
}
