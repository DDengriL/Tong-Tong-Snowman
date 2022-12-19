using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeGoal_Trap : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private Player player;
    [SerializeField] private SpriteRenderer player_sprite;
    [SerializeField] private Animator player_anim;
    [SerializeField] private Rigidbody2D player_rigid;

    [SerializeField] private GameObject fakeground;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator FakeGoal()
    {
        player_rigid.gravityScale = 0;
        player_rigid.velocity = new Vector2(0, 0);
        player.transform.position = new Vector3(192.45f, player.transform.position.y, player.transform.position.z);
        player_anim.SetBool("islanding", false);
        player_anim.SetBool("ismove", false);
        player_anim.SetBool("isgoal", true);
        player_anim.SetBool("isjump", true);
        while (player.transform.position.y >= -15f)
        {
            if(player.transform.position.y <= 1.76f)
            {
                transform.Translate(0, -1.5f * Time.deltaTime, 0);
                fakeground.transform.Translate(0, -1.5f * Time.deltaTime, 0);
            }
            player.transform.Translate(0, -1.5f * Time.deltaTime, 0);
            yield return new WaitForSeconds(0.001f);
        }
    }
}
