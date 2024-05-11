using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public AudioSource hitSFX;
    public AudioSource missSFX;
    public TMPro.TextMeshProUGUI scoreText;
    public TMPro.TextMeshProUGUI comboText;
    public static int comboScore;
    public static int currentScore;
    public int scorePerGoodNote = 50;
    public int scorePerGreatNote = 75;
    public int scorePerPerfectNote = 100;

    public int numGoodHits = 0;
    public int numGreatHits = 0;
    public int numPerfectHits = 0;
    public int numMisses = 0;

    public static int maxCombo = 0;
    void Start()
    {
        Instance = this;
        comboScore = 0;
        currentScore = 0;
        numGoodHits = 0;
        numGreatHits = 0;
        numPerfectHits = 0;
        numMisses = 0;
    }
    public static void Hit()
    {
        comboScore += 1;
        if (comboScore > maxCombo) {
            maxCombo = comboScore;
        }
    }
    public static void Miss()
    {
        comboScore = 0;
        Instance.numMisses += 1;   
    }

    public void GoodHit() {
        currentScore += scorePerGoodNote;
        numGoodHits += 1;
    }

    public void GreatHit() {
        currentScore += scorePerGreatNote;
        numGreatHits += 1;
    }

    public void PerfectHit() {
        currentScore += scorePerPerfectNote;
        numPerfectHits += 1;
    }

    public void LongHit() {
        currentScore += 1;
    }
    private void Update()
    {
        scoreText.text = currentScore.ToString();
        comboText.text = "Combo " + comboScore.ToString();
    }
}