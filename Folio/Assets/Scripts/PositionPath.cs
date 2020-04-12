using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Segment
{
    public int id;
    public Vector3 startPos;
    public Vector3 endPos;
    public float length;
    public float startDist;
    public float endDist;

    public Segment(int _id,Vector3 _startPos, Vector3 _endPos, float _startDist)
    {
        id = _id;
        startPos = _startPos;
        endPos = _endPos;
        length = Vector3.Distance(startPos, endPos);
        startDist = _startDist;
        endDist = startDist + length;
    }

    public Vector3 GetPosOnPath(float _currentDist)
    {
        float currentDist = (_currentDist - startDist) / (endDist - startDist);
        return Vector3.Lerp(startPos, endPos, currentDist);
    }
}

public class PositionPath : MonoBehaviour
{
    public List<Segment> segments = new List<Segment>();

    public float totalDist;

    private void Awake()
    {
        SetSegments();
    }

    public void SetSegments()
    {
        totalDist = 0;

        for (int i = 0; i < transform.childCount - 1; i++)
        {
            segments.Add(new Segment(i, transform.GetChild(i).transform.position, transform.GetChild(i + 1).transform.position, totalDist));
            totalDist += segments[i].length;
        }

    }

    public Segment GetCorrectSegment(float _currentDist)
    {
        float subDist = _currentDist;
        int index = 0;

        if (_currentDist == 0f)
        {
            return segments[0];
        }

        while (subDist > 0f)
        {
            subDist -= segments[index].length;
            index++;
        }

        return segments[index - 1];
    }

    public Vector3 Evaluate(float t)
    {
        float currentDist = t * totalDist;

        Segment segment = GetCorrectSegment(currentDist);
        return segment.GetPosOnPath(currentDist);

    }

    private void OnDrawGizmos()
    {
        List<Vector3> children = new List<Vector3>();

        for (int i = 0; i < transform.childCount; i++)
        {
            children.Add(transform.GetChild(i).position);
        }

        Gizmos.color = Color.red;
        for (int i = 0; i < children.Count - 1; i++)
        {
            Gizmos.DrawLine(children[i], children[i + 1]);
        }
    }
}
