using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crush_Brick : MonoBehaviour
{
    Rigidbody2D[] rb;

    void Start()
    {
        rb = GetComponentsInChildren<Rigidbody2D>();
        for (int i = 0; i < rb.Length; i++)
        {
            Debug.Log(rb[i].name);
        }
    }

    void AutoDes()
    {
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && collision.gameObject.transform.position.y < transform.position.y - 0.3f)
        {
            for (int i = 0; i < rb.Length; i++)
            {
                rb[i].bodyType = RigidbodyType2D.Dynamic;
                rb[i].gravityScale = 2;

                Invoke("AutoDes", 1f);

                if (i == 0)
                {
                    rb[i].AddForce(new Vector2(-1, 0.8f) * 100);
                }
                else if (i == 1)
                {
                    rb[i].AddForce(new Vector2(1, 0.8f) * 100);
                }
                else if (i == 2)
                {
                    rb[i].AddForce(new Vector2(-1, 1.2f) * 100);
                }
                else if (i == 3)
                {
                    rb[i].AddForce(new Vector2(1, 1.2f) * 100);
                }
            }
        }
    }

}
