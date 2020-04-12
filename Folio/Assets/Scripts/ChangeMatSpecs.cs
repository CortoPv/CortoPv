using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMatSpecs : MonoBehaviour
{
    [SerializeField] private Material mat;
    [SerializeField] private Color initColor;
    [SerializeField] private Color resultColor;
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
        initColor = mat.color;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeColor();
    }

    void ChangeColor()
    {
        if (Input.GetKey(KeyCode.E))
        {
            mat.color = Color.Lerp(initColor, resultColor, Time.time * speed);
        }
    }

}
