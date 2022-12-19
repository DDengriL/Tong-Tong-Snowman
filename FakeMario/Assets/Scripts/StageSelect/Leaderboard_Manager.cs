using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor.Rendering.LookDev;

public class Leaderboard_Manager : MonoBehaviour
{
    [Header("Leaderboard List")]
    [SerializeField] public string[] rankName;
    [SerializeField] public int[] bestScore;
    [SerializeField] private Text rankPlayer;
    private ScrollRect scroll_rect = null;
    public bool ingame = false;


    public int rankPlayerCount = 1;
    private int tmp;
    private string tmp_String;

    private void Awake()
    {
        
        if(rankPlayer == null)
        {
            Debug.Log(rankPlayer);
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
        if(PlayerPrefs.HasKey("rankPlayerCount") == false)
        {
            rankPlayerCount = 1;
        }
        else
        {
            rankPlayerCount = PlayerPrefs.GetInt("rankPlayerCount");
        }
        

        
        rankName = new string[rankPlayerCount];
        bestScore = new int[rankPlayerCount];
        if (SceneManager.GetActiveScene().name != "Leaderboard")
        {

            for (int i = 0; i < rankPlayerCount - 1; i++)
            {
                if (PlayerPrefs.HasKey("World 1 " + "Player " + i) && PlayerPrefs.HasKey("World 1 " + "Player " + i + " Best Score"))
                {
                    rankName[i] = PlayerPrefs.GetString("World 1 " + "Player " + i);
                    bestScore[i] = PlayerPrefs.GetInt("World 1 " + "Player " + i + " Best Score");
                }
                else
                {
                    break;
                }

            }

            Debug.Log(bestScore.Length);
            for (int i = 0; i < bestScore.Length-1; i++)
            {
                int max = i;
                for (int j = i + 1; j < bestScore.Length; j++)
                {
                    Debug.Log(bestScore[j]);
                    if (bestScore[j] > bestScore[max])      
                    {
                        max = j;
                    }
                }
                Debug.Log(bestScore[i]);
                tmp = bestScore[i];
                tmp_String = rankName[i];
                bestScore[i] = bestScore[max];
                rankName[i] = rankName[max];
                bestScore[max] = tmp;
                rankName[max] = tmp_String;
                //PlayerPrefs.SetInt("World 1 " + "Player " + i + " Best Score", bestScore[i]);
            }
            if (!ingame)
            {
                if (PlayerPrefs.HasKey("World 1 " + "Player " + 0) && PlayerPrefs.HasKey("World 1 " + "Player " + 0 + " Best Score"))
                    SyncText();
            }
        }
    }

    private void SyncText()
    {
        for(int i = 0; i < rankName.Length -1; i++)
        {
            
            rankPlayer.text += $"{i + 1}\t\t\t\t\t\t{rankName[i]}\t\t\t\t\t\t{bestScore[i]}\n";
        }
        if(scroll_rect != null)
        scroll_rect.verticalNormalizedPosition = 0.0f;
    }

    




}
