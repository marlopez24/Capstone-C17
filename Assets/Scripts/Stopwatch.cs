using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class Stopwatch : MonoBehaviour
{

    bool stopwatchActive = false;
    float currentTime;
    public Text currentTimeText;

    //Score
    int score;
    public Text scoreText;
    public float multiplier = 5;

    //public float highScore;
    //public Text highscoretext;


    private void Awake()
    {
        StartStopwatch();
    }

    //public void AddScore()
    //{
    //    score++;
    //}

    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
        //highScore = PlayerPrefs.GetFloat("Highscore");
    }

    // Update is called once per frame
    void Update()
    {
        if (stopwatchActive == true)
        {
            currentTime = currentTime + Time.deltaTime;
        }
        score = Mathf.RoundToInt(currentTime * multiplier);
        scoreText.text = score.ToString();
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        currentTimeText.text = time.ToString(@"mm\:ss|:fff");

        //highscoretext.text = highScore.ToString();

        //if(score > highScore)
        //{
        //    PlayerPrefs.SetFloat("Highscore", score);
        //}


    }

    public void StartStopwatch()
    {
        stopwatchActive = true;

    }

}
