using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreOnDestroy : MonoBehaviour
{

    public int ScoreValue = 50;
    public Transform explosion;
    bool isQuitting;

    private void OnApplicationQuit()
    {
        isQuitting = true;
    }

    void OnDestroy()
    {
        GameController.Score += ScoreValue;
        GameController.deadEnemies++;
        if (!isQuitting)
        {
            Instantiate(explosion, new Vector3(0, 0, 0), Quaternion.identity);
            Destroy(explosion, 2.0f);
        }


        if (GameController.Score >= 400 && GameController.deadEnemies == 10)
        {
            SceneManager.LoadScene("Level2");
            Time.timeScale = 1f;
            Time.fixedDeltaTime = 0.02F * Time.timeScale;
        }

        if ((GameController.Score >= 1100) && (GameController.deadEnemies == 20))
        {
            SceneManager.LoadScene("Level3");
            Time.timeScale = 1f;
            Time.fixedDeltaTime = 0.02F * Time.timeScale;
        }

        if ((GameController.Score >= 12000) && (GameController.deadEnemies == 30))
        {
            SceneManager.LoadScene("Level4");
            Time.timeScale = 1f;
            Time.fixedDeltaTime = 0.02F * Time.timeScale;
        }

        if ((GameController.Score >= 20000) && (GameController.deadEnemies == 40))
        {
            SceneManager.LoadScene("Level5");
            Time.timeScale = 1f;
            Time.fixedDeltaTime = 0.02F * Time.timeScale;
        }

        if (GameController.Score >= 30000 && GameController.deadEnemies >= 45)
        {
            GameObject[] spawners = GameObject.FindGameObjectsWithTag("SpawningPoint");

            for (var i = 0; i < spawners.Length; i++)
            {
                Destroy(spawners[i]);
            }
        }

    }
}