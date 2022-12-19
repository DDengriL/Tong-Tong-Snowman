using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stage1_Goal : MonoBehaviour
{

    [Header("Player")]
    [SerializeField] private Player player;
    [SerializeField] private SpriteRenderer player_sprite;
    [SerializeField] private Animator player_anim;
    [SerializeField] private Rigidbody2D player_rigid;

    [Header("Player Stats")]
    [SerializeField] private GameObject GameSystemManager_obj;

    [Header("Circle Transition")]
    [SerializeField] private RectTransform circle_transition;
    [SerializeField] private GameObject blacksrn;

    Timer timer;
    Score score;

    public bool isGoal = false;

    private void Start()
    {
        timer = GameObject.Find("GameSystemManager").GetComponent<Timer>();
        score = GameObject.Find("ScoreManager").GetComponent<Score>();
        blacksrn.SetActive(false);
    }
    
    public IEnumerator Goal()
    {
        player_rigid.gravityScale = 0;
        player_rigid.velocity = new Vector2(0,0);
        player.transform.position = new Vector3(205.58f, player.transform.position.y,player.transform.position.z);
        player_anim.SetBool("islanding", false);
        player_anim.SetBool("ismove", false);
        player_anim.SetBool("isgoal", true);
        player_anim.SetBool("isjump", true);
        while(player.transform.position.y >= 0.823f)
        {
            player.transform.Translate(0, -1.5f * Time.deltaTime, 0);
            yield return new WaitForSeconds(0.001f);
        }
        player_anim.SetBool("islanding", false);
        
        player_anim.SetBool("isjump", false);
        player_anim.SetBool("ismove", false);
        yield return new WaitForSeconds(1.0f);
        
        while(player.transform.position.x <= 213.44f)
        {
            player_anim.SetBool("ismove", true);
            player.transform.Translate(1.5f * Time.deltaTime, 0, 0);
            yield return new WaitForSeconds(0.001f);
        }
        player_anim.SetBool("ismove", false);
        yield return new WaitForSeconds(2.0f);
        while(timer.min != 0 || timer.sec >= 0)
        {
            if(timer.min == 0 && timer.sec <= 0)
            {
                break;
            }
            if(timer.sec <= 0)
            {
                timer.min--;
                timer.sec = 60;
            }
            else
            {
                score.score += 10;
                timer.sec--;

                yield return new WaitForSeconds(0.005f);
            }
        }
        yield return new WaitForSeconds(1.0f);
        StartCoroutine(Player_Opacity());
        for (float i = 2.5f; i >= 0.0925f; i -= 0.01f)
        {
            circle_transition.localScale = new Vector3(i, i, i);
            yield return new WaitForSeconds(0.001f);
        }
        blacksrn.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        Debug.Log("Stage Clear");
        DontDestroyOnLoad(GameSystemManager_obj);
        SceneManager.LoadScene("Leaderboard");
    }

    

    IEnumerator Player_Opacity()
    {
        Color color = player_sprite.color;
        for (float i = 1.0f; i >= 0.0f; i -= 0.003f)
        {
            color.a = i;
            player_sprite.color = color;
            yield return new WaitForSeconds(0.001f);
        }
    }
}
