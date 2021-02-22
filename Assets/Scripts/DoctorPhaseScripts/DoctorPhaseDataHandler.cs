﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoctorPhaseDataHandler : MonoBehaviour
{
    public string searchText;
    public string correctText;
    public ConfirmationHandler confirmationBox;
    public CancerStringDatabase database;

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
        
        if(closestText.Equals(correctText) && searchText.Equals(closestText))
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
