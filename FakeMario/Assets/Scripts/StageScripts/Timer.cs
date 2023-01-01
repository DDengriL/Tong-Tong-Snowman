using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{

    [Header("Timer Text")]
    [SerializeField] private Text timer_text;

    Stage1_Goal st1_goal;
    Stage3_Goal st3_goal;
    
    public int min = 6;
    public float sec = 0;
   
    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "Level1")
        st1_goal = GameObject.Find("Goal").GetComponent<Stage1_Goal>();

        if (SceneManager.GetActiveScene().name == "Level3")
            st3_goal = GameObject.Find("Goal").GetComponent<Stage3_Goal>();
        if (st1_goal == null)
        {
            Debug.Log("im null");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "Level1")
            TimerStart1();
        if (SceneManager.GetActiveScene().name == "Level2")
            TimerStart2();
        if (SceneManager.GetActiveScene().name == "Level3")
            TimerStart3();
        timer_text.text = string.Format("{0:D2} : {1:D2}", min, (int)sec);
    }


    private void TimerStart1()
    {
        if(min == 0 && sec == 0 && !st1_goal.isGoal)
        {
            SceneManager.LoadScene("Level1");
        }
        if (!st1_goal.isGoal)
        {
            
            if (sec <= 0)
            {
                min--;
                sec = 60;
            }
            else
            {
                sec -= Time.deltaTime;
            }
        }
    }

        private void TimerStart2()
        {
            //if (!st1_goal.isGoal)
            //{
                if (sec <= 0)
                {
                    min--;
                    sec = 60;
                }
                else
                {
                    sec -= Time.deltaTime;
                }
            //}
        }
    private void TimerStart3()
    {
        if (min == 0 && sec == 0 && !st3_goal.isGoal)
        {
            SceneManager.LoadScene("Level3");
        }
        if (!st3_goal.isGoal)
        {

            if (sec <= 0)
            {
                min--;
                sec = 60;
            }
            else
            {
                sec -= Time.deltaTime;
            }
        }
    }
}
