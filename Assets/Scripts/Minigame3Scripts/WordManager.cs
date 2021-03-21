using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WordManager : MonoBehaviour
{
    public List<Word> words;

    public WordSpawner wordSpawner;

    void Start() 
    {
        AddWord();
    
    }

    public void AddWord() 
    {

            Word word = new Word(WordGenerator.GetRandomWord(), wordSpawner.SpawnWord());
            words.Add(word);
    
        //Debug.Log(word.word);
    }


}
