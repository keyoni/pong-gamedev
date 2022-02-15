using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameObject paddle;

    private int targetCount = 3;
    public TextMeshProUGUI counterText;
    public TextMeshProUGUI counterBadText;
    public TextMeshProUGUI timerText;
    private bool _powerUpActive = false;

    private int _currentCount = 0;
    private int _currentBadCount = 0;

    public float timerMax = 5;
    private float _timer;

    private bool _timerStart = false;
    public string playerName;
    private  Vector3 regularSize;
    
    // Start is called before the first frame update
    void Start()
    {
        //counterText.text = paddle.name + ": ";
        _timer = timerMax;
        counterText.text = $"{playerName}:";
        counterBadText.text = $"Uh oh,{playerName}:";
        regularSize = paddle.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (_timerStart)
        {
            if (_timer > 0)
            {
                _timer -= Time.deltaTime;
                float seconds = Mathf.FloorToInt(_timer % 60);
                float milliseconds = (_timer % 1) * 1000;
                timerText.text = $"{seconds:00}:{milliseconds:000}";
            }
            else
            {
                timerText.text = "";
                _timerStart = false;
                _timer = timerMax;
                PowerUpDeactivate();
            }
        }
    }

    // private void OnCollisionEnter(Collision collision)
    // {
    //     if (!_powerUpActive) {
    //         if (collision.gameObject.tag.Equals("Ball"))
    //         {
    //             if (_currentCount < targetCount)
    //             {
    //                 counterText.text  += " |";
    //                 _currentCount++;
    //             }
    //             else if (_currentCount == targetCount)
    //             {
    //                 counterText.text = "POWER UP ACTIVE";
    //                 _powerUpActive = true;
    //                 PowerUpActivate();
    //                 _currentCount = 0;
    //             }
    //         }
    //     }
    // }

    private void PowerUpActivate()
    {
        _timerStart = true;
        paddle.transform.localScale += new Vector3(0, 0, 1);

    }
    private void PowerUpBadActivate()
    {
        _timerStart = true;
        paddle.transform.localScale -= new Vector3(0, 0, 0.4f);

    }

    private void PowerUpDeactivate()
    {
        paddle.transform.localScale = regularSize;
        _powerUpActive = false;
        counterText.text = $"{playerName}:";
    }

    public void PowerUpCounter()
    {
        if (!_powerUpActive) {
            if (_currentCount < targetCount)
            {
                counterText.text  += " |";
                _currentCount++;
            }
            else if (_currentCount == targetCount)
            {
                counterText.text = "POWER UP ACTIVE";
                _powerUpActive = true;
                PowerUpActivate();
                _currentCount = 0;
            }
        }
        
    }
    public void PowerUpBadCounter()
    {
        if (!_powerUpActive) {
            if (_currentBadCount < targetCount)
            {
                counterBadText.text  += " |";
                _currentBadCount++;
            }
            else if (_currentBadCount == targetCount)
            {
                counterBadText.text = "Bad POWER UP ACTIVE";
                _powerUpActive = true;
                PowerUpBadActivate();
                _currentBadCount = 0;
            }
        }
        
    }
}
