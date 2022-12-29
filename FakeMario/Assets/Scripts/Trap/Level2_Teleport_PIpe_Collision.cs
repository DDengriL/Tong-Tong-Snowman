using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Level2_Teleport_PIpe_Collision : MonoBehaviour
{
    public bool isActive = false;

    [SerializeField] BoxCollider2D tp_pipe1;
    [SerializeField] BoxCollider2D tp_pipe2;
    BoxCollider2D collider;
    Player player;
    Transform player_transform;
    Rigidbody2D player_rigid;
    GameObject player_obj;
  
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        player_transform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        player_rigid = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
        player_obj = GameObject.FindWithTag("Player");
        collider = GetComponent<BoxCollider2D>();
        if (player == null)
        {
            Debug.LogError("Player Script is NULL");
        }
        if (player_transform == null)
        {
            Debug.LogError("Player Transform Component is NULL");
        }
    }

    // Update is called once per frame
    void Update()
    {
       if(isActive)
        {
            collider.enabled = false;
            tp_pipe1.enabled = false;
            tp_pipe2.enabled = false;
            player_rigid.velocity = Vector2.zero;
            player_rigid.gravityScale = 0;
            player_obj.layer = 9;
        }
    }

    public IEnumerator Pipe_Teleport()
    {
        
        player.ispipein = true;
        player_transform.position = new Vector2(105.7106f, -0.70007f);
        yield return new WaitForSeconds(0.1f);
        while(player_transform.position.y >= -2.60026f)
        {
            player_transform.Translate(0, -1f * Time.deltaTime, 0);
            yield return new WaitForSeconds(0.001f);
        }
        yield return new WaitForSeconds(1.0f);
        player_transform.position = new Vector2(114.1114f, -2.60026f);
        yield return new WaitForSeconds(0.1f);
        while(player_transform.position.y <= -0.7007f)
        {
            player_transform.Translate(0, 1f * Time.deltaTime, 0);
            yield return new WaitForSeconds(0.001f);
        }
        yield return new WaitForSeconds(0.1f);
        isActive = false;
        tp_pipe2.enabled = true;
        player.ispipein = false;
        player_obj.layer = 8;
        player_rigid.gravityScale = 9.8f;
    }
}
