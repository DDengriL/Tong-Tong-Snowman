using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScroll : MonoBehaviour
{
    public float movespeed;

    //void Start()
    //{
        
    //}

    void Update()
    {
        transform.position += new Vector3(0, 1) * Time.deltaTime * movespeed;
        if (transform.position.y >= 5 || transform.position.y <= -5)
        {
            transform.position = new Vector2(transform.position.x, 0);
        }


    }
}
