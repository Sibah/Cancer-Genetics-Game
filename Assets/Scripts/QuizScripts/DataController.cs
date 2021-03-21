using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataController : MonoBehaviour
{
    public static DataController instance = null;
    public RoundData[] allRoundData;

    void Start()
    {
        SceneManager.LoadScene("MenuScreen");

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }

    public RoundData GetCurrentRoundData()
    {
        return allRoundData[0];
    }
}
