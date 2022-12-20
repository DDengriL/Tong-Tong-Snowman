using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor.Rendering;

public class Player_StageSelectManager : MonoBehaviour
{
    [Header("Escape Menu UI")]
    [SerializeField] private GameObject EscapeMenu;
    [SerializeField] private Material EscapeUIMat;

    [Header("Return To Title UI")]
    [SerializeField] private GameObject ReturnToTitle_UI;

    [Header("Leaderboard UI")]
    [SerializeField] private GameObject Leaderboard_UI;

    [Header("Data Reset UI")]
    [SerializeField] private GameObject Data_Reset_UI;

    [Header("Player Info")]
    SpriteRenderer player_sprite;
    [SerializeField] private GameObject enterLevelBlack;
   


    private float OffsetX = 0;

    [Header("Stage Select Level Text")]
    [SerializeField] private SpriteRenderer level1_text;
    private bool istxtshow = false;


    [Header("Data Reset System")]
    [SerializeField] private Text DataResetText;
    [SerializeField] private GameObject DataReset_Obj;
    [SerializeField] private Image DataResetCompleteBlackScrn;

    [Header("Save System")]
    [SerializeField] private Text SaveText;
    [SerializeField] private GameObject SaveTextObj;
    [SerializeField] private Image SaveCompleteblackScn;

    private bool saving = false;
    private bool leaderboard_open = false;
    private bool saveComplete = false;
    private bool enterlevel1 = false;

    [Header("Level 1 Door")]
    [SerializeField] private SpriteRenderer Level_1_Door;

    private bool Level1_Enable = false;


    [Header("Level 2 Door")]
    [SerializeField] private SpriteRenderer Level_2_Door;

    private bool Level2_Enable = false;

    [Header("Level Unlock")]
    public bool Level2Unlock;
    [SerializeField] private Animator level2_lock;

    [Header("Intro Circle Transition")]
    [SerializeField] private RectTransform CircleTransition;

    [Header("Player Script")]
    [SerializeField] private Player player;
    [SerializeField] private Animator player_anim;

    [Header("StageSelect Intro")]
    [SerializeField] private StageSelect_Intro stageIntro;

    [Header("Leaderboard Manager")]
    [SerializeField] private Leaderboard_Manager leaderboard_1;
    [SerializeField] private GameObject Leaderboard_manager;

    private void Awake()
    {
        ReturnToTitle_UI = GameObject.Find("ReturnToTitle");
        player_sprite = GetComponent<SpriteRenderer>();
        
        
        Debug.Log(ReturnToTitle_UI.name);
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        
    }
    // Start is called before the first frame update
    void Start()
    {
        enterLevelBlack.SetActive(false);
        EscapeMenu.SetActive(false);
        Leaderboard_UI.SetActive(false);
        ReturnToTitle_UI.SetActive(false);
        Data_Reset_UI.SetActive(false);
        DataReset_Obj.SetActive(false);
        SaveTextObj.SetActive(false);
        DataLoad();
        if(EscapeUIMat != null)
        {
            Debug.Log("EscapeUI Material 불러옴");
        }
        if(EscapeMenu != null)
        {
            Debug.Log("EscapeMenu GameObject 불러옴");
        }
    }

    // Update is called once per frame
    void Update()
    {
        StageSelecting();
        EscapeUIOffsetScrolling();
        EscapeMenuManager();
        PlayerAnimation();
        
    }
    private void PlayerAnimation()
    {
        if (EscapeMenu.activeSelf)
        {
            player_anim.SetBool("isjump", false);
            player_anim.SetBool("islanding", false);
            player_anim.SetBool("ismove", false);
        }
    }
    private void StageSelecting()
    {
        Level1();
        Level2();
    }

    private void EscapeMenuManager()
    {

        if(!saving && !leaderboard_open)
        {
            if(stageIntro.introEnd)
            {
                if (EscapeMenu.activeSelf)
                {
                    if (Input.GetKeyDown(KeyCode.Escape))
                    {
                        player.isPause = false;
                        EscapeMenu.SetActive(false);
                    }
                }
                else
                {
                    if (Input.GetKeyDown(KeyCode.Escape))
                    {
                        player.isPause = true;
                        EscapeMenu.SetActive(true);

                    }
                }
            }
        }
    }

    private void EscapeUIOffsetScrolling()
    {
        if(EscapeMenu.activeSelf || ReturnToTitle_UI.activeSelf || Data_Reset_UI.activeSelf)
        {
            if(OffsetX < 200)
            {
                OffsetX +=  0.2f * Time.deltaTime;
            }
            else
            {
                OffsetX = 0;
            }
            EscapeUIMat.mainTextureOffset = new Vector2(OffsetX, 0);
        }
    }

    private void DataLoad()
    {
        Level2Unlock = System.Convert.ToBoolean(PlayerPrefs.GetInt("Level2Data"));
        PlayerPrefs.Save();
        Debug.Log("Data Loaded");
    }

    IEnumerator DataSave()
    {
        SaveTextObj.SetActive(true);
        StartCoroutine(SaveTextOpacity());
        SaveText.text = "저장 중...";
        PlayerPrefs.SetInt("Level2Data", System.Convert.ToInt16(Level2Unlock));
        for (int i = 0; i < leaderboard_1.rankPlayerCount; i++)
        {
            PlayerPrefs.SetString("World 1 " + "Player " + i, leaderboard_1.rankName[i]);
            PlayerPrefs.SetFloat("World 1" + "Player " + i + " Best Score", leaderboard_1.bestScore[i]);
        }
        
        yield return new WaitForSeconds(1.5f);
       SaveText.text = "저장 완료!";
       saveComplete = true;
        yield return new WaitForSeconds(1.5f);
       StartCoroutine(SaveCompleteFade());
        
        
    }

