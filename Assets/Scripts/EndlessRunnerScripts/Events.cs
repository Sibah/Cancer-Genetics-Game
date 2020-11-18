using UnityEngine.SceneManagement;
using UnityEngine;

public class Events : MonoBehaviour
{
    public void ReplayGame()
    {
        SceneManager.LoadScene("EndlessRunner");
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
