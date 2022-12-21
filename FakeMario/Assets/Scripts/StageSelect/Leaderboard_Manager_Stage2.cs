using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Leaderboard_Manager_Stage2 : MonoBehaviour
{
    [Header("Leaderboard List")]
    [SerializeField] public string[] rankName_stage2;
    [SerializeField] public int[] bestScore_stage2;
    [SerializeField] private Text rankPlayer_stage2;
    private ScrollRect scroll_rect = null;
    public bool ingame = false;


    public int rankPlayerCount_stage2 = 1;
    private int tmp;
    private string tmp_String;

    private void Awake()
    {

        if (rankPlayer_stage2 == null)
        {
            Debug.Log(rankPlayer_stage2);
        }
    }
    private void Start()
    {

        LoadPlayer();


    }

    private void Update()
    {
        //rankName = new string[rankPlayerCount];
        //bestScore = new int[rankPlayerCount];
        //Debug.Log(rankPlayer);
    }

    // 플레이어 데이터 불러오기
    private void LoadPlayer()
    {
        if (PlayerPrefs.HasKey("rankPlayerCount_stage2") == false)
        {
            rankPlayerCount_stage2 = 1;
        }
        else
        {
            rankPlayerCount_stage2 = PlayerPrefs.GetInt("rankPlayerCount_stage2");
        }



        rankName_stage2 = new string[rankPlayerCount_stage2];
        bestScore_stage2 = new int[rankPlayerCount_stage2];
        if (SceneManager.GetActiveScene().name != "Leaderboard")
        {

            for (int i = 0; i < rankPlayerCount_stage2 - 1; i++)
            {
                if (PlayerPrefs.HasKey("World 2 " + "Player " + i) && PlayerPrefs.HasKey("World 2 " + "Player " + i + " Best Score"))
                {
                    rankName_stage2[i] = PlayerPrefs.GetString("World 2 " + "Player " + i);
                    bestScore_stage2[i] = PlayerPrefs.GetInt("World 2 " + "Player " + i + " Best Score");
                }
                else
                {
                    break;
                }

            }

            Debug.Log(bestScore_stage2.Length);
            for (int i = 0; i < bestScore_stage2.Length - 1; i++)
            {
                int max = i;
                for (int j = i + 1; j < bestScore_stage2.Length; j++)
                {
                    Debug.Log(bestScore_stage2[j]);
                    if (bestScore_stage2[j] > bestScore_stage2[max])
                    {
                        max = j;
                    }
                }
                Debug.Log(bestScore_stage2[i]);
                tmp = bestScore_stage2[i];
                tmp_String = rankName_stage2[i];
                bestScore_stage2[i] = bestScore_stage2[max];
                rankName_stage2[i] = rankName_stage2[max];
                bestScore_stage2[max] = tmp;
                rankName_stage2[max] = tmp_String;
                //PlayerPrefs.SetInt("World 1 " + "Player " + i + " Best Score", bestScore[i]);
            }
            if (!ingame)
            {
                if (PlayerPrefs.HasKey("World 2 " + "Player " + 0) && PlayerPrefs.HasKey("World 2 " + "Player " + 0 + " Best Score"))
                    SyncText();
            }
        }
    }

    private void SyncText()
    {
        for (int i = 0; i < rankName_stage2.Length - 1; i++)
        {

            rankPlayer_stage2.text += $"{i + 1}\t\t\t\t\t\t{rankName_stage2[i]}\t\t\t\t\t\t{bestScore_stage2[i]}\n";
        }
        if (scroll_rect != null)
            scroll_rect.verticalNormalizedPosition = 0.0f;
    }






}
