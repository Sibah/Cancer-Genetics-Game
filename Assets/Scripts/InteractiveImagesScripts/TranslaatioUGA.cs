using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TranslaatioUGA : MonoBehaviour
{
    [SerializeField]
    private Transform objectPlace;

    [SerializeField]
    private Sprite UAC2;

    [SerializeField]
    private Sprite UGA2;   

    private Vector2 initialPosition;

    private Vector2 mousePosition;

    private float deltaX, deltaY;

    public static bool locked;

    // Start is called before the first frame update
    void Start() {
        initialPosition = transform.position;
  
    }

    private void OnMouseDown() {
        if (!locked)
        {
            deltaX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
            deltaY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
        }
    }

    private void OnMouseDrag() {
        if (!locked)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(mousePosition.x - deltaX, mousePosition.y - deltaY);
        }
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
    
//        SceneManager.LoadScene("DNAScene");
        
//        Destroy(GameObject.Find("Text"));
//        Destroy(GameObject.Find("Text (1)"));
//        DontDestroyOnLoad(GameObject.Find("Canvas"));
//        GameObject go = GameObject.Find("Text");
//        go.transform.position = new Vector3(700,100,0);
//        go.GetComponent<Text>().text = "Rakenna RNA";
        
//        SceneManager.LoadScene("MainMenu");
            GameObject gobj = GameObject.Find("arrow_right3");
            gobj.GetComponent<SpriteRenderer>().enabled = true;  

        }

    private void OnMouseUp() {
        if (Mathf.Abs(transform.position.x - objectPlace.position.x) <= 0.5f &&
            Mathf.Abs(transform.position.y - objectPlace.position.y) <= 0.5f)
        {
            transform.position = new Vector2(objectPlace.position.x, objectPlace.position.y);
            locked = true;

            this.GetComponent<SpriteRenderer>().sprite = UGA2;
            GameObject go = GameObject.Find("UAC");
            go.GetComponent<SpriteRenderer>().sprite = UAC2;

            transform.position = new Vector3(gameObject.transform.position.x,
            gameObject.transform.position.y + .5f, 0);

            GameObject go2 = GameObject.Find("PlaceholderUGA");
            go2.transform.position = new Vector3(-100,-100, 0);
            
            StartCoroutine(ExecuteAfterTime(.5f));
            
        }
        else
        {
            transform.position = new Vector2(initialPosition.x, initialPosition.y);
        }
    }
}
