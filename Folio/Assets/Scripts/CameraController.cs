using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform posTarget;
    [SerializeField] private Transform focusTarget;

    [SerializeField] private float smoothingMovingValue;

    private void Update()
    {
        MoveCamera();
        MoveFocus();
    }

    private void MoveCamera()
    {
        transform.position = Vector3.Lerp(transform.position, posTarget.position, smoothingMovingValue);
    }

    private void MoveFocus()
    {
        transform.LookAt(focusTarget);
    }
}
