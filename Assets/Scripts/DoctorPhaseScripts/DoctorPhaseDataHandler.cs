using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoctorPhaseDataHandler : MonoBehaviour
{
    public string searchText;
    public CorrectString correctText;
    public ConfirmationHandler confirmationBox;
    public StringDatabase database;

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
        
        if(correctText.CheckIfCorrect(closestText) && searchText.Equals(closestText))
        {
            //TODO: Make correct answer possibility
            return;
        }
        else if(!searchText.Equals(closestText))
        {
            //TODO: Make confirmation check
            return;
        }
    }
}
