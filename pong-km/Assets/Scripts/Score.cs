using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
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
        }
        else
        {
            scoreL++;
            Debug.Log("Left Scores!");
        }

        Debug.Log("Score Left: " + scoreL + " Score Right: " + scoreR);
        return scoreL == scoreEnding || scoreR == scoreEnding;
    }

    private void GameOver()
    {
        
        Debug.Log("Score Left: " + scoreL + " Score Right: " + scoreR);
        Debug.Log("Game Over");
        Debug.Log(scoreR > scoreL ? "Right Paddle Wins!" : "Left Paddle Wins!");

        scoreR = 0;
        scoreL = 0;
        
        //To removed later for replay 
        Destroy(gameObject);
    }
}

