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
            //TODO: Make wrong answer possibility
            return;
        }
        
        if(correctText.Contains(searchText) || (correctText.CheckIfCorrect(closestText) && searchText.Equals(closestText)))
        {
            SendMessageUpwards("ActivatePhase", nextPhaseIndex, SendMessageOptions.RequireReceiver);
            //TODO: Make correct answer possibility
            return;
        }
        else if(!searchText.Equals(closestText))
        {
            confirmationBox.gameObject.SetActive(true);
            //TODO: Make confirmation check
            return;
        }
    }
}
