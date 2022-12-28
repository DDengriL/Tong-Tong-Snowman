using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fake_Brick : MonoBehaviour
{
    SpriteRenderer sr;
    
    Color color;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        
        color = sr.color;
        color.a = 0;
        sr.color = color;
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.transform.position.y < transform.position.y - 0.3f)
            {
                
                color.a = 1;
                sr.color = color;
            }
        }
    }
}
