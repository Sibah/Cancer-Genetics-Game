using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineInitializer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LineRenderer line = GetComponent<LineRenderer>();
        line.startWidth = 1;
        line.endWidth = 1;
        line.startColor = Color.black;
        line.endColor = Color.black;   
    }
}
