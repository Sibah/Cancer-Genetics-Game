using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordSpawner : MonoBehaviour
{
    public GameObject wordPrefab;
    public Transform wordCanvas;

   public WordDisplay SpawnWord ()
   {
       Vector3 randomPosition = new Vector3(Random.Range(-7f, 7f), 6f);


       GameObject wordObj = Instantiate(wordPrefab, randomPosition, Quaternion.identity, wordCanvas);
       wordObj.transform.SetAsFirstSibling();
       WordDisplay wordDisplay = wordObj.GetComponent<WordDisplay>();

       return wordDisplay;

   }


}
