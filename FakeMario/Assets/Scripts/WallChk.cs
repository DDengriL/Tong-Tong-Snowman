using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class WallChk : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerrb;
    [SerializeField] Player player;

    GroundChk gchk;

    private bool iswall;


    void Start()
    {
        gchk = GameObject.Find("GroundChk").GetComponent<GroundChk>();
       
    }

    void Update()
    {
        if (iswall && !gchk.isGround && !player.isdead)
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
