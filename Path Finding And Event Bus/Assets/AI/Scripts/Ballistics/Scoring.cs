using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour {

    public Text scoreText;

    public int score;

    public string scoreStr;
    public string gameOver = "Game Over!";

	// Use this for initialization
	void Start () {

        score = 0;
        scoreStr = score.ToString();
		
	}
	
    public void IncrementScore()
    {
        score++;
        scoreStr = score.ToString();
    }

    public void GameOver()
    {
        scoreStr = gameOver;
    }

    void Update()
    {
        scoreText.text = scoreStr;
    }

}
