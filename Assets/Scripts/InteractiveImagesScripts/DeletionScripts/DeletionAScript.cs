using UnityEngine;
using UnityEngine.UI;

public class DeletionAScript : MonoBehaviour
{
    private Vector2 initialPosition;

    private Vector2 mousePosition;

    private float deltaX, deltaY;

    private bool locked;

    private Text text;

    public int errors;


    // Start is called before the first frame update
    void Start() {
        initialPosition = transform.position;
        locked = false;
        
//        GameObject go = GameObject.Find("ErrorsText");
//        text = go.GetComponent<UnityEngine.UI.Text>();
//        text.text = "Virheitä jäljellä: " + errors;
    }

    private void OnMouseDown() {
        if(!locked){
            deltaX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
            deltaY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
        }
    }

    private void OnMouseDrag() {
        if(!locked){
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(mousePosition.x - deltaX, mousePosition.y - deltaY);
        }
    }

  

    private void OnMouseUp() {
        float x = transform.position.x;
        float y = transform.position.y;

        GameObject goMin = GameObject.Find("GPlaceA");
        float yRef = goMin.transform.position.y;
        float xMin = goMin.transform.position.x;

        GameObject goMax = GameObject.Find("TPlaceA");
        float xMax = goMax.transform.position.x;

        if (x > xMin && x < xMax && y > yRef -0.1f && y < yRef +0.1f)
        {
            locked = true;
            transform.position = new Vector2(mousePosition.x - deltaX, mousePosition.y - deltaY);
            GameObject clone = (GameObject)Instantiate(gameObject, initialPosition, Quaternion.identity);
            errors--;

            if (errors == 0)
            {
                
            }
        }else{
            transform.position = initialPosition;   
        }
    }
}
