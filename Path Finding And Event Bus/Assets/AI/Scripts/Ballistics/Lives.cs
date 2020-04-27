using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour {

    public Text livesText;

    public int lives;

    // Use this for initialization
    void Start()
    {

        lives = 3;

    }

    public void DecreaseLives()
    {
        lives--;
    }

    void Update()
    {
        livesText.text = lives.ToString();    
    }


}
