using UnityEngine;
using UnityEngine.SceneManagement;

public class NextArrowMutations1Scene : MonoBehaviour
{
    // Start is called before the first frame update

    void Start() {
        GetComponent<SpriteRenderer>().enabled = false;
    }
    void OnMouseOver(){
        if(Input.GetMouseButtonDown(0)){
            SceneManager.LoadScene("Mutations2Scene");
        }
    }
}
