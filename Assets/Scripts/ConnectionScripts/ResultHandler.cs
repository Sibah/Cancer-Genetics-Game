using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultHandler : MonoBehaviour
{
    [SerializeField]
    private Text correctConnections;
    [SerializeField]
    private Text score;
    [SerializeField]
    private Text time;

    public int connectionValue
    {
        set
        {
            correctConnections.text = $"Oikeita yhdistämisiä: {value}";
        }
    }

    public int scoreValue
    {
        set
        {
            score.text = $"Pisteet: {value}";
        }
    }

    public int timeValue
    {
        set
        {
            time.text = $"Aikaa kului: {value} sekunttia";
        }
    }
}
