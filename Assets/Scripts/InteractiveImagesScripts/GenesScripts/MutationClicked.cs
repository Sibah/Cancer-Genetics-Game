using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutationClicked : MonoBehaviour
{
       void OnMouseOver(){
        if(Input.GetMouseButtonDown(0)){
            Color color = gameObject.GetComponent<SpriteRenderer>().color;
            color.a = 255;
            gameObject.GetComponent<SpriteRenderer>().color = color;
        }
    }
}
