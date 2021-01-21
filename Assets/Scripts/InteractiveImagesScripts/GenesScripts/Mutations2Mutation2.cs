using UnityEngine;
using UnityEngine.UI;

public class Mutations2Mutation2 : MonoBehaviour
{
    [SerializeField]
    private GameObject newLetter;

    private Text text;
    public int errors;

    //Hiirellä klikattaessa geenivirhe korjautuu ja virhelaskuri päivittyy   
    void OnMouseOver(){
        if(Input.GetMouseButtonDown(0)){
            Color color = gameObject.GetComponent<SpriteRenderer>().color;
            color.a = 255;
            gameObject.GetComponent<SpriteRenderer>().color = color;
            newLetter.transform.position = transform.position;

            GameObject go = GameObject.Find("Mutations2Mutation1");
            go.GetComponent<Mutations2Mutation1>().errors--;
            int errors = go.GetComponent<Mutations2Mutation1>().errors;
            Debug.Log(errors);

            GameObject go2 = GameObject.Find("Mutations2ErrorsText");
            text = go2.GetComponent<UnityEngine.UI.Text>();
            text.text = "Virheitä jäljellä: " + errors;
        }
    }
}