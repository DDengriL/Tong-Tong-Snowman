using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float smoothing;

    Vector3 velocity = Vector3.zero;


    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, target.position + new Vector3(0, 3, -10), ref velocity, smoothing);
    }
}
