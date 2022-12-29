using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Level2_MoveBrick_Trap : MonoBehaviour
{

    public bool isActive = false;

    private bool smart = false;

    private float t;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isActive)
        {
            transform.position = new Vector3(93.56093f, -4.762938f, 0.121089f);

        }
        else
        {
            if(!smart)
            {
                smart = true;
                StartCoroutine(isactivecondition());
            }
            //transform.position = new Vector3(90.56063f, -4.762938f, 0);
        }



        /*if (smart)
        {
            if (t >= 1)
            {
                smart = false;
            }

            t += Time.deltaTime;
            Vector3.Lerp(new Vector3(93.56093f, -4.762938f, 0), new Vector3(90.56063f, -4.762938f, 0),t);
        }*/
    }

    IEnumerator isactivecondition()
    {
        while(transform.position.x >= 90.56063f)
        {
            transform.Translate(-35f * Time.deltaTime, 0, 0);
            yield return new WaitForSeconds(0.001f);
        }
    }
}
