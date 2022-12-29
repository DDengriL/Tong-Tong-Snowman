using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.UI;

public class Level2_Move_Brick_BackTrap : MonoBehaviour
{
    BoxCollider2D trap_collision;
    Level2_MoveBrick_Trap trap;
    BoxCollider2D trap_active_collision;
    [SerializeField] BoxCollider2D trap_active_collision2;
    [SerializeField] GameObject fake_Brick;
    public bool isblock = false;
    public bool iscollision = false;

    // Start is called before the first frame update
    void Start()
    {
        trap_collision = GameObject.Find("move_btick_Back_trap_collision").GetComponent<BoxCollider2D>();
        
        
        
        trap = GameObject.Find("move_brick").GetComponent<Level2_MoveBrick_Trap>();
        if(trap_collision == null || trap == null)
        {
            Debug.LogError("NullExpection");
        }
        fake_Brick.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(isblock)
        {
            fake_Brick.SetActive(true);
        }
        if(iscollision)
        {
            trap_active_collision2.enabled = false;
        }
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
