using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score = 0;
    [SerializeField] public Text score_text;

    Timer timer;
    Stage1_Goal goal;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Leaderboard")
        {
            score_text = null;
        }
        timer = GetComponent<Timer>();
        if(SceneManager.GetActiveScene().name == "Level1")
        goal = GameObject.Find("Goal").GetComponent<Stage1_Goal>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Leaderboard")
        {
            score_text = null;
        }
        if(SceneManager.GetActiveScene().name != "StageSelect" && SceneManager.GetActiveScene().name != "Leaderboard" && SceneManager.GetActiveScene().name != "Leaderboard_2" && SceneManager.GetActiveScene().name != "Leaderboard_3" && SceneManager.GetActiveScene().name != "level1_clear" && SceneManager.GetActiveScene().name != "level2_clear" && SceneManager.GetActiveScene().name != "level3_clear")
        {
            score_text.text = string.Format("{0:D8}", score);
        }
        
    }
}
