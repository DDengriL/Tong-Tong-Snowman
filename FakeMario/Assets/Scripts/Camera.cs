using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.Windows.WebCam;

public class Camera : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float smoothing;
    [SerializeField] float yPos;

    [SerializeField] Player player;

    Vector3 velocity = Vector3.zero;


    void Update()
    {
        if (target.position.y > 7.5)
        {
            yPos = 11.27f;
        }
        else if(target.position.y <=7.5f && target.position.y > -4.5f)
        {
            yPos = 0.27f;
        }
        /*else
        {
            yPos = -4f;
        }*/


        Vector3 finalTarget = new Vector3(target.position.x, yPos, -50);

        if(!player.isdead)
        transform.position = Vector3.SmoothDamp(transform.position,  finalTarget, ref velocity, smoothing);
    }
}
