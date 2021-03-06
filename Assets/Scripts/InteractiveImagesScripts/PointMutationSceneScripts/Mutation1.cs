using UnityEngine;
using UnityEngine.UI;

public class Mutation1 : MonoBehaviour
{

    [SerializeField]
    private GameObject newLetter;

    private Text text;
    public int errors;

    //Alustetaan teksti
    void Start() {
        GameObject go = GameObject.Find("ErrorsText");
        text = go.GetComponent<UnityEngine.UI.Text>();
        text.text = "Virheitä jäljellä: " + errors;
    }
    
    //Hiirellä klikattaessa geenivirhe korjautuu ja virhelaskuri päivittyy   
    void OnMouseOver(){
        if(Input.GetMouseButtonDown(0)){
            Color color = gameObject.GetComponent<SpriteRenderer>().color;
            color.a = 255;
            gameObject.GetComponent<SpriteRenderer>().color = color;
            newLetter.transform.position = transform.position;

            errors--;
            text.text = "Virheitä jäljellä: " + errors;
            if (errors == 0){
                GameObject gobj = GameObject.Find("Arrow");
               gobj.GetComponent<SpriteRenderer>().enabled = true;
            }            
        }
    }
}
