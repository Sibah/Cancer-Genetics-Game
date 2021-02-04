using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinePositionKeeper : MonoBehaviour
{
    public Transform firstPoint;
    public Transform secondPoint;
    public LineRenderer line;

    // Update is called once per frame
    void Update()
    {
        if(line != null && (firstPoint != null && secondPoint != null))
        {
            line.SetPositions(new Vector3[] { firstPoint.position, secondPoint.position });
        }
    }

    public void SetPoints(Transform first, Transform second)
    {
        firstPoint = first;
        secondPoint = second;
    }
}
