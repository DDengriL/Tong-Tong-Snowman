using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2_BlockFallDown : MonoBehaviour
{
    private bool isCollision = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            isCollision = true;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isCollision = true;
        }
    }

    private void Update()
    {
        if(isCollision)
        {
            gameObject.transform.Translate(0, -15 * Time.deltaTime, 0);
        }
    }
}
