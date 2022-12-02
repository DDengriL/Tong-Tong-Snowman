using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class WallChk : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerrb;

    private bool iswall;


    void Start()
    {

    }

    void Update()
    {
        if (iswall)
        {
            playerrb.velocity = new Vector2(playerrb.velocity.x, -7);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            iswall = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            iswall = false;
        }
    }
}
