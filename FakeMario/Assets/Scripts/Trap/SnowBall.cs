using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBall : MonoBehaviour
{
    [SerializeField] float speed;

    //void Start()
    //{
        
    //}

    void Update()
    {
        transform.position += new Vector3(-1 * speed, 0) * Time.deltaTime; 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Debug.Log("Aa");
            Destroy(this.gameObject);
        }
    }
}
