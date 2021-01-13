using UnityEngine;
using UnityEngine.SceneManagement;

public class StudyController : MonoBehaviour
{
    public void BackToMainMenuFromStudy()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
