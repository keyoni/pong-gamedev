using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int _scoreL = 0;
    private int _scoreR = 0;
    public int scoreEnding = 5;
    public TextMeshProUGUI restartText;


    private void Start()
    {
        restartText.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.tag.Contains("Goal")) return;
        bool leftGoalHit = collision.gameObject.name.Equals("Left Goal");
        if (Scoring(leftGoalHit)) {
            GameOver();
        }

    }
    
    private bool Scoring(bool leftGoal)
    {
        if (leftGoal)
        {
            _scoreR++;
            Debug.Log("Right Scores!");  
            scoreText.color = Color.red;
        }
        else
        {
            _scoreL++;
            Debug.Log("Left Scores!");
            scoreText.color = Color.blue;
        }

        Debug.Log("Score Left: " + _scoreL + " Score Right: " + _scoreR);
        scoreText.text = $"{_scoreL} - {_scoreR}";
      
        return _scoreL == scoreEnding || _scoreR == scoreEnding;
    }

    private void GameOver()
    {
        
        Debug.Log("Score Left: " + _scoreL + " Score Right: " + _scoreR);
        Debug.Log("Game Over");
        Debug.Log(_scoreR > _scoreL ? "Right Paddle Wins!" : "Left Paddle Wins!");

        scoreText.text =
            $"{(_scoreR > _scoreL ? "Right Paddle Wins!" : "Left Paddle Wins!")}\n Final Score: {_scoreL} - {_scoreR}";
            _scoreR = 0;
        _scoreL = 0;
        
        restartText.gameObject.SetActive(true);
        //To removed later for replay 
        Destroy(this.gameObject);
        
    }
}

