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
    private Text rankPlayer = null;
    private ScrollRect scroll_rect = null;
    public bool ingame = false;


    public int rankPlayerCount = 0;
    private int tmp;
    private void Start()
    {
        
        LoadPlayer();
        
    }

    private void LoadPlayer()
    {
        rankPlayerCount = PlayerPrefs.GetInt("rankPlayerCount");
        rankName = new string[rankPlayerCount];
        bestScore = new int[rankPlayerCount];
        for (int i = 0; i < rankPlayerCount; i++)
        {
            rankName[i] = PlayerPrefs.GetString("World 1 " + "Player " + i);
            bestScore[i] = PlayerPrefs.GetInt("World 1 " + "Player " + i + " Best Score");
        }
        for(int i = 0; i < rankPlayerCount; i++)
        {
            for(int j = 0; j < rankPlayerCount - 1; j++)
            {
                if (bestScore[j] > bestScore[j + 1])
                {
                    tmp = bestScore[j];
                    bestScore[j] = bestScore[j + 1];
                    bestScore[j + 1] = tmp;
                }
            }
        }
        if(!ingame)
        {
            SyncText();
        }
    }

    private void SyncText()
    {
        for(int i = 0; i < rankPlayerCount; i++)
        {
            rankPlayer.text += $"{i + 1}\t\t\t\t\t\t{rankName[i]}\t\t\t\t\t\t{bestScore[i]}\n";
        }
        if(scroll_rect != null)
        scroll_rect.verticalNormalizedPosition = 0.0f;
    }

    




}
