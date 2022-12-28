using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackGroundControl : MonoBehaviour
{
    Rigidbody2D rb;
    private float Dir;
    [SerializeField] float moveSpeed;
    Player player;
    Transform player_transform;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        player_transform = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        if(!player.isPause && !player.isdead)
        {
            Dir = Input.GetAxis("Horizontal");
            if(player_transform.position.y > 7.5f)
            {
                transform.position += new Vector3(Dir, 0, 0) * moveSpeed * Time.deltaTime;
            }
            else
            {
                transform.position += new Vector3(Dir, 0, 0) * moveSpeed * Time.deltaTime;
            }
            
        }
        else if(!player.isPause && !player.isdead && player_transform.position.y <= -4.5f)
        {
            transform.position = new Vector2(transform.position.x, player_transform.position.y);
        }
        
    }
}
