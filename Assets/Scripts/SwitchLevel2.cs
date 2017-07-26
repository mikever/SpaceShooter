using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SwitchLevel2 : MonoBehaviour
{
    Button myButton;    //will point to our button

    // Use this for initialization
    void Start()
    {
        myButton = GetComponent<Button>();  //get access to button component

        myButton.onClick.AddListener(() =>
        {
            swapLevel();
        });
    }

    void swapLevel()
    {
        //make sure game is unpaused
        Time.timeScale = 1;
        //load the scene we want
        SceneManager.LoadScene("Level2");
    }
}