using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinOb : MonoBehaviour
{
    Score score;
    Coin_Text coin_text;

    void Start()
    {
        score = GameObject.Find("ScoreManager").GetComponent<Score>();
        coin_text = GameObject.Find("GameSystemManager").GetComponent<Coin_Text>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            score.score += 100;
            coin_text.coin_amount++;
            Destroy(this.gameObject);
        }
    }
}
