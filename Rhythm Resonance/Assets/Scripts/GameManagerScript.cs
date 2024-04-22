using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;       // accesses text
using TMPro;
using JetBrains.Annotations;                // for textmeshpro

public class GameManagerScript : MonoBehaviour
{
    public AudioSource theMusic;
    public bool startPlaying;
    public BeatScrollerScript theBS;
    public static GameManagerScript instance;
    public int currentScore;
    public int scorePerNote = 100;
    public int scorePerGoodNote = 50;
    public int scorePerGreatNote = 75;
    public int scorePerPerfectNote = 100;
    public TextMeshProUGUI scoreText;      // make reference to ScoreText
    

    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        scoreText.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void NoteHit() { 
        Debug.Log("Hit On Time");
        //currentScore += scorePerNote;
        //scoreText.text = "Score: " + currentScore;

    }

    public void DisplayScore() {
        scoreText.text = "Score: " + currentScore;
    }

    public void GoodHit() {
        currentScore += scorePerGoodNote;
        DisplayScore();
    }

    public void GreatHit() {
        currentScore += scorePerGreatNote;
        DisplayScore();
    }

    public void PerfectHit() {
        currentScore += scorePerPerfectNote;
        DisplayScore();
    }

    public void NoteMissed() {
        Debug.Log("Missed Note");
    }
}
