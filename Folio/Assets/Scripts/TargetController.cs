using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    [SerializeField] private PositionPath pathManager;

    [SerializeField] private float speed;
    [SerializeField] private float speedMultiplier;

    Vector2 initPos;
    Vector2 mousePosX;

    [SerializeField] private float progression;


    private void Update()
    {
        SetSpeed();
        SetProgression();
        MoveTarget();
    }

    void SetSpeed()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            initPos = Input.mousePosition;
            mousePosX = initPos;
        }

        if (Input.GetButtonUp("Fire1"))
        {
            initPos = Vector2.zero;
            speed = 0;
        }

        if (initPos != Vector2.zero)
        {
            mousePosX.y = Input.mousePosition.y;
            speed = Vector2.Distance(mousePosX, Input.mousePosition);

            if (Input.mousePosition.x < mousePosX.x)
            {
                speed = -speed;
            }
            speed /= speedMultiplier;
        }
    }

    private void SetProgression()
    {
        progression = Mathf.Clamp01(progression + speed);
    }

    void MoveTarget()
    {

        transform.position = pathManager.Evaluate(progression);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 0.3f);
    }
}

