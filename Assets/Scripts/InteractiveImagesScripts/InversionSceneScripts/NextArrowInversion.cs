using UnityEngine;
using UnityEngine.SceneManagement;

public class NextArrowInversion : MonoBehaviour
{
    void Start() {
        GetComponent<SpriteRenderer>().enabled = false;
    }
    void OnMouseOver(){
        if(Input.GetMouseButtonDown(0)){
            SceneManager.LoadScene("InsertionScene");
        }
    }
}
