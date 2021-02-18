using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateUIElement : MonoBehaviour
{
    [SerializeField]
    private GameObject activatableUIElement;

    public void ActivateElement()
    {
        int childCount = activatableUIElement.transform.parent.childCount;
        activatableUIElement.transform.SetSiblingIndex(childCount-1);
        activatableUIElement.SetActive(!activatableUIElement.activeSelf);
    }
}
