using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pswitch : MonoBehaviour
{
    public bool isP;

    void Dest()
    {
        Destroy(this.gameObject);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isP = true;
            Invoke("Dest", 0.5f);
        }
    }
}
