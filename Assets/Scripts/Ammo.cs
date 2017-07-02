﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour {

    public float Damage = 100f;
    public float LifeTime = 2f;

    void OnEnable()
    {
        CancelInvoke();
        Invoke("Die", LifeTime);
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider Col)
    {
        //Get health component
        Health H = Col.gameObject.GetComponent<Health>();

        if (H == null) return;

        H.HealthPoints -= Damage;

        Die();
    }

    void Die()
    {
        gameObject.SetActive(false);
    }
}
