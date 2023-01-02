using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    Stage1_Goal st1_goal;
    Stage2_Goal st2_goal;
    Stage3_Goal st3_goal;

    FakeGoal_Trap fakegoaltrap;
    Level2_Trap_Pipe2 lvl2_pipe_trap;
    Level2_MoveBrick_Trap lvl2_move_Brick;
    Level2_Move_Brick_BackTrap lvl2_move_back_trap;
    Level2_Teleport_PIpe_Collision lvl2_tp_pipe;


    Starcoin_UI starcoin_ui;

    Score score;

    GroundChk gchk;

    [Header("Jump Key")]
    [SerializeField]
    private KeyCode jumpKey = KeyCode.Space;

    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator ani;
    AudioSource audio;
    GameObject Leaderboard_manager;

    Vector2 tmp;

    private float Dir;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpPower;

    [SerializeField] float Wdis;

    // ³Í ³ª°¡¶ó
    private bool canjump = false;
    private bool canHold = false;

    private float temp;

    
    private float Y;
    private bool canDe;

    public bool isArrive = false;
    public bool isPause = false;
    public bool enterlevel1 = false;
    
    public bool isdead = false;
    public bool ispipein = false;

    Color color;

    void Start()
    {
        
        gchk = GetComponentInChildren<GroundChk>();
        audio = GetComponent<AudioSource>();
        if(SceneManager.GetActiveScene().name != "StageSelect")
        {
            starcoin_ui = GameObject.Find("GameSystemManager").GetComponent<Starcoin_UI>();
        }
        if(SceneManager.GetActiveScene().name == "Level1")
        {
            st1_goal = GameObject.Find("Goal").GetComponent<Stage1_Goal>();
            score = GameObject.Find("ScoreManager").GetComponent<Score>();
            Leaderboard_manager = GameObject.Find("Leaderboard_Manager");
        }
        if(SceneManager.GetActiveScene().name == "Level1")
        {
            fakegoaltrap = GameObject.Find("Fake_Goal").GetComponent<FakeGoal_Trap>();
        }
        if(SceneManager.GetActiveScene().name == "Level2")
        {
            lvl2_pipe_trap = GameObject.Find("Trap_Pipe").GetComponent<Level2_Trap_Pipe2>();
            lvl2_move_Brick = GameObject.Find("move_brick").GetComponent<Level2_MoveBrick_Trap>();
            lvl2_move_back_trap = GameObject.Find("move_Brick_back_trap").GetComponent<Level2_Move_Brick_BackTrap>();
            lvl2_tp_pipe = GameObject.Find("Teleport_Pipe_Collision").GetComponent<Level2_Teleport_PIpe_Collision>();
            score = GameObject.Find("ScoreManager").GetComponent<Score>();
            st2_goal = GameObject.Find("Goal").GetComponent<Stage2_Goal>();
        }
        if (SceneManager.GetActiveScene().name == "Level3")
        {
            st3_goal = GameObject.Find("Goal").GetComponent<Stage3_Goal>();
            score = GameObject.Find("ScoreManager").GetComponent<Score>();
            Leaderboard_manager = GameObject.Find("Leaderboard_Manager_stage3");
        }
        tmp = transform.position;
        ani = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        temp = jumpPower;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name == "Level1" && !st1_goal.isGoal)
        {
            Destroy(Leaderboard_manager);
            SceneManager.LoadScene("StageSelect");
        }
        if(!isPause && !isArrive && !enterlevel1 && !isdead && !ispipein)
        {
            if (canjump == false && rb.velocity.y < -1)
            {
                Debug.Log("land");
                ani.SetBool("islanding", true);
                ani.SetBool("isjump", false);
            }

            if (Input.GetKeyDown(jumpKey) && canjump == true && gchk.isGround)
            {
                ani.SetBool("isjump", true);
                rb.velocity = new Vector2(rb.velocity.x, 0);

                rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                canjump = false;
                Invoke("Hold", 0.1f);
                Invoke("HoldC", 0.3f);
                Invoke("Yde", 0.2f);
            }
            if (Input.GetKey(jumpKey))
            {
                if (!canHold)
                {
                    Y = 17;
                }
                if (canDe)
                {
                    Y -= 0.1f;
                }

                if (canHold)
                    rb.velocity = new Vector2(rb.velocity.x, Y);
            }
            if (Input.GetKeyUp(jumpKey))
            {
                canDe = false;
                canHold = false;
                jumpPower = temp;
            }



            if (Input.GetAxis("Horizontal") == 0 && canjump == true)
            {
                Invoke("RunCheck", 3f);
            }

            if (Input.GetAxis("Horizontal") != 0 && moveSpeed < 7)
            {
                moveSpeed = moveSpeed + 5 * Time.deltaTime;
            }

            if (rb.velocity.x > 0.5)
            {
                if (!audio.isPlaying && gchk.isGround)
                {
                    audio.Play();
                }
                ani.SetBool("ismove", true);
                if (rb.velocity.x > 0)
                {
                    sr.flipX = false;
                }
            }
            if (rb.velocity.x < 0.5)
            {
                if (!audio.isPlaying && gchk.isGround)
                {
                    audio.Play();
                }
                ani.SetBool("ismove", true);
                if (rb.velocity.x < 0)
                {
                    sr.flipX = true;
                }
            }
            if (rb.velocity.x < 0.5 && rb.velocity.x > -0.5)
            {
                audio.Stop();
                ani.SetBool("ismove", false);
                
            }

            
        }

        if (gchk.isGround)
        {
            ani.SetBool("islanding", false);
        }
        if (!gchk.isGround)
        {
            canjump = false;
        }

    }

    void Hold() => canHold = true;
    void HoldC() => canHold = false;
    void Yde() => canDe = true;



    private void RunCheck()
    {
        if (Input.GetAxis("Horizontal") == 0 && canjump == true)
        {
            moveSpeed = 2;
        }
    }


    void FixedUpdate()
    {
        if(!isPause && !isArrive && !enterlevel1 && !isdead && !ispipein)
        {
            Dir = Input.GetAxis("Horizontal") * moveSpeed;
            rb.velocity = new Vector2(Dir, rb.velocity.y);
        }
       
    }

    void respawn()
    {
        color.a = 1;
        sr.color = color;
        transform.position = tmp;
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            canjump = true;
        }

        if (gchk.isGround)
        {
            ani.SetBool("islanding", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        rb.velocity = new Vector2(rb.velocity.x, 0);

        if (gchk.isGround)
        {
            ani.SetBool("islanding", false);
        }

        if (collision.gameObject.tag == "Ground" && gchk.isGround)
        {
            ani.SetBool("islanding", false);
            canjump = true;
        }
        if (collision.gameObject.name != "movePlatform")
        {
            canHold = false;
        }
    }

    

    
    public IEnumerator Respawn()
    {
        Color color = sr.color;
        for (float i = 1.0f; i >= 0.0f; i -= 0.01f)
        {
            color.a = i;
            sr.color = color;
            yield return new WaitForSeconds(0.001f);
        }
        yield return new WaitForSeconds(1.0f);
        if(SceneManager.GetActiveScene().name == "Level1")
        {
            SceneManager.LoadScene("Level1");
        }
        if(SceneManager.GetActiveScene().name == "Level2")
        {
            SceneManager.LoadScene("Level2");
        }
        if (SceneManager.GetActiveScene().name == "Level3")
        {
            SceneManager.LoadScene("Level3");
        }
    }


    //private void OnCollisionExit2D(Collision2D collision) 
    //{
    //    if (collision.gameObject.tag == "Ground")
    //    {
            
    //        canjump = false;
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.gameObject.name == "StarCoin_1")
        {
            starcoin_ui.coin_1_collect = true;
        }
        if (collision.gameObject.name == "StarCoin_2")
        {
            starcoin_ui.coin_2_collect = true;
        }
        if (collision.gameObject.name == "StarCoin_3")
        {
            starcoin_ui.coin_3_collect = true;
        }
        if (collision.gameObject.name == "Goal")
        {
            if (SceneManager.GetActiveScene().name == "Level1")
            {
                StartCoroutine(st1_goal.Goal());
                st1_goal.isGoal = true;
            }
            if(SceneManager.GetActiveScene().name == "Level2")
            {
                StartCoroutine(st2_goal.Goal());
                st2_goal.isGoal = true;
            }
            if (SceneManager.GetActiveScene().name == "Level3")
            {
                StartCoroutine(st3_goal.Goal());
                st3_goal.isGoal = true;
            }

            isArrive = true;
        }
        if (collision.gameObject.name == "Goal_Bonus")
        {
            score.score += 500;
        }

        if (collision.gameObject.tag == "StarCoin")
        {
            score.score += 500;
        }

        if (collision.gameObject.name == "Fake_Goal")
        {
            StartCoroutine(fakegoaltrap.FakeGoal());
            isArrive = true;
        }
        if (collision.gameObject.name == "level_2_pipe_trap_collision")
        {
            bool trap = false;
            if (Input.GetAxisRaw("Horizontal") == 1 && !trap)
            {
                trap = true;
                isArrive = true;
                StartCoroutine(lvl2_pipe_trap.Trap_Active());
            }
        }



        if (collision.gameObject.tag == "deadzone")
        {
            isdead = true;
            gameObject.layer = 8;
            rb.velocity = new Vector2(0, 0);
            StartCoroutine(Respawn());
        }

        if(SceneManager.GetActiveScene().name == "Level2")
        {
            if(collision.gameObject.name == "move_btick_Back_trap_collision")
            {
                lvl2_move_back_trap.isblock = true;
            }
            if(collision.gameObject.name == "trap_active_collision")
            {
                lvl2_move_Brick.isActive = true;
            }
            if(collision.gameObject.name == "trap_active_collision_2")
            {
                lvl2_move_back_trap.iscollision = true;
            }
            
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Teleport_Pipe_Collision")
        {
            if(Input.GetAxisRaw("Vertical") == -1)
            {
                lvl2_tp_pipe.isActive = true;
                StartCoroutine(lvl2_tp_pipe.Pipe_Teleport());
            }
        }
    }

}






// I like P
// if you find this p
// you will be p

// im smart