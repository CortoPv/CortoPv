using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path
{
    public List<Vector3> waypoints;

    public int segmentIndex;

    public float speed;

    float lerpValue;
    

    public Vector3[] currentSegment => Segments(segmentIndex);

    public Vector3[] Segments(int index)
    {
        Vector3[] result = new Vector3[2] { waypoints[index], waypoints[index + 1] };
        return result;
    }

    public Vector3[] CurrentSegment()
    {
        return Segments(segmentIndex);
    }

    public int SetIndex(int currentIndex, float lerpValue)
    {
        if (lerpValue >= 1)
        {
            currentIndex++;
            lerpValue --;
        }
        if (lerpValue <= 0)
        {
            currentIndex--;
            lerpValue ++;
        }

        return currentIndex;
    }

    public Vector3 SetPosition(Vector3[] currentSegment, int currentIndex, float speed)
    {
        Vector3 result;
        lerpValue = Mathf.Clamp(lerpValue + speed, -0.1f, 1.1f);

        if (lerpValue >= 1 || lerpValue <= 0)
        {
            SetIndex(currentIndex, lerpValue);
        }
        result = Vector3.Lerp(currentSegment[0], currentSegment[1], lerpValue);
        return result;

    }
}
