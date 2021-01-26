using UnityEngine;
using UnityEngine.UI;

public class MutationClicked : MonoBehaviour
{

    [SerializeField]
    private GameObject newLetter;

    private Text text;
    
    //Hiirellä klikattaessa geenivirhe korjautuu ja virhelaskuri päivittyy   
    void OnMouseOver(){
        if(Input.GetMouseButtonDown(0)){
            Color color = gameObject.GetComponent<SpriteRenderer>().color;
            color.a = 255;
            gameObject.GetComponent<SpriteRenderer>().color = color;
            newLetter.transform.position = transform.position;

            GameObject go = GameObject.Find("Mutation1");
            go.GetComponent<Mutation1>().errors--;
            int errors = go.GetComponent<Mutation1>().errors;
      

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
