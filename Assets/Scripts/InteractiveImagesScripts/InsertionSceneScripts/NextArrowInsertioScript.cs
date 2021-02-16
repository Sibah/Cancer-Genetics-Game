using UnityEngine;
using UnityEngine.SceneManagement;

public class NextArrowInsertioScript : MonoBehaviour
{
    void Start() {
        GetComponent<SpriteRenderer>().enabled = false;
    }
    void OnMouseOver(){
        if(Input.GetMouseButtonDown(0)){
            SceneManager.LoadScene("DeletionScene");
        }
    }
}
