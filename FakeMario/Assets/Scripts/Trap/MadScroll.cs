using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MadScroll : MonoBehaviour
{
    PlatformScroll ps;

    private bool canpluse = true;

    void Start()
    {
        ps = GetComponentInParent<PlatformScroll>();
    }

    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (canpluse)
            {
                ps.movespeed = -10;
                canpluse = false;
            }
            
        }
    }

}
