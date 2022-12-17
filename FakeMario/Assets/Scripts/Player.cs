using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator ani;

    Vector2 tmp;

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

    Color color;

    void Start()
    {
        tmp = transform.position;
        ani = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        temp = jumpPower;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(!isPause)
        {
            if (canjump == false && rb.velocity.y < -1)
            {
                ani.SetBool("islanding", true);
                ani.SetBool("isjump", false);
            }

            if (Input.GetKeyDown(KeyCode.C) && canjump == true)
            {
                ani.SetBool("isjump", true);
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
                    Y = 17;
                }
                if (canDe)
                {
                    Y -= 0.1f;
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
                moveSpeed = moveSpeed + 5 * Time.deltaTime;
            }

            if (rb.velocity.x > 0.5)
            {
                ani.SetBool("ismove", true);
                if (rb.velocity.x > 0)
                {
                sr.flipX = false;
                }
            }
            if (rb.velocity.x < 0.5)
            {
                ani.SetBool("ismove", true);
                if (rb.velocity.x < 0)
                {
                sr.flipX = true;
                }
            }
            if (rb.velocity.x < 0.5 && rb.velocity.x > -0.5)
            {
                ani.SetBool("ismove", false);
                
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

    void respawn()
    {
        color.a = 1;
        sr.color = color;
        transform.position = tmp;
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            canjump = true;
        }   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        canHold = false;
        rb.velocity = new Vector2(rb.velocity.x, 0);

        if (collision.gameObject.tag == "Ground")
        {
            ani.SetBool("islanding", false);
            canjump = true;
        }

        if (collision.gameObject.tag == "deadzone")
        {
            color = gameObject.GetComponent<SpriteRenderer>().color;
            color.a = 0;
            sr.color = color;
            Invoke("respawn", 3);
        }
    }

    private void OnCollisionExit2D(Collision2D collision) 
    {
        if (collision.gameObject.tag == "Ground")
        {
            
            canjump = false;
        }
    }

    


}
