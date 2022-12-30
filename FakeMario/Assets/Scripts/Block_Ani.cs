using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_Ani : MonoBehaviour
{
    Animator ani;
    private bool playerTouch;
    private bool canTouch = true;
    Coin coin;

    public bool Fire;

    private void Start()
    {
        coin = GetComponent<Coin>();
        ani = GetComponent<Animator>();
    }

    void Update()
    {
        if (playerTouch && canTouch)
        {
            playerTouch = false;
            
            transform.position += new Vector3(0, 0.1f);
            Invoke("TouchAni2", 0.01666f);
            canTouch = false;
        }
    }

    private void TouchAni2()
    {
        transform.position += new Vector3(0, 0.1f);
        transform.localScale += new Vector3(0.1f, 0.1f);
        Invoke("TouchAni3", 0.01666f);
    }
    private void TouchAni3()
    {
        transform.position += new Vector3(0, 0.1f);
        transform.localScale += new Vector3(0.1f, 0.1f);
        Invoke("TouchAni4", 0.01666f);
    }
    private void TouchAni4()
    {
        transform.position += new Vector3(0, 0.1f);
        transform.localScale += new Vector3(0.1f, 0.1f);
        Invoke("TouchAni5", 0.01666f);
    }
    private void TouchAni5()
    {
        //transform.position += new Vector3(0, 0.08f);
        transform.localScale += new Vector3(0.1f, 0.1f);
        Invoke("TouchAni6", 0.01666f);
    }
    private void TouchAni6()
    {
        transform.localScale += new Vector3(0.08f, 0.08f);
        Invoke("TouchAni7", 0.01666f);
    }
    private void TouchAni7()
    {
        transform.localScale += new Vector3(0.02f, 0.02f);
        Invoke("TouchAni8", 0.01666f);
    }
    //---------------------------------UP------------------------------------------
    private void TouchAni8()
    {
        transform.position -= new Vector3(0, 0.038f);
        transform.localScale -= new Vector3(0.024f, 0.024f);
        Invoke("TouchAni9", 0.01666f);
    }
    private void TouchAni9()
    {
        transform.position -= new Vector3(0, 0.098f);
        transform.localScale -= new Vector3(0.144f, 0.144f);
        Invoke("TouchAni10", 0.01666f);
    }
    private void TouchAni10()
    {
        transform.position -= new Vector3(0, 0.068f);
        transform.localScale -= new Vector3(0.084f, 0.084f);
        Invoke("TouchAni11", 0.01666f);
    }
    private void TouchAni11()
    {
        transform.position -= new Vector3(0, 0.068f);
        transform.localScale -= new Vector3(0.084f, 0.084f);
        Invoke("TouchAni12", 0.01666f);
    }
    private void TouchAni12()
    {
        transform.position -= new Vector3(0, 0.068f);
        transform.localScale -= new Vector3(0.084f, 0.084f);
        Invoke("TouchAni13", 0.01666f);
    }
    private void TouchAni13()
    {
        transform.position -= new Vector3(0, 0.06f);
        transform.localScale -= new Vector3(0.08f, 0.08f);
        ani.SetBool("isTouch", true);
    }
    //---------------------------------Down------------------------------------------





    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.transform.position.y < transform.position.y - 0.3f)
            {
                Fire = true;
                coin.istouch = true;   
                playerTouch = true;
            }
        }
    }



}
