using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageSelect_Intro : MonoBehaviour
{
    [Header("Intro Blackscreen")]
    [SerializeField] private GameObject blackScreen;

    [Header("Intro Circle Transition")]
    [SerializeField] private RectTransform CircleTransition;

    [Header("Intro Circle Transition Opacity")]
    [SerializeField] private Image MainCircle;
    [SerializeField] private Image Black1;
    [SerializeField] private Image Black2;
    [SerializeField] private Image Black3;
    [SerializeField] private Image Black4;


    public bool introEnd = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Intro());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Intro()
    {
        yield return new WaitForSeconds(1.0f);
        blackScreen.SetActive(false);
        StartCoroutine(CircleTransition_Opacity());
        for (float i = 0.05f; i <= 3.0f; i += 0.01f * Time.deltaTime * 300)
        {
            CircleTransition.localScale = new Vector3(i, i, i);
            yield return new WaitForSeconds(0.001f);
        }
        introEnd = true;
    }

    IEnumerator CircleTransition_Opacity()
    {
        Color color = MainCircle.color;
        for(float i = 1.0f; i >= 0.0f; i-= 0.0002f * Time.deltaTime * 300)
        {
            color.a = i;
            MainCircle.color = color;
            Black1.color = color;
            Black2.color = color;
            Black3.color = color;
            Black4.color = color;
            yield return new WaitForSeconds(0.001f);
        }
    }
}
