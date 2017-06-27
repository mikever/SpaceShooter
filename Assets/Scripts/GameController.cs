using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    // Game Score
    public static int Score = 0;

    // Prefix
    public string ScorePrefix = string.Empty;

    // Score Text Object
    public Text ScoreText = null;

    // Game Over Text
    public Text GameOverText = null;

    public static GameController ThisInstance = null;

    //----------------------

    void Awake()
    {
        ThisInstance = this;
        Score = 0;
    }

    void Update()
    {
        // Update score text
        if (ScoreText != null)
            ScoreText.text = ScorePrefix + Score.ToString();
    }

    public static void GameOver()
    {
        if (ThisInstance.GameOverText != null)
            ThisInstance.GameOverText.gameObject.SetActive(true);
    }
}
