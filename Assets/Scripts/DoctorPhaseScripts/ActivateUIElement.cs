using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateUIElement : MonoBehaviour
{
    [SerializeField]
    private GameObject ActivatableUIElement;

    public void ActivateElement()
    {
        ActivatableUIElement.SetActive(true);
    }
}
