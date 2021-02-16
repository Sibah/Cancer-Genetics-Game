using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public void ResetScene(){
        Debug.Log("testi");
        SceneManager.LoadScene("DeletionScene");
    }
}