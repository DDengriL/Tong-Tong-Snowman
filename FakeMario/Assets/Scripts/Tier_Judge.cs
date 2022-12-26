using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UI;

public class Tier_Judge : MonoBehaviour
{

    Score score;
    [Header("Progress Bar")]
    [SerializeField] Image progress_bar;
    
    public double currentScore;
    [SerializeField] private int testScore;

    private float waitTime = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        //score = GameObject.Find("ScoreManager").GetComponent<Score>();
        //ScoreCalculate();
        currentScore = testScore * 0.000125f;
        StartCoroutine(progress_condition());
    }

    // Update is called once per frame
    void Update()
    {
       
        Debug.Log($"progress bar 값 : {progress_bar.fillAmount} / 점수 : {currentScore}");
        /*if(progress_bar.fillAmount <= currentScore)
        {
            progress_bar.fillAmount += 0.001f * Time.deltaTime * 20;
        }*/
    }

    private void ScoreCalculate()
    {
        currentScore = score.score * 0.000125f; // 1 / 8000으로 progressbar 값 초기화
    }

    

    private void progress_fill()
    {
        if (progress_bar.fillAmount <= currentScore)
        {
            progress_bar.fillAmount += 0.001f * Time.deltaTime * 30;
            }
    }

    IEnumerator progress_condition()
    {
        Color color;
        if (testScore <= 1000)
        {
            yield return new WaitForSeconds(waitTime);
            for (; ; )
            {
                if(progress_bar.fillAmount >= currentScore)
                {
                    break;
                }
                progress_fill();
                yield return new WaitForSeconds(0.001f);
            }
            
        }
        if (testScore > 1000 && testScore <= 2000)
        {
            ColorUtility.TryParseHtmlString("#CD7F32", out color);
            progress_bar.color = color;
            yield return new WaitForSeconds(waitTime);
            progress_bar.fillAmount = 0.125f;
            yield return new WaitForSeconds(waitTime);

            for (; ; )
            {
                if (progress_bar.fillAmount >= currentScore)
                {
                    break;
                }
                progress_fill();
                yield return new WaitForSeconds(0.001f);
            }
        }
        if (testScore > 2000 && testScore <= 3000)
        {
            yield return new WaitForSeconds(waitTime);
            progress_bar.fillAmount = 0.125f;
            yield return new WaitForSeconds(waitTime);
            progress_bar.fillAmount = 0.25f;
            yield return new WaitForSeconds(waitTime);
            for (; ; )
            {
                if (progress_bar.fillAmount >= currentScore)
                {
                    break;
                }
                progress_fill();
                yield return new WaitForSeconds(0.001f);
            }
        }
        if(testScore > 3000 && testScore <= 4000)
        {
            yield return new WaitForSeconds(waitTime);
            progress_bar.fillAmount = 0.125f;
            yield return new WaitForSeconds(waitTime);
            progress_bar.fillAmount = 0.25f;
            yield return new WaitForSeconds(waitTime);
            progress_bar.fillAmount = 0.375f;
            yield return new WaitForSeconds(waitTime);
            for (; ; )
            {
                if (progress_bar.fillAmount >= currentScore)
                {
                    break;
                }
                progress_fill();
                yield return new WaitForSeconds(0.001f);
            }
        }
        if(testScore > 4000 && testScore <= 5000)
        {
            yield return new WaitForSeconds(waitTime);
            progress_bar.fillAmount = 0.125f;
            yield return new WaitForSeconds(waitTime);
            progress_bar.fillAmount = 0.25f;
            yield return new WaitForSeconds(waitTime);
            progress_bar.fillAmount = 0.375f;
            yield return new WaitForSeconds(waitTime);
            progress_bar.fillAmount = 0.5f;
            yield return new WaitForSeconds(waitTime);
            for (; ; )
            {
                if (progress_bar.fillAmount >= currentScore)
                {
                    break;
                }
                progress_fill();
                yield return new WaitForSeconds(0.001f);
            }
        }
        if(testScore > 5000 && testScore <= 6000)
        {
            yield return new WaitForSeconds(waitTime);
            progress_bar.fillAmount = 0.125f;
            yield return new WaitForSeconds(waitTime);
            progress_bar.fillAmount = 0.25f;
            yield return new WaitForSeconds(waitTime);
            progress_bar.fillAmount = 0.375f;
            yield return new WaitForSeconds(waitTime);
            progress_bar.fillAmount = 0.5f;
            yield return new WaitForSeconds(waitTime);
            progress_bar.fillAmount = 0.625f;
            yield return new WaitForSeconds(waitTime);
            for (; ; )
            {
                if (progress_bar.fillAmount >= currentScore)
                {
                    break;
                }
                progress_fill();
                yield return new WaitForSeconds(0.001f);
            }
        }
        if(testScore > 6000 && testScore <= 7000)
        {
            yield return new WaitForSeconds(waitTime);
            progress_bar.fillAmount = 0.125f;
            yield return new WaitForSeconds(waitTime);
            progress_bar.fillAmount = 0.25f;
            yield return new WaitForSeconds(waitTime);
            progress_bar.fillAmount = 0.375f;
            yield return new WaitForSeconds(waitTime);
            progress_bar.fillAmount = 0.5f;
            yield return new WaitForSeconds(waitTime);
            progress_bar.fillAmount = 0.625f;
            yield return new WaitForSeconds(waitTime);
            progress_bar.fillAmount = 0.75f;
            yield return new WaitForSeconds(waitTime);
            for (; ; )
            {
                if (progress_bar.fillAmount >= currentScore)
                {
                    break;
                }
                progress_fill();
                yield return new WaitForSeconds(0.001f);
            }
        }
        if(testScore > 7000 && testScore <= 8000)
        {
            yield return new WaitForSeconds(waitTime);
            progress_bar.fillAmount = 0.125f;
            yield return new WaitForSeconds(waitTime);
            progress_bar.fillAmount = 0.25f;
            yield return new WaitForSeconds(waitTime);
            progress_bar.fillAmount = 0.375f;
            yield return new WaitForSeconds(waitTime);
            progress_bar.fillAmount = 0.5f;
            yield return new WaitForSeconds(waitTime);
            progress_bar.fillAmount = 0.625f;
            yield return new WaitForSeconds(waitTime);
            progress_bar.fillAmount = 0.75f;
            yield return new WaitForSeconds(waitTime);
            progress_bar.fillAmount = 0.875f;
            yield return new WaitForSeconds(waitTime);
            for (; ; )
            {
                if (progress_bar.fillAmount >= currentScore)
                {
                    break;
                }
                progress_fill();
                yield return new WaitForSeconds(0.001f);
            }
        }
        if(testScore > 8000)
        {
            yield return new WaitForSeconds(waitTime);
            progress_bar.fillAmount = 0.125f;
            yield return new WaitForSeconds(waitTime);
            progress_bar.fillAmount = 0.25f;
            yield return new WaitForSeconds(waitTime);
            progress_bar.fillAmount = 0.375f;
            yield return new WaitForSeconds(waitTime);
            progress_bar.fillAmount = 0.5f;
            yield return new WaitForSeconds(waitTime);
            progress_bar.fillAmount = 0.625f;
            yield return new WaitForSeconds(waitTime);
            progress_bar.fillAmount = 0.75f;
            yield return new WaitForSeconds(waitTime);
            progress_bar.fillAmount = 0.875f;
            yield return new WaitForSeconds(waitTime);
            progress_bar.fillAmount = 1;
        }
    }

    

  
}
