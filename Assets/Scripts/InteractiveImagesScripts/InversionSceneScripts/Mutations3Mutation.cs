using UnityEngine;
using System;
public class Mutations3Mutation : MonoBehaviour
{

    private bool locked = true;

    private Vector3 startPosition;

    [SerializeField]
    private int rotationSpeed = 50;
    void Update() {
        if (locked == false){
            GameObject go = GameObject.Find("C2");
            go.transform.RotateAround(transform.position, new Vector3(0, 0, 1), rotationSpeed * Time.deltaTime);
            go.transform.rotation = Quaternion.identity;    

            GameObject go2 = GameObject.Find("G");
            go2.transform.RotateAround(transform.position, new Vector3(0, 0, 1), rotationSpeed * Time.deltaTime);
            go2.transform.rotation = Quaternion.identity; 


            GameObject go3 = GameObject.Find("A");
            go3.transform.RotateAround(transform.position, new Vector3(0, 0, 1), rotationSpeed * Time.deltaTime);
            go3.transform.rotation = Quaternion.identity; 


            GameObject go4 = GameObject.Find("A2");
            go4.transform.RotateAround(transform.position, new Vector3(0, 0, 1), rotationSpeed * Time.deltaTime);
            go4.transform.rotation = Quaternion.identity; 
            
            float currentAngle = Vector2.Angle(startPosition - transform.position,
                                           go4.transform.position - transform.position);

            if (currentAngle >= 179){
                rotationSpeed = 0;
                GameObject arrow = GameObject.Find("Arrow");
                arrow.GetComponent<SpriteRenderer>().enabled = true;                 
            }
        }
    }
        
    void OnMouseOver(){
        if(Input.GetMouseButtonDown(0)){
            Color color = gameObject.GetComponent<SpriteRenderer>().color;
            color.a = 255;
            gameObject.GetComponent<SpriteRenderer>().color = color;

            GameObject go = GameObject.Find("C2");
            go.transform.position = new Vector2(transform.position.x+.8f,transform.position.y);
            
            GameObject go2 = GameObject.Find("G");
            go2.transform.position = new Vector2(transform.position.x+.4f,transform.position.y);

            GameObject go3 = GameObject.Find("C");
            go3.transform.position = new Vector2(transform.position.x,transform.position.y);

            GameObject go4 = GameObject.Find("A");
            go4.transform.position = new Vector2(transform.position.x-.4f,transform.position.y);

            GameObject go5 = GameObject.Find("A2");
            go5.transform.position = new Vector2(transform.position.x-.8f,transform.position.y);
            startPosition = go5.transform.position;

            locked = false;
        }
    }
}
