using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using Unity.VisualScripting;

public class Leaderboard_Register : MonoBehaviour
{
    [Header("Input Field")]
    [SerializeField] private InputField input;

    [Header("Player Status")]
    Score score;
    [Header("Register")]
    [SerializeField] private GameObject register_btn;
    [SerializeField] private GameObject Loading_Process;
    [SerializeField] private Text loading_text;

    [Header("Score Manager")]
    [SerializeField] private GameObject scoreboard_obj;


    [Header("Intro Black")]
    [SerializeField] private Image blackimg;

    [Header("Leaderboard Manager")]
    [SerializeField] private Leaderboard_Manager leader_manager;
    [SerializeField] private GameObject Leaderboad_obj;
    private void Start()
    {
        leader_manager = GameObject.Find("Leaderboard_Manager").GetComponent<Leaderboard_Manager>();
        Leaderboad_obj = GameObject.Find("Leaderboard_Manager");
        scoreboard_obj = GameObject.Find("ScoreManager");
        score = GameObject.Find("ScoreManager").GetComponent<Score>();
        StartCoroutine(intro());
    }
    public void CancelBtn()
    {
        SceneManager.LoadScene("StageSelect");
    }

    public void Register_Btn()
    {
        StartCoroutine(Register());
    }
    IEnumerator Register()
    {
        if (input.text != "")
        {
            
            register_btn.SetActive(false);
            Loading_Process.SetActive(true);
            loading_text.text = "등록 중...";
            if (PlayerPrefs.HasKey("rankPlayerCount") == false)
            {
                leader_manager.rankPlayerCount = 1;
            }
            else
            {
                leader_manager.rankPlayerCount = PlayerPrefs.GetInt("rankPlayerCount");
            }


            
            
            for (int i = 0; i < leader_manager.rankPlayerCount - 1; i++)
            {
                if (PlayerPrefs.HasKey("World 1 " + "Player " + i) && PlayerPrefs.HasKey("World 1 " + "Player " + i + " Best Score"))
                {
                    leader_manager.rankName[i] = PlayerPrefs.GetString("World 1 " + "Player " + i);
                    leader_manager.bestScore[i] = PlayerPrefs.GetInt("World 1 " + "Player " + i + " Best Score");
                }
                

            }
            leader_manager.rankName[leader_manager.rankPlayerCount - 1] = "";
            leader_manager.bestScore[leader_manager.rankPlayerCount - 1] = 0;
            if(!PlayerPrefs.HasKey("World 1 " + "Player " + 0) && !PlayerPrefs.HasKey("World 1 " + "Player " + 0 + " Best Score"))
            {
                leader_manager.rankName[0] = "";
                leader_manager.bestScore[0] = 0;
            }
            Debug.Log(leader_manager.rankPlayerCount);
            Debug.Log(leader_manager.rankName.Length);
            for (int i = 0; i < leader_manager.rankName.Length; i++)
            {
                Debug.Log(leader_manager.rankName.Length);
                if (leader_manager.rankName[i] == "")
                {
                    Debug.Log("등록함");
                    leader_manager.rankName[i] = input.text;
                    PlayerPrefs.SetString("World 1 " + "Player " + i, leader_manager.rankName[i]);
                    PlayerPrefs.SetInt("World 1 " + "Player " + i + " Best Score", score.score);
                }
            }
            leader_manager.rankPlayerCount++;
            PlayerPrefs.SetInt("rankPlayerCount", leader_manager.rankPlayerCount);
            Destroy(Leaderboad_obj);
            Destroy(scoreboard_obj);
            yield return new WaitForSeconds(1.5f);
            loading_text.text = "등록 완료!";
            yield return new WaitForSeconds(1.5f);
            SceneManager.LoadScene("StageSelect");
        }
    }
    IEnumerator intro()
    {
        Color color = blackimg.color;
        for(float i = 1.0f; i >= 0.0f; i -= 0.01f * Time.deltaTime* 300)
        {
            color.a = i;
            blackimg.color = color;
            yield return new WaitForSeconds(0.001f);
        }
    }

}
