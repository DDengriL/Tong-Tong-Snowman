using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credit : MonoBehaviour
{
    SpriteRenderer sr;

    Color color;

    private bool isinv;

    void Start()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
        color = sr.color;
        color.a = 0;
        sr.color = color;
    }

    void Update()
    {
        if (isinv)
        {
            if (color.a <= 1) 
            {
                color.a += 0.01f;
                sr.color = color;
            }
        }
        else if (!isinv)
        {
            if (color.a >= 0) 
            {
                color.a -= 0.01f;
                sr.color = color;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isinv = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isinv = false;
        }
    }
}
