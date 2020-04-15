﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    [SerializeField] Text _scoreText;
    [SerializeField] Text _ballsLeftText;

    string _scoreTemplate = "Score: ";
    string _ballsLeftTemplate = "Balls left: ";

    float _ballsLeft;
    int _score = 0;

    void Start()
    {
        _ballsLeft = ConfigurationUtils.BallsNumber;
        _ballsLeftText.text = _ballsLeftTemplate + _ballsLeft.ToString();
        _scoreText.text = _scoreTemplate + _score.ToString();

        Ball.OnDeath += DecreaseBallsNumber;
        Block.OnBlockDeath += IncreaseScore;
    }

    void DecreaseBallsNumber()
    {
        _ballsLeft--;
        _ballsLeftText.text = _ballsLeftTemplate + _ballsLeft;
    }

    void IncreaseScore(int points)
    {
        _score += points;
        _scoreText.text = _scoreTemplate + _score.ToString();
    }

    private void OnDisable()
    {
        Ball.OnDeath -= DecreaseBallsNumber;
        Block.OnBlockDeath -= IncreaseScore;

    }
}
