using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MadSnowball : MonoBehaviour
{
    SnowBallFire sbf;
    Coin coin;
    Block_Ani ani;

    private bool cantouch = true;

    void Start()
    {
        ani = GetComponentInChildren<Block_Ani>();
        sbf = GetComponent<SnowBallFire>();
        coin = GetComponentInChildren<Coin>();

    }

    void Update()
    {
        if (ani.Fire)
        {
            ani.Fire = false;
            Debug.Log("AA");
            sbf.coolT = 0.3f;
            StartCoroutine(sbf.SnowballFire2());
        }
    }
}
