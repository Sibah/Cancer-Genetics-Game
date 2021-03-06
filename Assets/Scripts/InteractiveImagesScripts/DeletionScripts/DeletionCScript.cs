using UnityEngine;

public class DeletionCScript : MonoBehaviour
{
    private Vector2 initialPosition;

    private Vector2 mousePosition;

    private float deltaX, deltaY;

    private bool locked;


    // Start is called before the first frame update
    void Start() {
        initialPosition = transform.position;
        locked = false;
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
        transform.position = initialPosition;
    }
}
