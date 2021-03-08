using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordTimer : MonoBehaviour
{
    public WordManager wordManager;

    public float wordDelay = 10f;
    private float nextWordTime = 0f;

    private void Update()
    {
        if (Time.time >= nextWordTime)
        {
            wordManager.AddWord();
            nextWordTime = Time.time + wordDelay;

            //increase the speed of falling words
            //wordDelay *= .99f;
        }
    }
}
