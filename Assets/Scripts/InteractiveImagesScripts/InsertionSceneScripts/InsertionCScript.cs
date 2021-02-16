using UnityEngine;
using UnityEngine.UI;

public class InsertionCScript : MonoBehaviour
{
    private Text text;
    public int errors;

    private bool drop;

    //Alustetaan teksti
    void Start() {
        GameObject go = GameObject.Find("ErrorsText");
        text = go.GetComponent<UnityEngine.UI.Text>();
        text.text = "Virheitä jäljellä: " + errors;
    }
    
    void Update() {
        if (drop){
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.01f);
        }
    }
    //Hiirellä klikattaessa geenivirhe korjautuu ja virhelaskuri päivittyy   
    void OnMouseOver(){
        if(Input.GetMouseButtonDown(0)){
 //           transform.position = new Vector2(transform.position.x,transform.position.y-0.1f);
            drop = true;
            errors--;
            text.text = "Virheitä jäljellä: " + errors;
        }
    }
}
