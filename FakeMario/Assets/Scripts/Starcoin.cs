using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starcoin : MonoBehaviour
{
    Animator anim;
    CircleCollider2D col;

    Vector3 targetpos;

    Vector3 velocity = Vector3.zero;

    Vector3 tmp;

    Color color;
    SpriteRenderer sr;

    float t = 0;
    bool b = false;
    bool p = false;
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        color = sr.color;
        color.a = 1;
        sr.color = color;
        tmp = transform.position;
        targetpos = transform.position + new Vector3(0, 0.7f, 0);
        anim = GetComponent<Animator>();
        col = GetComponent<CircleCollider2D>();
        if(anim == null)
        {
            Debug.LogError("null");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            col.enabled = false;
            Debug.Log("Collected");

            b = true;
            
            
        }
    }

    private void Update()
    {
        if(b)
        {
            transform.position = Vector3.SmoothDamp(transform.position, targetpos, ref velocity, 0.1f);
            Invoke("motion2", 0.6f);
            Invoke("P", 0.3f);
        }
        if (p)
        {
            color.a -= Time.deltaTime;
            sr.color = color;
            if (color.a <= 0)
            {
                p = false;
            }
        }
    }

    void P() => p = true;

    void motion2()
    {
        b = false;
        transform.position = Vector3.SmoothDamp(transform.position, tmp, ref velocity, 0.1f);
    }

    private void Starcoin_Collect()
     {
     }


}
