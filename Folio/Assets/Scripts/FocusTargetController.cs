using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusTargetController : MonoBehaviour
{
    [SerializeField] private Transform focusControlPoint;
    [SerializeField] private float smoothingRotationValue;

    

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector3.Lerp(transform.position, focusControlPoint.position, smoothingRotationValue);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, 0.3f);
    }
}
