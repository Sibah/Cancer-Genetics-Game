using UnityEngine;
using UnityEngine.SceneManagement;

public class NextArrowSoluScene : MonoBehaviour
{

    void Start() {
        GetComponent<SpriteRenderer>().enabled = false;
    }
    void OnMouseOver(){
        if(Input.GetMouseButtonDown(0)){
            SceneManager.LoadScene("DNAScene");
        }
    }
}
