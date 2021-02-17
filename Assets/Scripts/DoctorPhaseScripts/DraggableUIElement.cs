using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableUIElement : EventTrigger
{
    public bool isDragging;
    public DragTarget dragTarget;

    void Start() 
    {
        dragTarget = GetComponentInParent<DragTarget>();    
    }
    // Update is called once per frame
    void Update()
    {
        if (isDragging)
        {
            dragTarget.transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        print("start");
        isDragging = true;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        print(eventData);
        isDragging = false;
    }
}
