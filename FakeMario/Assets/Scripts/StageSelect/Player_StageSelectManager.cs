using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_StageSelectManager : MonoBehaviour
{

    [Header("Level 1 Door")]
    [SerializeField] private SpriteRenderer Level_1_Door;

    private bool Level1_Enable = false;


    [Header("Level 2 Door")]
    [SerializeField] private SpriteRenderer Level_2_Door;

    private bool Level2_Enable = false;

    [Header("Level Unlock")]
    public bool Level2Unlock;

    // Start is called before the first frame update
    void Start()
    {
        DataLoad();
    }

    // Update is called once per frame
    void Update()
    {
        StageSelecting();
    }

    private void StageSelecting()
    {
        Level1();
        Level2();
    }

    private void DataLoad()
    {
        Level2Unlock = System.Convert.ToBoolean(PlayerPrefs.GetInt("Level2Data"));
    }

    private void DataSave()
    {
        PlayerPrefs.SetInt("Level2Data", System.Convert.ToInt16(Level2Unlock));
    }

    private void Level1()
    {
        if (Level1_Enable)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Debug.LogError("Player entered Level 1");
            }
        }
    }

    private void Level2()
    {
        if(Level2_Enable)
        {
            if(Input.GetKeyDown(KeyCode.UpArrow))
            {
                Debug.LogError("Player entered level 2");
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Level1")
        {
            Level1_Enable = true;
            Level_1_Door.color = Color.green;
            Debug.LogError("player reached level 1 door");
        }

        if(Level2Unlock)
        {
            if(collision.gameObject.tag == "Level2")
            {
                Level2_Enable = true;
                Level_2_Door.color = Color.green;
                Debug.LogError("player reached level 2 door");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Level1")
        {
            Level1_Enable = false;
            Level_1_Door.color = Color.white;
            Debug.LogError("player exited level 1 door");
        }

        if(Level2Unlock)
        {
            if(collision.gameObject.tag == "Level2")
            {
                Level2_Enable = false;
                Level_2_Door.color = Color.white;
                Debug.LogError("player exited level 2 door");
            }
        }
    }
}
