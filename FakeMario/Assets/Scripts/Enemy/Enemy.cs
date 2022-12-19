using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    SpriteRenderer sr;
    Animator ani;
    Player player;

    private int isright = 1;

    [SerializeField] float speed;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        ani = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        transform.position += new Vector3(1 * isright * speed, 0) * Time.deltaTime;
    }

    void Die()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DirSwitch")
        {
            isright *= -1;
            if (sr.flipX)
            {
                sr.flipX = false;
            }
            else if (!sr.flipX)
            {
                sr.flipX = true;
            }

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.transform.position.y > transform.position.y + 1f)
            {
                gameObject.layer = 7;
                ani.SetBool("isdie", true);
                Invoke("Die", 0.5f);
            }
            else
            {
                StartCoroutine(player.Respawn());
                player.gameObject.layer = 9;
            }
        }
    }


}
