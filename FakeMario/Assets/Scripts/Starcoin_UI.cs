using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Starcoin_UI : MonoBehaviour
{
    [Header("StarCoin")]
    [SerializeField] private Image Starcoin_1;
    [SerializeField] private Image Starcoin_2;
    [SerializeField] private Image Starcoin_3;

    [SerializeField] private Transform StarCoin_tf1;
    [SerializeField] private Transform StarCoin_tf2;
    [SerializeField] private Transform StarCoin_tf3;

    [Header("StarCoin Sprite")]
    [SerializeField] private Sprite Starcoin_Fill;
    [SerializeField] private Sprite Starcoin_Blank;

    public bool coin_1_collect = false;
    public bool coin_2_collect = false;
    public bool coin_3_collect = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StarCoin();   
    }


    private void StarCoin()
    {
        // Starcoin 1
        if (coin_1_collect)
        {
            StarCoin_tf1.localScale = new Vector3(1.3f, 1.3f, 1.3f);
            Starcoin_1.sprite = Starcoin_Fill;
        }
        else
        {
            StarCoin_tf1.localScale = new Vector3(1, 1, 1);
            Starcoin_1.sprite = Starcoin_Blank;
        }

        // Starcoin 2
        if (coin_2_collect)
        {
            StarCoin_tf2.localScale = new Vector3(1.3f, 1.3f, 1.3f);
            Starcoin_2.sprite = Starcoin_Fill;
        }
        else
        {
            StarCoin_tf2.localScale = new Vector3(1, 1, 1);
            Starcoin_2.sprite = Starcoin_Blank;
        }

        // Starcoin 3
        if (coin_3_collect)
        {
            StarCoin_tf3.localScale = new Vector3(1.3f, 1.3f, 1.3f);
            Starcoin_3.sprite = Starcoin_Fill;
        }
        else
        {
            StarCoin_tf3.localScale = new Vector3(1, 1, 1);
            Starcoin_3.sprite = Starcoin_Blank;
        }
    }
}
