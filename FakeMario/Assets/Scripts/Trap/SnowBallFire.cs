using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBallFire : MonoBehaviour
{
    public bool canFire;
    public bool stop;
    public float coolT;
    [SerializeField] float offSetx;
    [SerializeField] float offSety;

    [SerializeField] GameObject snowball;

    //void Start()
    //{
        
    //}

    void Update()
    {
        if (canFire)
        {
            canFire = false;
            //StopCoroutine(SnowballFire());
            StartCoroutine(SnowballFire());
        }

    }

    IEnumerator SnowballFire()
    {
        bool Fire = true;
        while (Fire)
        {
            if (stop)
            {
                stop = false;
                break;
            }
            Fire = false;
            GameObject sbinst = Instantiate(snowball);
            snowball.transform.position = transform.position + new Vector3(offSetx, offSety, 0);
            yield return new WaitForSeconds(coolT);
            Fire = true;
        }
    }

    public IEnumerator SnowballFire2()
    {
        bool Fire = true;
        while (Fire)
        {
            Fire = false;
            GameObject sbinst = Instantiate(snowball);
            snowball.transform.position = transform.position + new Vector3(offSetx, offSety, 0);
            yield return new WaitForSeconds(coolT);
            Fire = true;
            stop = true;
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canFire = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            stop = true;
        }
    }
}
