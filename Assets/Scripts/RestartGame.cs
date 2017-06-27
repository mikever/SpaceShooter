using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour {
    Button myButton;    //will point to our button

    private void Awake()
    {
        myButton = GetComponent<Button>();
        myButton.onClick.AddListener(() =>
        {
            restartGame();
        });
    }

    void restartGame()
    {
        //make sure game is unpaused
        Time.timeScale = 1;
        //reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
