using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_StageSelectManager : MonoBehaviour
{
    [Header("Escape Menu UI")]
    [SerializeField] private GameObject EscapeMenu;
    [SerializeField] private Material EscapeUIMat;

    private float OffsetX = 0;

    [Header("Save System")]
    [SerializeField] private Text SaveText;
    [SerializeField] private GameObject SaveTextObj;
    [SerializeField] private Image SaveCompleteblackScn;

    private bool saving = false;
    private bool saveComplete = false;

    [Header("Level 1 Door")]
    [SerializeField] private SpriteRenderer Level_1_Door;

    private bool Level1_Enable = false;


    [Header("Level 2 Door")]
    [SerializeField] private SpriteRenderer Level_2_Door;

    private bool Level2_Enable = false;

    [Header("Level Unlock")]
    public bool Level2Unlock;


    [Header("Player Script")]
    [SerializeField] private Player player;

    private void Awake()
    {
        EscapeMenu = GameObject.Find("ESC");
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        
    }
    // Start is called before the first frame update
    void Start()
    {
        EscapeMenu.SetActive(false);
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

        
    }

    private void StageSelecting()
    {
        Level1();
        Level2();
    }

    private void EscapeMenuManager()
    {

        if(!saving)
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

    private void EscapeUIOffsetScrolling()
    {
        if(EscapeMenu.activeSelf)
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
    }

    IEnumerator DataSave()
    {
        SaveTextObj.SetActive(true);
        StartCoroutine(SaveTextOpacity());
        SaveText.text = "저장 중...";
        PlayerPrefs.SetInt("Level2Data", System.Convert.ToInt16(Level2Unlock));
        yield return new WaitForSeconds(1.5f);
       SaveText.text = "저장 완료!";
       saveComplete = true;
        yield return new WaitForSeconds(1.5f);
       StartCoroutine(SaveCompleteFade());
        
        
    }

  
    IEnumerator SaveCompleteFade()
    {
        Color color = SaveCompleteblackScn.color;
        for(float i = 0.0f; i <= 1.0f; i+= 0.004f)
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
            for (float i = 1.0f; i >= 0.8f; i -= 0.001f)
            {
                color.a = i;
                SaveText.color = color;
                yield return new WaitForSeconds(0.001f);
            }
            for (float i = 0.8f; i <= 1.0f; i += 0.001f)
            {
                color.a = i;
                SaveText.color = color;
                yield return new WaitForSeconds(0.001f);
            }
        }
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

    public void CheckBtn()
    {
        
        saving = true;
        EscapeMenu.SetActive(false);
        StartCoroutine(DataSave());

    }

    public void CancelBtn()
    {
        player.isPause = false;
        EscapeMenu.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Level1")
        {
            Level1_Enable = true;
            Level_1_Door.color = Color.green;
            Debug.LogError("player reached level 1 door");
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
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Level1")
        {
            Level1_Enable = false;
            Level_1_Door.color = Color.white;
            Debug.LogError("player exited level 1 door");
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
}
