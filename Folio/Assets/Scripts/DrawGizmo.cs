using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawGizmo : MonoBehaviour
{
    [SerializeField] private bool focus;

    private void OnDrawGizmos()
    {
        if (focus)
            Gizmos.color = Color.grey;
        else
            Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, 0.3f);
    }
}
