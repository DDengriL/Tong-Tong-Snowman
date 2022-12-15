using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundControl : MonoBehaviour
{
    Rigidbody2D rb;
    private float Dir;
    [SerializeField] float moveSpeed;
    Player player;


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        if(!player.isPause)
        {
            Dir = Input.GetAxis("Horizontal");
            transform.position += new Vector3(Dir, 0, 0) * moveSpeed * Time.deltaTime;
        }
        
    }
}
