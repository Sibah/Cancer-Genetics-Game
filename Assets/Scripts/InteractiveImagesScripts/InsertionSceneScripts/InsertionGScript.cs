using UnityEngine;
using UnityEngine.UI;
public class InsertionGScript : MonoBehaviour
{
    private bool drop;

    private Text text;
    
    void Update() {
        if (drop){
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.01f);
        }
    }
    //Hiirellä klikattaessa geenivirhe korjautuu ja virhelaskuri päivittyy   
    void OnMouseOver(){
        if(Input.GetMouseButtonDown(0)){
            drop = true;
            
            GameObject go = GameObject.Find("C");
            go.GetComponent<InsertionCScript>().errors--;
            int errors = go.GetComponent<InsertionCScript>().errors;

            GameObject go2 = GameObject.Find("ErrorsText");
            text = go2.GetComponent<UnityEngine.UI.Text>();
            text.text = "Virheitä jäljellä: " + errors;
            if (errors == 0){
                GameObject gobj = GameObject.Find("Arrow");
                gobj.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
    }
}
