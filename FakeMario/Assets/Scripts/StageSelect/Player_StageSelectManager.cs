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

    [Header("Leaderboard Choice UI")]
    [SerializeField] private GameObject Leaderboard_Choice_UI;

    [Header("Leaderboard UI")]
    [SerializeField] private GameObject Leaderboard_Stage1;
    [SerializeField] private GameObject Leaderboard_Stage2;
    [SerializeField] private GameObject Leaderboard_Stage3;


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
    private bool enterlevel2 = false;
    private bool enterlevel3 = false;

    [Header("Level 1 Door")]
    [SerializeField] private SpriteRenderer Level_1_Door;

    private bool Level1_Enable = false;


    [Header("Level 2 Door")]
    [SerializeField] private SpriteRenderer Level_2_Door;

    private bool Level2_Enable = false;

    [Header("Level 3 Door")]
    [SerializeField] private SpriteRenderer Level_3_Door;

    private bool Level3_Enable = false;



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
    [SerializeField] private Leaderboard_Manager_Stage2 leaderboard_2;
    [SerializeField] private GameObject Leaderboard_manager_2;
    [SerializeField] private Leaderboard_Manager_Stage3 leaderboard_3;
    [SerializeField] private GameObject Leaderboard_manager_3;

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
        Leaderboard_Choice_UI.SetActive(false);
        Leaderboard_Stage1.SetActive(false);
        Leaderboard_Stage2.SetActive(false);
        Leaderboard_Stage3.SetActive(false);
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
        Level3();
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
       
        PlayerPrefs.Save();
        Debug.Log("Data Loaded");
    }

    IEnumerator DataSave()
    {
        SaveTextObj.SetActive(true);
        StartCoroutine(SaveTextOpacity());
        SaveText.text = "저장 중...";
        
        for (int i = 0; i < leaderboard_1.rankPlayerCount; i++)
        {
            PlayerPrefs.SetString("World 1 " + "Player " + i, leaderboard_2.rankName_stage2[i]);
            PlayerPrefs.SetFloat("World 1" + "Player " + i + " Best Score", leaderboard_2.bestScore_stage2[i]);
        }
        for (int i = 0; i < leaderboard_2.rankPlayerCount_stage2; i++)
        {
            PlayerPrefs.SetString("World 2 " + "Player " + i, leaderboard_2.rankName_stage2[i]);
            PlayerPrefs.SetFloat("World 2" + "Player " + i + " Best Score", leaderboard_2.bestScore_stage2[i]);
        }
        for (int i = 0; i < leaderboard_3.rankPlayerCount_stage3; i++)
        {
            PlayerPrefs.SetString("World 3 " + "Player " + i, leaderboard_3.rankName_stage3[i]);
            PlayerPrefs.SetFloat("World 3" + "Player " + i + " Best Score", leaderboard_3.bestScore_stage3[i]);
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
        
        PlayerPrefs.DeleteKey("rankPlayerCount");

        for (int i = 0; i <= leaderboard_2.bestScore_stage2.Length; i++)
        {
            PlayerPrefs.DeleteKey("World 2 " + "Player " + i);
            PlayerPrefs.DeleteKey("World 2 " + "Player " + i + " Best Score");
        }

        PlayerPrefs.DeleteKey("rankPlayerCount_stage2");

        for (int i = 0; i <= leaderboard_3.bestScore_stage3.Length; i++)
        {
            PlayerPrefs.DeleteKey("World 3 " + "Player " + i);
            PlayerPrefs.DeleteKey("World 3 " + "Player " + i + " Best Score");
        }

        PlayerPrefs.DeleteKey("rankPlayerCount_stage3");
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

    public void Leaderboard_stage1_visible()
    {
        Leaderboard_Choice_UI.SetActive(false);
        Leaderboard_Stage1.SetActive(true);
        leaderboard_open = true;
    }

    public void Leaderboard_stage2_visible()
    {
        Leaderboard_Choice_UI.SetActive(false);
        Leaderboard_Stage2.SetActive(true);
        leaderboard_open = true;
    }

    public void Leaderboard_stage3_visible()
    {
        Leaderboard_Choice_UI.SetActive(false);
        Leaderboard_Stage3.SetActive(true);
        leaderboard_open = true;
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
        if(Level2_Enable && !enterlevel2)
        {
            if(Input.GetKeyDown(KeyCode.UpArrow))
            {
                enterlevel2 = false;
                DontDestroyOnLoad(Leaderboard_manager_2);
                StartCoroutine(Enterlevel2());
            }
        }
    }

    private void Level3()
    {
        if (Level3_Enable && !enterlevel3)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                enterlevel3 = false;
                DontDestroyOnLoad(leaderboard_3);
                StartCoroutine(Enterlevel3());
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
    IEnumerator Enterlevel2()
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
        SceneManager.LoadScene("Level2");
    }

    IEnumerator Enterlevel3()
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
        SceneManager.LoadScene("Level3");
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
        
        Leaderboard_Choice_UI.SetActive(true);
    }

    public void Leaderboard_Stage_1_Close()
    {
        Leaderboard_Stage1.SetActive(false);
        leaderboard_open = false;
        player.isPause = false;
    }

    public void Leaderboard_Stage_2_Close()
    {
        Leaderboard_Stage2.SetActive(false);
        leaderboard_open = false;
        player.isPause = false;
    }

    public void Leaderboard_Stage_3_Close()
    {
        Leaderboard_Stage3.SetActive(false);
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

       
            if(collision.gameObject.tag == "Level2")
            {
                Level2_Enable = true;
                Level_2_Door.color = new Color32(255, 255, 255, 255);
                
            }

        if (collision.gameObject.tag == "Level3")
        {
            Level3_Enable = true;
            Level_3_Door.color = new Color32(255, 255, 255, 255);

        }
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

        
            if(collision.gameObject.tag == "Level2")
            {
                Level2_Enable = false;
                Level_2_Door.color = new Color32(100, 100, 100, 255);
                
            }

        if (collision.gameObject.tag == "Level3")
        {
            Level3_Enable = false;
            Level_3_Door.color = new Color32(100, 100, 100, 255);

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
