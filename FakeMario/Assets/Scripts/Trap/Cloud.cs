using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    Color color;
    SpriteRenderer sr;
    [SerializeField] Sprite img;

    private bool invi;


    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        color = sr.color;
        color.a = 0;
        sr.color = color;
        
    }

    void Update()
    {
        if (invi)
        {
            color.a += 3 * Time.deltaTime;
            sr.color = color;
            if (color.a >= 1)
            {
                invi = false;
            }
        }
    }

    private void Srchange()
    {
        sr.sprite = img;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Invoke("Srchange", 0.5f);
            invi = true;
        }
    }
}
