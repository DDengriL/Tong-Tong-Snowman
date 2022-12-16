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
    [SerializeField] public float[] bestTime;
    private Text rankPlayer = null;
    private ScrollRect scroll_rect = null;



    public int rankPlayerCount = 0;
    private float tmp;
    private void Start()
    {
        LoadPlayer();
    }

    private void LoadPlayer()
    {
        rankPlayerCount = PlayerPrefs.GetInt("rankPlayerCount");
        rankName = new string[rankPlayerCount];
        bestTime = new float[rankPlayerCount];
        for (int i = 0; i < rankPlayerCount; i++)
        {
            rankName[i] = PlayerPrefs.GetString("Player " + i);
            bestTime[i] = PlayerPrefs.GetFloat("Player " + i + " Best Time");
        }
        for(int i = 0; i < rankPlayerCount; i++)
        {
            for(int j = 0; j < rankPlayerCount - 1; j++)
            {
                if (bestTime[j] > bestTime[j + 1])
                {
                    tmp = bestTime[j];
                    bestTime[j] = bestTime[j + 1];
                    bestTime[j + 1] = tmp;
                }
            }
        }
        SyncText();
    }

    private void SyncText()
    {
        for(int i = 0; i < rankPlayerCount; i++)
        {
            rankPlayer.text += $"{i + 1}\t\t\t\t\t\t{rankName[i]}\t\t\t\t\t\t{bestTime[i]}\n";
        }
        scroll_rect.verticalNormalizedPosition = 0.0f;
    }

    




}
