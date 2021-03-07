﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level01Controller : MonoBehaviour
{
    [SerializeField] Text _currentScoreTextView;

    int _currentScore;

    private void Update()
    {
        // Increase Score
        //TODO replace with real implementation later
        if (Input.GetKeyDown(KeyCode.Q))
        {
            IncreaseScore(5);
        }
        // Exit Level
        //TODO bring up popup menu for navigation


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitLevel();
        }
    }
    public void ExitLevel()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void IncreaseScore(int scoreIncrease)
    {
        // increase score
        _currentScore += scoreIncrease;
        // update score display, so we can see the new score
        _currentScoreTextView.text =
            "Score: " + _currentScore.ToString();
    }
}
