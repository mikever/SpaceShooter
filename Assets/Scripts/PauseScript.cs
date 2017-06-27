using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour {
    Button myButton;            //will point to our button
    public GameObject menu;     //Assign in inspector
    bool showMenu;              //to hold value of menu is on or off
    int timeToggle;             //value to hold time toggle

    void Start()
    {
        //set value for timeToggle to on
        timeToggle = 1;

        //set a default value for our showMenu toggle
        showMenu = false;
        menu.SetActive(showMenu);   //initially hide menu
    }

    void Awake()
    {
        myButton = GetComponent<Button>();  //get access to button component here
        myButton.onClick.AddListener(() =>
        {
           pauseGame();
        });
    }

    void pauseGame()
    {
        //flip toggle for showing menu
        showMenu = !showMenu;

        //show or hide menu based on toggle
        menu.SetActive(showMenu);

        //check value of time toggle
        if (showMenu)
        {
            timeToggle = 0;
        } else
        {
            timeToggle = 1;
        }

        //pause or unpause
        Time.timeScale = timeToggle;
    }
}
