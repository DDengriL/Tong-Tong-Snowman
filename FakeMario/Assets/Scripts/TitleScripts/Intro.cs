using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Intro : MonoBehaviour
{
    [Header("Intro Circle Transition")]
    [SerializeField] private RectTransform Circle_Transition;
    [SerializeField] private GameObject IntroBlackScreen;

    [Header("Game Title Object")]
    [SerializeField] private GameObject GameTitle;

    [Header("Player Object")]
    [SerializeField] private GameObject Player;

    [Header("PressAnyKey Text")]
    [SerializeField] private RectTransform AnyKey_Text;

    [Header("Title Bounce Animation")]
    [SerializeField] private Animator Title_anim;

    [Header("Fade Blackscreen When Starting Game")]
    [SerializeField] private Image startGame_Blackscreen;

    [Header("Intro Circle Opacity")]
    [SerializeField] private Image Circle_Transition_img;
    [SerializeField] private Image img1;
    [SerializeField] private Image img2;
    [SerializeField] private Image img3;
    [SerializeField] private Image img4;
    [SerializeField] private Image img5;
    [SerializeField] private Image img6;
    [SerializeField] private Image img7;
    [SerializeField] private Image img8;
    [SerializeField] private Image img9;
    [SerializeField] private Image img10;
    [SerializeField] private Image img11;
    [SerializeField] private Image img12;
    [SerializeField] private Image img13;
    [SerializeField] private Image img14;
    [SerializeField] private Image img15;
    [SerializeField] private Image img16;



    private bool AFKState = false;
    private bool isStart = false;
    private bool introEnd = false;
    // Start is called before the first frame update
    void Start()
    {
        Player.SetActive(false);
        StartCoroutine(IntroStart());
    }

    // Update is called once per frame
    void Update()
    {
        GameStarting();
    }
    private void GameStarting()
    {
        if(introEnd == true && AFKState == false && isStart == false)
        {
            if(Input.anyKeyDown)
            {
                isStart = true;
                StartCoroutine(StartingGame());
            }
        }
    }

    IEnumerator StartingGame()
    {
        Color color = startGame_Blackscreen.color;
        for(float i = 0.0f; i <= 1.0f; i += 0.01f)
        {
            color.a = i;
            startGame_Blackscreen.color = color;
            yield return new WaitForSeconds(0.001f);
        }
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("StageSelect");
    }
    IEnumerator IntroStart()
    {
        yield return new WaitForSeconds(1.5f);
        IntroBlackScreen.SetActive(false);
        StartCoroutine(IntroOpacity());
        for(float i = 0.01f; i <= 2.5f; i += 0.01f)
        {
            Circle_Transition.localScale = new Vector3(i, i, i);
            yield return new WaitForSeconds(0.001f);
        }
        Player.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        Title_anim.SetBool("Activate", true);
        yield return new WaitForSeconds(1.0f);
        StartCoroutine(AnyKeyText_Scale());
        introEnd = true;
        yield return new WaitForSeconds(20.0f);
        if(isStart == false)
        {
            AFKState = true;
        }
        
        while(GameTitle.transform.position.y <= 6.4f)
        {
            GameTitle.transform.Translate(0, 1, 0);
        }
        yield return new WaitForSeconds(1.0f);
        StartCoroutine(OutroOpacity());
        for (float i = 2.5f; i >= 0.01f; i -= 0.01f)
        {
            Circle_Transition.localScale = new Vector3(i, i, i);
            yield return new WaitForSeconds(0.001f);
        }
        IntroBlackScreen.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator OutroOpacity()
    {

        Color color = img1.color;

        yield return new WaitForSeconds(0.2f);
        for (float i = 0.0f; i <= 1.0f; i +=1.0f)
        {
            color.a = i;

            img1.color = color;
            img2.color = color;
            img3.color = color;
            img4.color = color;
            img5.color = color;
            img6.color = color;
            img7.color = color;
            img8.color = color;
            img9.color = color;
            img10.color = color;
            img11.color = color;
            img12.color = color;
            img13.color = color;
            img14.color = color;
            img15.color = color;
            img16.color = color;
            Circle_Transition_img.color = color;
            yield return new WaitForSeconds(0.001f);

        }
    }
    IEnumerator IntroOpacity()
    {
        
        Color color = img1.color;

        yield return new WaitForSeconds(0.2f);
        for(float i = 1.0f; i >= 0.0f; i -= 0.001f)
        {
            color.a = i;
            
            img1.color = color;
            img2.color = color;
            img3.color = color;
            img4.color = color;
            img5.color = color;
            img6.color = color;
            img7.color = color;
            img8.color = color;
            img9.color = color;
            img10.color = color;
            img11.color = color;
            img12.color = color;
            img13.color = color;
            img14.color = color;
            img15.color = color;
            img16.color = color;
            Circle_Transition_img.color = color;
            yield return new WaitForSeconds(0.001f);

        }
    }

    IEnumerator AnyKeyText_Scale()
    {
        for(float i = 0.0f; i <= 1.0f; i += 0.01f)
        {
            AnyKey_Text.localScale = new Vector3(i, i, i);
            yield return new WaitForSeconds(0.001f);
        }
        while(AFKState == false)
        {
            for(float i = 1.0f; i >= 0.95f; i -= 0.0001f)
            {
                if(AFKState)
                {
                    break;
                }
                AnyKey_Text.localScale = new Vector3(i, i, i);
                yield return new WaitForSeconds(0.001f);
            }
            for (float i = 0.95f; i <= 1.0f; i += 0.0001f) 
            {
                if (AFKState)
                {
                    break;
                }
                AnyKey_Text.localScale = new Vector3(i, i, i);
                yield return new WaitForSeconds(0.001f);
            }
        }
        for(float i = 1.0f; i >= 0.0f; i -= 0.01f)
        {
            AnyKey_Text.localScale = new Vector3(i, i, i);
            yield return new WaitForSeconds(0.001f);
        }
    }
}
