using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2_Trap_Pipe2 : MonoBehaviour
{
    [Header("Player Component")]
    [SerializeField] Rigidbody2D player_rigid;
    [SerializeField] Player player_sc;
    [SerializeField] Transform player_tf;
    [SerializeField] Animator player_anim;
    [SerializeField] SpriteRenderer player_sprite;

    [Header("Trap Pipe")]
    [SerializeField] BoxCollider2D trap_pipe_col;
     
    public IEnumerator Trap_Active()
    {
        trap_pipe_col.enabled = false;
        player_sc.isdead = true;
        player_rigid.velocity = new Vector2(0, 0);
        player_rigid.gravityScale = 0;
        player_anim.SetBool("ismove", false);
        player_anim.SetBool("islanding", false);
        player_anim.SetBool("isjump", false);
        player_tf.position = new Vector3(player_tf.position.x, -2.946f, 0);
       
        while(player_tf.position.x <= 11.62f)
        {
            player_tf.transform.Translate(0.5f * Time.deltaTime, 0, 0);
            yield return new WaitForSeconds(0.001f);
        }
        yield return new WaitForSeconds(1.0f);
        player_sprite.flipX = true;
        player_anim.SetBool("islanding", true);
        while(player_tf.position.x >= -35.06f)
        {
            player_tf.transform.Translate(-12 * Time.deltaTime, 0, 0);
            yield return new WaitForSeconds(0.001f);
        }
        

    }
}
