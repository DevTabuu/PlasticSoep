using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    [SerializeField]
    private Text _scoreDisplay;

    [SerializeField]
    private float _updateTime;

    private float _updateTimer;
    private int _score;
    private int _displayScore;

    private void Start()
    {
        _updateTimer = _updateTime;
    }

    public void AddScore(int score)
    {
        _score += score;
        Debug.Log("Score: " + _score);
    }

    private void Update()
    {
        _updateTimer -= Time.deltaTime;
        if (_updateTimer <= 0)
        {
            if (_displayScore < _score)
                _displayScore++;

            else if (_displayScore > _score)
                _displayScore--;

            _updateTimer = _updateTime;
        }

        _scoreDisplay.text = "Score: " + _displayScore;
    }
}
