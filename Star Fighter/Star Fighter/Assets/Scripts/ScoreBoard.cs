using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    Text scoreBoard;
    Score score;

    // Start is called before the first frame update
    void Start()
    {
        scoreBoard = GetComponent<Text>();
        score = FindObjectOfType<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreBoard.text = score.GetScore().ToString();
    }
}
