using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Leaderboard_Register : MonoBehaviour
{
    [Header("Input Field")]
    [SerializeField] private InputField input;

    [Header("Player Status")]
    Score score;
    [Header("Register")]

    [Header("Intro Black")]
    [SerializeField] private Image blackimg;

    [Header("Leaderboard Manager")]
    [SerializeField] private Leaderboard_Manager leader_manager;
    private void Start()
    {
        leader_manager = GameObject.Find("Leaderboard_Manager").GetComponent<Leaderboard_Manager>();
        score = GameObject.Find("GameSystemManager").GetComponent<Score>();
        StartCoroutine(intro());
    }
    public void CancelBtn()
    {
        SceneManager.LoadScene("StageSelect");
    }

    public void Register()
    {
        if(input.text != null)
        {
            leader_manager.rankPlayerCount = PlayerPrefs.GetInt("rankPlayerCount");
            leader_manager.rankPlayerCount++;
            PlayerPrefs.SetInt("rankPlayerCount", leader_manager.rankPlayerCount);
            for(int i = 0; i <= leader_manager.rankPlayerCount; i++)
            {
                if (leader_manager.rankName[i] == null)
                {
                    leader_manager.rankName[i] = input.text;
                    PlayerPrefs.SetString("World 1 " + "Player " + i, leader_manager.rankName[i]);
                    PlayerPrefs.SetInt("World 1 " + "Player " + i + " Best Score", score.score);
                }
            }
        }
    }

    IEnumerator intro()
    {
        Color color = blackimg.color;
        for(float i = 1.0f; i >= 0.0f; i -= 0.01f)
        {
            color.a = i;
            blackimg.color = color;
            yield return new WaitForSeconds(0.001f);
        }
    }

}
