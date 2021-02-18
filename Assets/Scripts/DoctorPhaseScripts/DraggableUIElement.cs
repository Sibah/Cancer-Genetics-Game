using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// Put this to every child object and the draggable parent object to make the UI element draggable
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
        int childCount = dragTarget.transform.parent.childCount;
        dragTarget.transform.SetSiblingIndex(childCount-1);
        isDragging = true;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;
    }
}
