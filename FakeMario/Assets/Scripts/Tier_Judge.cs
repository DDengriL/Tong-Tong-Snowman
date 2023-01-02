using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UI;

public class Tier_Judge : MonoBehaviour
{

    Score score;
    [Header("Progress Bar")]
    [SerializeField] Image progress_bar;

    [Header("Tier Image")]
    [SerializeField] Sprite[] Tier_img;
    [SerializeField] Transform Tier_Obj;
    [SerializeField] SpriteRenderer Tier_Sprite;
    [SerializeField] Text tier_text;
    [SerializeField] Text score_Text;

    const float static_y = 694.8695f;
    float t;

    bool isiron;

    int tierRoutineCount;

    bool nextTier = false;

    public double currentScore;
    [SerializeField] private int testScore;

    private float waitTime = 1;

    float textOnly_Score = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        currentScore = testScore * 0.000125f;
        //score = GameObject.Find("ScoreManager").GetComponent<Score>();
        //ScoreCalculate();
        image_change();
        StartCoroutine(progress_condition());
        StartCoroutine(TierIconMove());
    }

    // Update is called once per frame
    void Update()
    {
        
        Debug.Log(t);
        Debug.Log($"progress bar 값 : {progress_bar.fillAmount} / 점수 : {currentScore}");

        Tier_Obj.transform.position = Vector3.Lerp(new Vector3(-358.7358f, static_y), new Vector3(2219.922f, static_y), t);
        Text_Change();
        if(textOnly_Score < testScore)
        {
            textOnly_Score+= Time.deltaTime * 900;
        }
        else
        {
            textOnly_Score = testScore;
        }
        score_Text.text = textOnly_Score.ToString("F0");
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

    IEnumerator TierIconMove()
    {
        int a = 7;
        for(int i = tierRoutineCount; i  > 0; i--)
        {
            for(float l = 0; l <= 0.53f; l += Time.deltaTime * 2)
            {
                t = l;
                yield return new WaitForSeconds(0.001f);
            }
            if(i == 1)
            {
                break;
            }
            
            yield return new WaitForSeconds(0.5f);
            for(float l = 0.53f; l <= 1; l += Time.deltaTime * 2)
            {
                t = l;
                yield return new WaitForSeconds(0.001f);
            }
            Tier_Sprite.sprite = Tier_img[a];
            a--;
        }
        yield return new WaitForSeconds(4.0f);
    }

   
    private void image_change()
    {
        if (testScore <= 1000)
        {
            tierRoutineCount = 1;
        }
        if (testScore > 1000 && testScore <= 2000)
        {
            tierRoutineCount = 2;

        }
        if (testScore > 2000 && testScore <= 3000)
        {
            tierRoutineCount = 3;
        }
        if (testScore > 3000 && testScore <= 4000)
        {
            tierRoutineCount = 4;
        }
        if (testScore > 4000 && testScore <= 5000)
        {
            tierRoutineCount = 5;
        }
        if (testScore > 5000 && testScore <= 6000)
        {
            tierRoutineCount = 6;
        }
        if (testScore > 6000 && testScore <= 7000)
        {
            tierRoutineCount = 7;
        }
        if (testScore > 7000 && testScore <= 8000)
        {
            tierRoutineCount = 8;
        }
        if (testScore > 8000)
        {
            tierRoutineCount = 9;
        }

    }

    private void Text_Change()
    {
        switch(progress_bar.fillAmount)
        {
            case 0:
                tier_text.text = "Iron";
                break;
            case 0.125f:
                tier_text.text = "Bronze";
                break;
            case 0.25f:
                tier_text.text = "Silver";
                break;
            case 0.375f:
                tier_text.text = "Gold";
                break;
            case 0.5f:
                tier_text.text = "Platinum";
                break;
            case 0.625f:
                tier_text.text = "Diamond";
                break;
            case 0.75f:
                tier_text.text = "Master";
                break;
            case 0.875f:
                tier_text.text = "Grand Master";
                break;
            case 1:
                tier_text.text = "Challenger";
                break;
        }
    }
    IEnumerator progress_condition()
    {
        
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
