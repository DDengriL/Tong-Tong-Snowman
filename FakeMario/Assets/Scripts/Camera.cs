using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float smoothing;
    [SerializeField] float yPos;
<<<<<<< HEAD
=======

>>>>>>> 096d312e489d92bb9c786fe0882be79d5c36855f
    Vector3 velocity = Vector3.zero;


    void Update()
    {
        Vector3 finalTarget = new Vector3(target.position.x, yPos, -10);

        transform.position = Vector3.SmoothDamp(transform.position,  finalTarget, ref velocity, smoothing);
    }
}
