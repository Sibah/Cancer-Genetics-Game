using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoctorPhaseManager : MonoBehaviour
{
    public GameObject[] cases;
    public GameObject[] phases;
    public Transform currentlyActiveCase;

    void Start() 
    {
        int caseIndex = Random.Range(0, cases.Length);
        currentlyActiveCase = cases[caseIndex].transform; 
        cases[caseIndex].SetActive(true);
        GatherPhases(caseIndex);
    }

    public void ActivatePhase(int index)
    {
        if(index >= phases.Length)
        {
            index = phases.Length-1;
        }

        DeactivatePhases();
        phases[index].SetActive(true);
    }

    private void GatherPhases(int index)
    {
        if(index >= cases.Length)
        {
            index = cases.Length-1;
        }

        if(index < 0)
        {
            index = 0;
        }
        
        Transform currentCase = cases[index].transform;
        GameObject[] currentPhases = new GameObject[currentCase.childCount];

        for(int i = 0; i < currentCase.childCount; i++)
        {
            currentPhases[i] = currentCase.GetChild(i).gameObject;
        }

        phases = currentPhases;
    }

    private void DeactivatePhases()
    {
        foreach(GameObject phase in phases)
        {
            phase.SetActive(false);
        }
    }
}
