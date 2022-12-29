using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2_on_off_snowball : MonoBehaviour
{

    [Header("Snowball")]
    [SerializeField] GameObject Snowball;
    [SerializeField] GameObject Snowball2;
    [SerializeField] GameObject On_Off_Switch;
    // Start is called before the first frame update
    void Start()
    {
        if(Snowball == null|| Snowball2 == null)
        {
            Debug.LogError("NullExpection");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void Off_State_Rotation()
    {
       // Snowball.transform.RotateAround(On_Off_Switch, Vector3.up, 1);
    }
}
