using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBallType2 : MonoBehaviour
{
    [SerializeField] int speed;
    Rigidbody2D rb;
    private float xran;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        xran = Random.RandomRange(-5, 5);
        rb.AddForce(new Vector3(xran, 40), ForceMode2D.Impulse);
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);
        }
    }
}
