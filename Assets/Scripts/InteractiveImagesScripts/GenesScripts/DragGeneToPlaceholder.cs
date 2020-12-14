using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragGeneToPlaceholder : MonoBehaviour
{
    [SerializeField]
    public Transform objectPlace;

    private Vector2 initialPosition;

    private Vector2 mousePosition;

    private float deltaX, deltaY;

    public bool locked;

    // Start is called before the first frame update
    void Start() {
        initialPosition = transform.position;
        locked = false;
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

    private void OnMouseUp() {
        if (Mathf.Abs(transform.position.x - objectPlace.position.x) <= 0.2f &&
            Mathf.Abs(transform.position.y - objectPlace.position.y) <= 0.2f)
        {
            GameObject clone = (GameObject)Instantiate(gameObject, initialPosition, Quaternion.identity);
            //scale 0.6f for ios
//           transform.localScale = new Vector3(1.5f, 1.5f, 0);
            transform.position = new Vector2(objectPlace.position.x, objectPlace.position.y);
            locked = true;

        }
        else
        {
            transform.position = new Vector2(initialPosition.x, initialPosition.y);
        }
    }

    public bool OnPlace() {
        return locked;
    }
}
