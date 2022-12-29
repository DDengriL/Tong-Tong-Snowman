using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class On_Off_Switch : MonoBehaviour
{

    [Header("On/Off Sprite")]
    [SerializeField] Sprite On_sprite;
    [SerializeField] Sprite Off_sprite;


    SpriteRenderer sprite_render;
    Transform player_tf;
    [Header("Switch State")]
    public bool switch_state = false;



    private float coolTime = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        sprite_render = GetComponent < SpriteRenderer>();
        player_tf = GameObject.FindWithTag("Player").GetComponent<Transform>();
        if(player_tf == null)
        {
            Debug.LogError("Player is Null");
        }
    }

    // Update is called once per frame
    void Update()
    {

        if(coolTime > 0)
        {
            coolTime -= Time.deltaTime;
        }
        else
        {
            coolTime = 0;
        }
        if(switch_state )
        {
            sprite_render.sprite = On_sprite;   
        }
        else
        {
            sprite_render.sprite = Off_sprite;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && player_tf.position.y < transform.position.y && coolTime == 0)
        {
            if(switch_state)
            {
                switch_state = false;
                coolTime = 1.0f;
            }
            else
            {
                switch_state = true;
                coolTime = 1.0f;
            }
        }
    }
}
