using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{

    [Header("Timer Text")]
    [SerializeField] private Text timer_text;

    private int min = 0;
    private float sec = 0;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TimerStart();
        timer_text.text = string.Format("{0:D2} : {1:D2}", min, (int)sec);
    }


    private void TimerStart()
    {
        if((int)sec == 60)
        {
            min++;
            sec = 0;
        }
        else
        {
            sec += Time.deltaTime;
        }
       
    }
}
