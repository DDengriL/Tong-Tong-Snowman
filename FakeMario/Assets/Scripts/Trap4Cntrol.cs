using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap4Cntrol : MonoBehaviour
{
    Pswitch ps;
    Crush_Brick[] crushs;
    GameObject qblock;

    [SerializeField] GameObject coin;


    void Start()
    {
        crushs = GetComponentsInChildren<Crush_Brick>();
        ps = GetComponentInChildren<Pswitch>();
        qblock = GameObject.Find("PswitchBlock");
    }

    void Update()
    {
        if (ps == null)
        {
            ps = GetComponentInChildren<Pswitch>();
        }
        else if (ps != null)
        {
            if (ps.isP == true)
            {
                ps.isP = false;
                BrickCange();
            }
        }
        
    }

    void BrickCange()
    {
        for (int i = 0; i < crushs.Length; i++)
        {
            GameObject coinins = Instantiate(coin);
            coinins.transform.position = crushs[i].gameObject.transform.position;
        }
        for (int i = 0; i < crushs.Length; i++)
        {
            crushs[i].BlockCrush();
        }
        Destroy(qblock);
    }

}
