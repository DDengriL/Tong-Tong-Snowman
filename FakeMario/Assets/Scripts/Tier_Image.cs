using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tier_Image : MonoBehaviour
{
    [Header("Tier Image")]
    [SerializeField] Sprite[] Tier_img;

    const float static_y = 694.8695f;

    float t;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = Vector3.Lerp(new Vector3(-358.7358f, static_y), new Vector3(2219.922f, static_y), t);
    }



    private void ImageChange()
    {
       
        
    }
}
