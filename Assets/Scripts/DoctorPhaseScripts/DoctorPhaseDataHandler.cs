using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoctorPhaseDataHandler : MonoBehaviour
{
    public string searchText;
    public CorrectString correctText;
    public ConfirmationHandler confirmationBox;
    public StringDatabase database;
    public int nextPhaseIndex;

    public void SetSearchText(string text)
    {
        searchText = text;
    }

    public void TestWrittenWord()
    {
        if(searchText.Length == 0)
        {
            return;
        }

        string closestText = database.FindClosestText(searchText);

        if(closestText == null)
        {
            return;
        }
        
        if(correctText.CheckIfCorrect(closestText) && searchText.Equals(closestText))
        {
            SendMessageUpwards("ActivatePhase", nextPhaseIndex, SendMessageOptions.RequireReceiver);
        }
        else if(!searchText.Equals(closestText))
        {
            confirmationBox.gameObject.SetActive(true);
            confirmationBox.ChangeTitleText(closestText);
        }
    }

    public void CheckConfirmationText(string confirmationText)
    {
        if(correctText.CheckIfCorrect(confirmationText))
        {
            SendMessageUpwards("ActivatePhase", nextPhaseIndex, SendMessageOptions.RequireReceiver);
        }
    }
}
