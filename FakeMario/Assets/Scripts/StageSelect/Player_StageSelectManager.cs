using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_StageSelectManager : MonoBehaviour
{

    [Header("Level 1 Door")]
    [SerializeField] private SpriteRenderer Level_1_Door;

    private bool Level1_Enable = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StageSelecting();
    }

    private void StageSelecting()
    {
        Level1();
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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Level1")
        {
            Level1_Enable = true;
            Level_1_Door.color = Color.green;
            Debug.LogError("player reached level 1 door");
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
    }
}
