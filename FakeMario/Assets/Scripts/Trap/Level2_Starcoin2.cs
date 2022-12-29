using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
public class Level2_Starcoin2 : MonoBehaviour
{
    [Header("Invisible Tiles")]
    [SerializeField] private SpriteRenderer[] tiles = new SpriteRenderer[6];


    bool alphazero = false;
    Color color;
    // Start is called before the first frame update
    void Start()
    {
        color = tiles[0].color;
        color.a = 1;
        for(int i = 0; i < 5; i++)
        {
            tiles[i].color = color;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        tiles[0].color = color;
        tiles[1].color = color;
        tiles[2].color = color;
        tiles[3].color = color;
        tiles[4].color = color;
        tiles[5].color = color;



        if(alphazero)
        {
            if (color.a >= 0)
            {
                color.a -= 6 * Time.deltaTime;
            }
        }
        else
        {
            if (color.a <= 1)
            {
                color.a += 6 * Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            alphazero = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            alphazero= false;
        }
    }
}
