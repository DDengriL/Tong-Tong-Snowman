using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll2 : MonoBehaviour
{
    Rigidbody2D rb;
    private float Dir;
    [SerializeField] float moveSpeed;
 


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
       
    }

    void Update()
    { 
        
            Dir = Input.GetAxis("Horizontal");
            transform.position += new Vector3(Dir, 0, 0) * moveSpeed * Time.deltaTime;
        

    }
}
