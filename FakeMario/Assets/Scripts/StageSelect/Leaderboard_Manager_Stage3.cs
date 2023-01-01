using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Leaderboard_Manager_Stage3 : MonoBehaviour
{
    [Header("Leaderboard List")]
    [SerializeField] public string[] rankName_stage3;
    [SerializeField] public int[] bestScore_stage3;
    [SerializeField] private Text rankPlayer_stage3;
    private ScrollRect scroll_rect = null;
    public bool ingame = false;


    public int rankPlayerCount_stage3 = 1;
    private int tmp;
    private string tmp_String;

    private void Awake()
    {

        if (rankPlayer_stage3 == null)
        {
            Debug.Log(rankPlayer_stage3);
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
        if (PlayerPrefs.HasKey("rankPlayerCount_stage3") == false)
        {
            rankPlayerCount_stage3 = 1;
        }
        else
        {
            rankPlayerCount_stage3 = PlayerPrefs.GetInt("rankPlayerCount_stage3");
        }



        rankName_stage3 = new string[rankPlayerCount_stage3];
        bestScore_stage3 = new int[rankPlayerCount_stage3];
        if (SceneManager.GetActiveScene().name != "Leaderboard")
        {

            for (int i = 0; i < rankPlayerCount_stage3 - 1; i++)
            {
                if (PlayerPrefs.HasKey("World 3 " + "Player " + i) && PlayerPrefs.HasKey("World 3 " + "Player " + i + " Best Score"))
                {
                    rankName_stage3[i] = PlayerPrefs.GetString("World 3 " + "Player " + i);
                    bestScore_stage3[i] = PlayerPrefs.GetInt("World 3 " + "Player " + i + " Best Score");
                }
                else
                {
                    break;
                }

            }

            Debug.Log(bestScore_stage3.Length);
            for (int i = 0; i < bestScore_stage3.Length - 1; i++)
            {
                int max = i;
                for (int j = i + 1; j < bestScore_stage3.Length; j++)
                {
                    Debug.Log(bestScore_stage3[j]);
                    if (bestScore_stage3[j] > bestScore_stage3[max])
                    {
                        max = j;
                    }
                }
                Debug.Log(bestScore_stage3[i]);
                tmp = bestScore_stage3[i];
                tmp_String = rankName_stage3[i];
                bestScore_stage3[i] = bestScore_stage3[max];
                rankName_stage3[i] = rankName_stage3[max];
                bestScore_stage3[max] = tmp;
                rankName_stage3[max] = tmp_String;
                //PlayerPrefs.SetInt("World 1 " + "Player " + i + " Best Score", bestScore[i]);
            }
            if (!ingame)
            {
                if (PlayerPrefs.HasKey("World 3 " + "Player " + 0) && PlayerPrefs.HasKey("World 3 " + "Player " + 0 + " Best Score"))
                    SyncText();
            }
        }
    }

    private void SyncText()
    {
        for (int i = 0; i < rankName_stage3.Length - 1; i++)
        {

            rankPlayer_stage3.text += $"{i + 1}\t\t\t\t\t\t{rankName_stage3[i]}\t\t\t\t\t\t{bestScore_stage3[i]}\n";
        }
        if (scroll_rect != null)
            scroll_rect.verticalNormalizedPosition = 0.0f;
    }






}
