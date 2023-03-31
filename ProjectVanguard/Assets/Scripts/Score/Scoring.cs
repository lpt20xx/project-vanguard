using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    public Text scoreText;
    public int score;
    public int maxScore;

    public GameObject scoreObj;
    public GameObject winText;

    public GameObject crosshair;
    public GameObject playerHealth;

    public GameObject enemy;

    public GameObject levelControl;

    public static bool isWin = false;
    private void Start()
    {
        this.SetStartScore();
    }

    public void SetStartScore()
    {
        score = 0;
    }

    public void AddScore(int newScore)
    {
        score += newScore;
    }

    

    // Update is called once per frame
    void Update()
    {
        this.UpdateScore();
    }

    public void UpdateScore()
    {
        scoreText.text = "Score: " + score;


        if(score == maxScore)
        {
            scoreObj.SetActive(false);
            crosshair.SetActive(false);
            playerHealth.SetActive(false);

            enemy.SetActive(false);

            winText.SetActive(true);

            if(AudioManager.Instance == null)
            {
                return;
            }

            AudioManager.Instance.musicSource.Stop();
            
            isWin = true;

            levelControl.GetComponent<LevelCompleteScript>().enabled = true;
        }
    }

    
}
