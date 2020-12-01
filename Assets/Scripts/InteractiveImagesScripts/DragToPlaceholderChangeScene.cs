using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DragToPlaceholderChangeScene : MonoBehaviour
{
    [SerializeField]
    private Transform objectPlace;

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
    
        SceneManager.LoadScene("DNAScene");
        
//        Destroy(GameObject.Find("Text"));
        Destroy(GameObject.Find("Text (1)"));
        DontDestroyOnLoad(GameObject.Find("Canvas"));
        GameObject go = GameObject.Find("Text");
        go.transform.position = new Vector3(700,100,0);
        go.GetComponent<Text>().text = "Rakenna RNA";
        }

    private void OnMouseUp() {
        if (Mathf.Abs(transform.position.x - objectPlace.position.x) <= 0.5f &&
            Mathf.Abs(transform.position.y - objectPlace.position.y) <= 0.5f)
        {
            transform.position = new Vector2(objectPlace.position.x, objectPlace.position.y);
            locked = true;
            StartCoroutine(ExecuteAfterTime(1));
            
        }
        else
        {
            transform.position = new Vector2(initialPosition.x, initialPosition.y);
        }
    }
}
