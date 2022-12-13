using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingStatus : MonoBehaviour
{
    [Header("�ε� �ð�")]

    [SerializeField] private float Seconds;


    [Header("�÷��̾� ü�� ������ ����")]

    [SerializeField] private GameObject Health_Status;


    [Header("ü�� �ؽ�Ʈ ���")]

    [SerializeField] private Text HealthText;


    [Header("�ε� �� �ҷ��� �� ���")]
    [SerializeField] private string[] LoadScene_ = new string[0];

    private int sceneNum = 0;

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
            SceneManager.LoadScene(LoadScene_[sceneNum]);
            DontDestroyOnLoad(Health_Status);
        }
        HealthText.text = health.Health.ToString();
    }


}