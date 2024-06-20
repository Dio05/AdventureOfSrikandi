using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    TextMeshProUGUI textScore;

    public int score = 0;



    // Start is called before the first frame update
    void Start()
    {
        textScore = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void addScorelvl1()
    {
        score = score + 100;
        textScore.text = "Score = " + score;
    }

    public void addScorelvl2()
    {
        score = score + 50;
        textScore.text = "Score = " + score;
    }

    public void addScorelvl3()
    {
        score = score + 40;
        textScore.text = "Score = " + score;
    }

    public void addScorelvl3a()
    {
        score = score + 20;
        textScore.text = "Score = " + score;
    }
}
