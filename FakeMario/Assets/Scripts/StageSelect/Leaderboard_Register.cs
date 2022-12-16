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

    [Header("Register")]

    [Header("Leaderboard Manager")]
    [SerializeField] private Leaderboard_Manager leader_manager;
    public void CancelBtn()
    {
        SceneManager.LoadScene("StageSelect");
    }

    public void Register()
    {
        if(input.text != null)
        {
            leader_manager.rankPlayerCount++;
            leader_manager.rankName[leader_manager.rankPlayerCount] = input.text;
        }
    }

}
