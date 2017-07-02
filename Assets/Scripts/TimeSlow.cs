using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeSlow : MonoBehaviour {

    private float timeRemaining;
    void Start()
    {
        timeRemaining = 5f;
    }

    void OnTriggerEnter(Collider Col)
    {
        Die();
            Time.timeScale = 0.5f;
            Time.fixedDeltaTime = 0.02F * Time.timeScale;
        Invoke("resumeTime", timeRemaining);
    }

    void Die()
    {
        gameObject.SetActive(false);
    }

    void resumeTime()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;
    }
}