     public void Escape_Menu_Data_Reset_Btn()
    {
        EscapeMenu.SetActive(false);
        Data_Reset_UI.SetActive(true);
    }

    public void Data_Reset_Cancel_Btn()
    {
        Data_Reset_UI.SetActive(false);
        player.isPause = false;
    }
    public void Data_Reset_Check_Btn()
    {
        StartCoroutine(Data_Reset());
    }

    IEnumerator Data_Reset()
    {
        Data_Reset_UI.SetActive(false);
        DataReset_Obj.SetActive(true);
        DataResetText.text = "데이터 초기화 중...";
        for (int i = 0; i <= leaderboard_1.bestScore.Length; i++)
        {
            PlayerPrefs.DeleteKey("World 1 " + "Player " + i);
            PlayerPrefs.DeleteKey("World 1 " + "Player " + i + " Best Score");
        }
        PlayerPrefs.DeleteKey("Level2Data");
        PlayerPrefs.DeleteKey("rankPlayerCount");
        yield return new WaitForSeconds(1.5f);
        DataResetText.text = "데이터 초기화 완료!";
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(SaveCompleteFade());
    }
    IEnumerator SaveCompleteFade()
    {
        Color color = SaveCompleteblackScn.color;
        for(float i = 0.0f; i <= 1.0f; i+= 0.004f * Time.deltaTime * 300)
        {
            color.a = i;
            SaveCompleteblackScn.color = color;
            yield return new WaitForSeconds(0.001f);
        }
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("MainMenu");
    }
    IEnumerator SaveTextOpacity()
    {
        while(!saveComplete)
        {
            Color color = SaveText.color;
            for (float i = 1.0f; i >= 0.8f; i -= 0.001f * Time.deltaTime * 300)
            {
                color.a = i;
                SaveText.color = color;
                yield return new WaitForSeconds(0.001f);
            }
            for (float i = 0.8f; i <= 1.0f; i += 0.001f * Time.deltaTime * 300)
            {
                color.a = i;
                SaveText.color = color;
                yield return new WaitForSeconds(0.001f);
            }
        }
    }

    private void Level1()
    {
        if (Level1_Enable && !enterlevel1)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                enterlevel1 = true;
                DontDestroyOnLoad(Leaderboard_manager);
                StartCoroutine(Enterlevel1());
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

    IEnumerator Enterlevel1()
    {
        player.enterlevel1 = true;
        StartCoroutine(player_opacity());
        for (float i = 3.0f; i >= 0.05f; i -= 0.01f * Time.deltaTime * 300)
        {
            CircleTransition.localScale = new Vector3(i, i, i);
            yield return new WaitForSeconds(0.001f);
        }
        enterLevelBlack.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("Level1");
    }

    IEnumerator player_opacity()
    {
        Color color = player_sprite.color;
        for (float i = 1.0f; i >= 0.0f; i -= 0.01f * Time.deltaTime * 300)
        {
            color.a = i;
            player_sprite.color = color;
            yield return new WaitForSeconds(0.001f);
        }
    }
    public void EscapeMenu_ReturnToTitle()
    {
        EscapeMenu.SetActive(false);
        leaderboard_open = true;
        ReturnToTitle_UI.SetActive(true);
    }

    public void EscapeMenu_Leaderboard()
    {
        EscapeMenu.SetActive(false);
        leaderboard_open = true;
        Leaderboard_UI.SetActive(true);
    }

    public void Leaderboard_Close()
    {
        Leaderboard_UI.SetActive(false);
        leaderboard_open = false;
        player.isPause = false;
    }

    public void TitleCheckBtn()
    {
        ReturnToTitle_UI = GameObject.Find("ReturnToTitle");
        if (ReturnToTitle_UI == null)
        {
            Debug.Log("Error");
        }
        
        saving = true;
        ReturnToTitle_UI.SetActive(false);
        StartCoroutine(DataSave());

    }

    public void TitleCancelBtn()
    {
        player.isPause = false;
        leaderboard_open = false;
        ReturnToTitle_UI.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Level1")
        {
            Level1_Enable = true;
            Level_1_Door.color = new Color32(255, 255, 255, 255);
            
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
        else
        {
            if(collision.gameObject.tag == "Level2" || collision.gameObject.name == "level2lock")
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))
                    StartCoroutine(level2lock_touch());
            }
        }
    }

    IEnumerator level2lock_touch()
    {
        
            level2_lock.SetBool("istouch", true);
            yield return new WaitForSeconds(1.5f);
            level2_lock.SetBool("istouch", false);
        
            
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Level1")
        {
            istxtshow = true;
            StopCoroutine(level1Text_hide());
            StartCoroutine(level1Text_show());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Level1")
        {
            istxtshow = false;
            Level1_Enable = false;
            Level_1_Door.color = new Color32(100, 100, 100, 255);
            StopCoroutine(level1Text_show());
            StartCoroutine(level1Text_hide());
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

    IEnumerator level1Text_show()
    {
        Color color = level1_text.color;
        for(float i = color.a; i <= 1.0f; i += 0.01f * Time.deltaTime  *300)
        {
            if(istxtshow)
            {
                color.a = i;
                level1_text.color = color;
                yield return new WaitForSeconds(0.001f);
            }
            
        }
    }

    IEnumerator level1Text_hide()
    {
        Color color = level1_text.color;
        for(float i = color.a; i >= 0.0f; i -= 0.01f * Time.deltaTime * 300)
        {
            if(!istxtshow)
            {
                color.a = i;
                level1_text.color = color;
                yield return new WaitForSeconds(0.001f);
            }
            
        }
    }
}
