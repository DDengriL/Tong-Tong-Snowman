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
    private bool canHold = false;

    private float temp;

    private float F = 0.01666f;
    private float Y;
    private bool canDe;

    public bool isPause = false;

    void Start()
    {
        temp = jumpPower;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(!isPause)
        {
            if (Input.GetKeyDown(KeyCode.C) && canjump == true)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);

                rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                canjump = false;
                Invoke("Hold", 0.1f);
                Invoke("HoldC", 0.3f);
                Invoke("Yde", 0.2f);
            }
            if (Input.GetKey(KeyCode.C))
            {
                if (!canHold)
                {
                    Y = 20;
                }
                if (canDe)
                {
                    Y -= 0.2f;
                }

                if (canHold)
                    rb.velocity = new Vector2(rb.velocity.x, Y);
            }
            if (Input.GetKeyUp(KeyCode.C))
            {
                canDe = false;
                canHold = false;
                jumpPower = temp;
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
        
    }

    void Hold() => canHold = true;
    void HoldC() => canHold = false;
    void Yde() => canDe = true;



    private void RunCheck()
    {
        if (Input.GetAxis("Horizontal") == 0 && canjump == true)
        {
            moveSpeed = 2;
        }
    }


    void FixedUpdate()
    {
        if(!isPause)
        {
            Dir = Input.GetAxis("Horizontal") * moveSpeed;
            rb.velocity = new Vector2(Dir, rb.velocity.y);
        }
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        canHold = false;
        rb.velocity = new Vector2(rb.velocity.x, 0);

        if (collision.gameObject.tag == "Ground")
        {
            canjump = true;
        }
    }

}
