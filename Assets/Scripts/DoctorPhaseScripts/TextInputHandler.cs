using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextInputHandler : MonoBehaviour
{
    public TMP_InputField inputField;

    public void SendInputText()
    {
        SendMessageUpwards("SetSearchText", inputField.text, SendMessageOptions.RequireReceiver);
        inputField.text = "";
        SendMessageUpwards("TestWrittenWord", SendMessageOptions.RequireReceiver);
    }
}
