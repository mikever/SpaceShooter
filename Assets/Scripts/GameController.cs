using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    // Game Score
    public static int Score = 0;

    // Health Score
    public static float Health = 0;

    // Prefixes
    public string ScorePrefix = string.Empty;

    // Score Text Object
    public Text ScoreText = null;

    // Player health text
    public Text HealthText = null;

    // Game Over Text
    public Text GameOverText = null;

    // number of killed enemies
    public static int deadEnemies = 0;

    public static GameController ThisInstance = null;

    //----------------------

    void Awake()
    {
        ThisInstance = this;
    }

    void Update()
    {
        // Update score text
        if (ScoreText != null)
            ScoreText.text = ScorePrefix + Score.ToString();

        // Update player health text
        if (HealthText != null)
        {
            HealthText.text = "Health: " + Health.ToString();
        }
    }

    public static void GameOver()
    {
        if (ThisInstance.GameOverText != null)
            ThisInstance.GameOverText.gameObject.SetActive(true);
    }
}