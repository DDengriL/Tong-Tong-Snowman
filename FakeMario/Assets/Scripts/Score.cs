using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score = 0;
    [SerializeField] public Text score_text;

    Timer timer;
    Stage1_Goal goal;

    // Start is called before the first frame update
    void Start()
    {
        timer = GetComponent<Timer>();
        goal = GameObject.Find("Goal").GetComponent<Stage1_Goal>();
    }

    // Update is called once per frame
    void Update()
    {
        score_text.text = string.Format("{0:D8}", score);
    }
}
