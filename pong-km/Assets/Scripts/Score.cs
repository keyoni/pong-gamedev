using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int scoreL = 0;
    private int scoreR = 0;
    public int scoreEnding = 5;
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
            scoreR++;
            Debug.Log("Right Scores!");  
            scoreText.color = Color.red;
        }
        else
        {
            scoreL++;
            Debug.Log("Left Scores!");
            scoreText.color = Color.blue;
        }

        Debug.Log("Score Left: " + scoreL + " Score Right: " + scoreR);
        scoreText.text = $"{scoreL} - {scoreR}";
      
        return scoreL == scoreEnding || scoreR == scoreEnding;
    }

    private void GameOver()
    {
        
        Debug.Log("Score Left: " + scoreL + " Score Right: " + scoreR);
        Debug.Log("Game Over");
        Debug.Log(scoreR > scoreL ? "Right Paddle Wins!" : "Left Paddle Wins!");

        scoreText.text =
            $"{(scoreR > scoreL ? "Right Paddle Wins!" : "Left Paddle Wins!")}\n Final Score: {scoreL} - {scoreR}";
            scoreR = 0;
        scoreL = 0;
        
        //To removed later for replay 
        Destroy(gameObject);
    }
}

