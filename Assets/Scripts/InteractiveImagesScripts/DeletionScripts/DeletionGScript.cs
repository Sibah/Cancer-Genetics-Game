using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletionGScript : MonoBehaviour
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
        float x = transform.position.x;
        float y = transform.position.y;

        GameObject goMin = GameObject.Find("CPlaceG1");
        float yRef = goMin.transform.position.y;
        float xMin = goMin.transform.position.x;

        GameObject goMax = GameObject.Find("C2PlaceG1");
        float xMax = goMax.transform.position.x;

        GameObject goMin2 = GameObject.Find("GPlaceG2");
        float xMin2 = goMin2.transform.position.x;

        GameObject goMax2 = GameObject.Find("APlaceG2");
        float xMax2 = goMax2.transform.position.x;

        GameObject goMin3 = GameObject.Find("CPlaceG3");
        float xMin3 = goMin3.transform.position.x;

        GameObject goMax3 = GameObject.Find("APlaceG3");
        float xMax3 = goMax3.transform.position.x;
        
        if (x > xMin && x < xMax || x > xMin2 && x < xMax2 || x > xMin3 && x < xMax3 && y > yRef -0.1f && y < yRef +0.1f)
        {
            locked = true;
            transform.position = new Vector2(mousePosition.x - deltaX, mousePosition.y - deltaY);
            GameObject clone = (GameObject)Instantiate(gameObject, initialPosition, Quaternion.identity);

            GameObject gobj = GameObject.Find("AMoving");
            gobj.GetComponent<DeletionAScript>().errors--;
            int errors = gobj.GetComponent<DeletionAScript>().errors;
            if (errors == 0)
            {
                
            }

        }else{
            transform.position = initialPosition;   
        }
    }
}
