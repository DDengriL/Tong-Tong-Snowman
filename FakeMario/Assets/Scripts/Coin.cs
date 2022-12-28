using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    SpriteRenderer sr;

    [SerializeField] GameObject coin;
    
    Score score;
    Coin_Text coin_text;
    GameObject coinins;
    public bool istouch = false;
    private bool move = false;
    private bool cantouch = true;
    Color coincolor; 

    private void Start()
    {
        //score = GameObject.Find("ScoreManager").GetComponent<Score>();
        //coin_text = GameObject.Find("GameSystemManager").GetComponent<Coin_Text>();
        sr = GetComponent<SpriteRenderer>();
        coinins = Instantiate(coin);
        coinins.transform.parent = this.transform;
        coincolor = coinins.GetComponent<SpriteRenderer>().color;
        coincolor.a = 0;
        coinins.GetComponent<SpriteRenderer>().color = coincolor;
        coinins.transform.position = transform.position;
    }

    void Update()
    {
        if (istouch && cantouch)
        {
            Debug.Log("cc");
            if (coin.gameObject.name == "Coin")
            {
                //score.score += 100;
                //coin_text.coin_amount++;

            }
            coincolor.a = 1;
            istouch = false;
            cantouch = false;
            move = true;
        }

        if (move)
        {
            coinins.transform.position += new Vector3(0, 3) * Time.deltaTime;
            if (coin.gameObject.name == "Coin")
            {
                if (coinins.transform.position.y >= transform.position.y + 0.6f)
                {
                    coincolor.a -= 0.01f;
                    coinins.GetComponent<SpriteRenderer>().color = coincolor;
                    if (coincolor.a == 0)
                    {
                        move = false;
                    }
                }   
            }
            else if (coin.gameObject.name != "Coin")
            {
                if (coinins.transform.position.y >= transform.position.y + 0.6f)
                {
                    coinins.GetComponent<SpriteRenderer>().color = coincolor;
                    move = false;
                }
            }
        }
    }
}
