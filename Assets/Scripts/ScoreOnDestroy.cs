using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreOnDestroy : MonoBehaviour {

    public int ScoreValue = 50;

    void OnDestroy()
    {
        GameController.Score += ScoreValue;

        if (GameController.Score == 500)
        {
            SceneManager.LoadScene("Level2");
            Time.timeScale = 1f;
            Time.fixedDeltaTime = 0.02F * Time.timeScale;
        }

        if (GameController.Score > 500 && GameController.Score < 200)
        {
            SceneManager.LoadScene("Level3");
            Time.timeScale = 1f;
            Time.fixedDeltaTime = 0.02F * Time.timeScale;
        }

        if (GameController.Score > 700)
        {
            // TODO End Game
        }

    }
}
