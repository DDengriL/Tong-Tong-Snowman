using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tier_Judge : MonoBehaviour
{

    Score score;
    [Header("Progress Bar")]
    [SerializeField] Image progress_bar;
    public double score_value;
    
    // Start is called before the first frame update
    void Start()
    {
        //score = GameObject.Find("ScoreManager").GetComponent<Score>();
        StartCoroutine(Score());
    }

    // Update is called once per frame
    void Update()
    {
       
        Debug.Log($"progress bar °ª : {progress_bar.fillAmount} / Á¡¼ö : {score_value}");
        
    }

    private void ScoreCalculate()
    {
        for(double i = 0; i <= 1; i += 0.001f * Time.deltaTime)
        {
            if(score_value == 6000 * i)
            {
                break;
            }
            progress_bar.fillAmount = (float)i;
        }
    }

    IEnumerator Score()
    {
        for (double i = 0; i <= 1; i += 0.001f)
        {
            if (score_value == 6000 * i)
            {
                break;
            }
            progress_bar.fillAmount = (float)i;
            yield return new WaitForSeconds(0.001f);
        }
    }

  
}
