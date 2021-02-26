using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConfirmationHandler : MonoBehaviour
{
    public TextMeshProUGUI titleText;
    private string changableText = "";

    public void ChangeTitleText(string text)
    {
        changableText = text;
        titleText.text = $"Tarkoititko: {text}";
    }


    public void Confirm()
    {
        SendMessageUpwards("CheckConfirmationText", changableText, SendMessageOptions.RequireReceiver);
    } 

    public void Decline()
    {
        gameObject.SetActive(false);
    }
}
