using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using Unity.VisualScripting;

public class Leaderboard_Register_Stage2 : MonoBehaviour
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
    [SerializeField] private Leaderboard_Manager_Stage2 leader_manager;
    [SerializeField] private GameObject Leaderboad_obj;
    private void Start()
    {
        leader_manager = GameObject.Find("Leaderboard_Manager_stage2").GetComponent<Leaderboard_Manager_Stage2>();
        Leaderboad_obj = GameObject.Find("Leaderboard_Manager_stage2");
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
            if (PlayerPrefs.HasKey("rankPlayerCount_stage2") == false)
            {
                leader_manager.rankPlayerCount_stage2 = 1;
            }
            else
            {
                leader_manager.rankPlayerCount_stage2 = PlayerPrefs.GetInt("rankPlayerCount_stage2");
            }




            for (int i = 0; i < leader_manager.rankPlayerCount_stage2 - 1; i++)
            {
                if (PlayerPrefs.HasKey("World 2 " + "Player " + i) && PlayerPrefs.HasKey("World 2 " + "Player " + i + " Best Score"))
                {
                    leader_manager.rankName_stage2[i] = PlayerPrefs.GetString("World 2 " + "Player " + i);
                    leader_manager.bestScore_stage2[i] = PlayerPrefs.GetInt("World 2 " + "Player " + i + " Best Score");
                }


            }
            leader_manager.rankName_stage2[leader_manager.rankPlayerCount_stage2 - 1] = "";
            leader_manager.bestScore_stage2[leader_manager.rankPlayerCount_stage2 - 1] = 0;
            if (!PlayerPrefs.HasKey("World 2 " + "Player " + 0) && !PlayerPrefs.HasKey("World 2 " + "Player " + 0 + " Best Score"))
            {
                leader_manager.rankName_stage2[0] = "";
                leader_manager.bestScore_stage2[0] = 0;
            }
            Debug.Log(leader_manager.rankPlayerCount_stage2);
            Debug.Log(leader_manager.rankName_stage2.Length);
            for (int i = 0; i < leader_manager.rankName_stage2.Length; i++)
            {
                Debug.Log(leader_manager.rankName_stage2.Length);
                if (leader_manager.rankName_stage2[i] == "")
                {
                    Debug.Log("등록함");
                    leader_manager.rankName_stage2[i] = input.text;
                    PlayerPrefs.SetString("World 2 " + "Player " + i, leader_manager.rankName_stage2[i]);
                    PlayerPrefs.SetInt("World 2 " + "Player " + i + " Best Score", score.score);
                }
            }
            leader_manager.rankPlayerCount_stage2++;
            PlayerPrefs.SetInt("rankPlayerCount", leader_manager.rankPlayerCount_stage2);
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
        for (float i = 1.0f; i >= 0.0f; i -= 0.01f * Time.deltaTime * 300)
        {
            color.a = i;
            blackimg.color = color;
            yield return new WaitForSeconds(0.001f);
        }
    }

}
