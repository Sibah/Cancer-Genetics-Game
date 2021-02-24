using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoctorPhaseManager : MonoBehaviour
{
    public GameObject[] phases;

    public void ActivatePhase(int index)
    {
        if(index >= phases.Length)
        {
            index = phases.Length-1;
        }

        DeactivatePhases();
        phases[index].SetActive(true);
    }

    private void DeactivatePhases()
    {
        foreach(GameObject phase in phases)
        {
            phase.SetActive(false);
        }
    }
}
