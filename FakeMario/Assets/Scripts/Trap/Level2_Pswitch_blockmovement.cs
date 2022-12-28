using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Level2_Pswitch_blockmovement : MonoBehaviour
{
    Pswitch p_switch;
    // Start is called before the first frame update
    void Start()
    {
        p_switch = GameObject.Find("Pswitch").GetComponent<Pswitch>();
        if(p_switch == null)
        {
            Debug.Log("p_switch is null");
            Application.Quit(); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!p_switch.isP)
        {
            transform.position = new Vector2(57.75629f, 2.203979f);
        }
        else
        {
            transform.position = new Vector2(54.856f, 2.203979f);
        }
    }
}
