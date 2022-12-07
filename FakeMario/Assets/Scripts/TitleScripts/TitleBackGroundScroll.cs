using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleBackGroundScroll : MonoBehaviour
{
    private float Dir;
    [SerializeField] float moveSpeed;


    void Start()
    {
    }

    void Update()
    {
        if (this.gameObject.name == "Player")
        {
            if (transform.position.x <= 0)
            {
                transform.position += new Vector3(-1, 0, 0) * moveSpeed * Time.deltaTime;
            }
        }
        else
        {
            transform.position += new Vector3(-1, 0, 0) * moveSpeed * Time.deltaTime;
        }
    }
}
