using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class InvisibleTile : MonoBehaviour
{
    Color color;
    Tilemap tm;

    private bool isPlayer;
    private bool exitPlayer;
    
    void Start()
    {
        tm = GetComponent<Tilemap>();
        color = tm.color;
        color.a = 1;
        tm.color = color;
    }

    void Update()
    {
        if (isPlayer)
        {
            if (color.a >= 0)
            {
                color.a -= Time.deltaTime * 2;
                tm.color = color;
            }
            else if (color.a <= 0)
            {
                isPlayer = false;
            }
        }

        if (exitPlayer)
        {
            if (color.a <= 1)
            {
                color.a += Time.deltaTime * 2;
                tm.color = color;
            }
            else if (color.a >= 1)
            {
                exitPlayer = false;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!isPlayer)
            {
                isPlayer = true;
                exitPlayer = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            exitPlayer = true;
            isPlayer = false;
        }
    }

}
