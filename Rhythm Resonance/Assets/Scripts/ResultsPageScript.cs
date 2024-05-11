using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using System;

public class ResultsPageScript : MonoBehaviour
{

    public TMPro.TextMeshProUGUI gradeText;
    public TMPro.TextMeshProUGUI perfectText;
    public TMPro.TextMeshProUGUI greatText;
    public TMPro.TextMeshProUGUI goodText;
    public TMPro.TextMeshProUGUI missText;

    public TMPro.TextMeshProUGUI maxComboText;
    public TMPro.TextMeshProUGUI scoreText;

    public TMPro.TextMeshProUGUI myGrade;

    public double audioSourceTime;

    public double clipLength;



    public int aGrade;
    public int bGrade;
    public int cGrade;
    public int dGrade;

    public GameObject resultsPage;

    public float delayTime = 3.0f;

    public bool startDelay = false;

    // Start is called before the first frame update
    void Start()
    {
        myGrade = gradeText.GetComponent<TextMeshProUGUI>();
        audioSourceTime = SongManager.Instance.audioSource.time;
        clipLength = SongManager.Instance.audioSource.clip.length;
        
    }

    void DisplayResults()
    {
        int numOfNotes = SongManager.Instance.numOfNotes;
        int numOfLongNotes = Lane.longSpawnIndex + 1;
        int numOfMiddleNotes = Lane.numOfMiddleNotes;

        int currentScore = ScoreManager.currentScore;

        int allPerfect = (numOfNotes * 100); //+ (numOfLongNotes * 100) + numOfMiddleNotes;
        //Debug.Log(allPerfect);

        aGrade = (int)(allPerfect * 0.90);
        bGrade = (int)(allPerfect * 0.80);
        cGrade = (int)(allPerfect * 0.70);
        dGrade = (int)(allPerfect * 0.60);

        if (currentScore == allPerfect)
        {
            gradeText.text = "S";
            myGrade.color = Color.yellow;
        }
        else if (currentScore >= aGrade)
        {
            gradeText.text = "A";
            myGrade.color = Color.yellow;
        }
        else if (currentScore >= bGrade)
        {
            gradeText.text = "B";
            myGrade.color = Color.green;
        }
        else if (currentScore >= cGrade)
        {
            gradeText.text = "C";
            myGrade.color = Color.cyan;
        }
        else if (currentScore >= dGrade)
        {
            gradeText.text = "D";
            myGrade.color = Color.blue;
        }
        else
        {
            gradeText.text = "E";
            myGrade.color = Color.gray;
        }

        perfectText.text = ScoreManager.Instance.numPerfectHits.ToString();
        greatText.text = ScoreManager.Instance.numGreatHits.ToString();
        goodText.text = ScoreManager.Instance.numGoodHits.ToString();
        missText.text = ScoreManager.Instance.numMisses.ToString();

        maxComboText.text = ScoreManager.maxCombo.ToString();
        scoreText.text = ScoreManager.currentScore.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        if (startDelay)
        {
            delayTime -= Time.deltaTime;
            if (delayTime <= 0 && Input.anyKey)
            {
                SceneManager.LoadScene("MainMenu");
            }
        }

        double currentTime = SongManager.GetAudioSourceTime();
        if (SongManager.Instance.songStarted && !SongManager.Instance.audioSource.isPlaying && currentTime == 0)
        {
            DisplayResults();
            startDelay = true;
            resultsPage.GetComponent<CanvasGroup>().alpha = 1f;
        }

    }
}
