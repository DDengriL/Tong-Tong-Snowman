using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using Unity.VisualScripting;

public class Leaderboard_Register_Stage3 : MonoBehaviour
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
    [SerializeField] private Leaderboard_Manager_Stage3 leader_manager;
    [SerializeField] private GameObject Leaderboad_obj;
    private void Start()
    {
        leader_manager = GameObject.Find("Leaderboard_Manager_stage3").GetComponent<Leaderboard_Manager_Stage3>();
        if(leader_manager == null)
        {
            Debug.Log("Null");
        }
        Leaderboad_obj = GameObject.Find("Leaderboard_Manager_stage3");
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
            if (PlayerPrefs.HasKey("rankPlayerCount_stage3") == false)
            {
                leader_manager.rankPlayerCount_stage3 = 1;
            }
            else
            {
                leader_manager.rankPlayerCount_stage3 = PlayerPrefs.GetInt("rankPlayerCount_stage3");
            }




            for (int i = 0; i < leader_manager.rankPlayerCount_stage3 - 1; i++)
            {
                if (PlayerPrefs.HasKey("World 3 " + "Player " + i) && PlayerPrefs.HasKey("World 3 " + "Player " + i + " Best Score"))
                {
                    leader_manager.rankName_stage3[i] = PlayerPrefs.GetString("World 3 " + "Player " + i);
                    leader_manager.bestScore_stage3[i] = PlayerPrefs.GetInt("World 3 " + "Player " + i + " Best Score");
                }


            }
            leader_manager.rankName_stage3[leader_manager.rankPlayerCount_stage3 - 1] = "";
            leader_manager.bestScore_stage3[leader_manager.rankPlayerCount_stage3 - 1] = 0;
            if (!PlayerPrefs.HasKey("World 3 " + "Player " + 0) && !PlayerPrefs.HasKey("World 3 " + "Player " + 0 + " Best Score"))
            {
                leader_manager.rankName_stage3[0] = "";
                leader_manager.bestScore_stage3[0] = 0;
            }
            Debug.Log(leader_manager.rankPlayerCount_stage3);
            Debug.Log(leader_manager.rankName_stage3.Length);
            for (int i = 0; i < leader_manager.rankName_stage3.Length; i++)
            {
                Debug.Log(leader_manager.rankName_stage3.Length);
                if (leader_manager.rankName_stage3[i] == "")
                {
                    Debug.Log("등록함");
                    leader_manager.rankName_stage3[i] = input.text;
                    PlayerPrefs.SetString("World 3 " + "Player " + i, leader_manager.rankName_stage3[i]);
                    PlayerPrefs.SetInt("World 3 " + "Player " + i + " Best Score", score.score);
                }
            }
            leader_manager.rankPlayerCount_stage3++;
            PlayerPrefs.SetInt("rankPlayerCount_stage3", leader_manager.rankPlayerCount_stage3);
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
