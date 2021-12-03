using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public GameObject scoreText;
    public int scoreNumber;

    void Start()
    {
        scoreNumber = 0;
    }

    void ScoreText(int score)
    {
        scoreNumber += score;
        scoreText.GetComponent<Text>().text = "Score: " + scoreNumber;
    }
}
