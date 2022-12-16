using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin_Text : MonoBehaviour
{
    [Header("Coin Text")]
    [SerializeField] private Text coin_text;

    public int coin_amount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coin_text.text = string.Format("x {0:D2}", coin_amount);
    }
}
