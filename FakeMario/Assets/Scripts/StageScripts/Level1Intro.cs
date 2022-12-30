using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level1Intro : MonoBehaviour
{
    [SerializeField] private RectTransform levelentercircle;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(gameObject.name);
        StartCoroutine(circle());
    }

    IEnumerator circle()
    {
        for(float i = 0.095f; i <= 4.5f; i += 0.01f * Time.deltaTime * 300)
        {
            levelentercircle.localScale = new Vector3(i, i, i);
            yield return new WaitForSeconds(0.001f);
        }
    }
}
