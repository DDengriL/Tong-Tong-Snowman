using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CreditLight : MonoBehaviour
{
    Light2D light;
    private bool isplayer;

    void Start()
    {
        light = GetComponentInChildren<Light2D>();
    }

    void Update()
    {
        if (isplayer)
        {
            light.intensity = 3;
        }
        else
        {
            light.intensity = 1.2f;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isplayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isplayer = false;
        }
    }
}
