using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingStatus : MonoBehaviour
{
    [Header("로딩 시간")]

    [SerializeField] private float Seconds;


    [Header("플레이어 체력 데이터 유지")]

    [SerializeField] private GameObject Health_Status;


    [Header("체력 텍스트 출력")]

    [SerializeField] private Text HealthText;

    PlayerHealth health;

    // Start is called before the first frame update
    void Start()
    {
        health = GameObject.Find("PlayerHealth").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Seconds >= 0)
        {
            Seconds -= Time.deltaTime;
        }
        else
        {
            SceneManager.LoadScene("Level1");
            DontDestroyOnLoad(Health_Status);
        }
        HealthText.text = health.Health.ToString();
    }


}