using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperAmmo : MonoBehaviour {

    void Start()
    {
    }

    void OnTriggerEnter(Collider Col)
    {
        Die();
        PlayerController.superShot = true;
    }

    void Die()
    {
        gameObject.SetActive(false);
    }
}
