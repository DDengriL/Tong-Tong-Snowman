using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballRotate : MonoBehaviour
{
    [SerializeField] float rotatespeed;
    private float t;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(0, 0, rotatespeed * Time.deltaTime);

        if (transform.localRotation.z >= 360)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
