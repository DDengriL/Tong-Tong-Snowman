using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChk : MonoBehaviour
{
    public bool isGround;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = false;
        }
    }
}
