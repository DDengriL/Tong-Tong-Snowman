using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap1 : MonoBehaviour
{
    [SerializeField] GameObject[] briks;

    void Start()
    {
        for (int i = 0; i < briks.Length; i++)
        {
            Debug.Log(briks[i].name);
            briks[i].SetActive(false);
        }
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            for (int i = 0; i < briks.Length; i++)
            {
                briks[i].SetActive(true);
            }
        }
    }
}
