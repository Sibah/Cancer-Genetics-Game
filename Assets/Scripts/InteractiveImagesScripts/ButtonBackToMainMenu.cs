using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBackToMainMenu : MonoBehaviour
{
    public void onButtonPress() { 
        SceneManager.LoadScene("MainMenu"); 
        Debug.Log("testi");      
    }
}
