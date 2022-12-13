using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float smoothing;
    [SerializeField] float yPos;
    Vector3 velocity = Vector3.zero;


    void Update()
    {
        Vector3 finalTarget = new Vector3(target.position.x, yPos, -10);

        transform.position = Vector3.SmoothDamp(transform.position,  finalTarget, ref velocity, smoothing);
    }
}
