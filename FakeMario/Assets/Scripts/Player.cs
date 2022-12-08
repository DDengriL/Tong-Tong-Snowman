using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;

    private float Dir;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpPower;

    [SerializeField] float Wdis;

    private int isright;
    private bool canjump = false;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && canjump == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);

            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            canjump = false;

        }

        if (Input.GetAxis("Horizontal") == 0 && canjump == true)
        {
            Invoke("RunCheck", 3f);
        }

        if (Input.GetAxis("Horizontal") != 0 && moveSpeed < 7)
        {
            moveSpeed = moveSpeed + 4 * Time.deltaTime;
        }

        if (rb.velocity.x > 0)
        {
            isright = 1;
        }
        if (rb.velocity.x < 0)
        {
            isright = -1;
        }

        if (rb.velocity.y != 0)
        {
            Debug.Log(rb.velocity.y);
        }
    }

    private void RunCheck()
    {
        if (Input.GetAxis("Horizontal") == 0 && canjump == true)
        {
            moveSpeed = 2;
        }
    }


    void FixedUpdate()
    {
        Dir = Input.GetAxis("Horizontal") * moveSpeed;
        rb.velocity = new Vector2(Dir, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            canjump = true;
        }
    }

}
