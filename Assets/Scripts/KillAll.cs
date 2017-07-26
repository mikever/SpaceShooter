using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillAll : MonoBehaviour {

    public List<GameObject> enemies = new List<GameObject>();

    void OnTriggerEnter(Collider Col)
    {
        Die();
        DestroyAll();
    }

    void Die()
    {
        gameObject.SetActive(false);
    }

    private int shipCount;

    void DestroyAll()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Enemy");

        for (var i = 0; i < gameObjects.Length; i++)
        {
            Health H = gameObjects[i].GetComponent<Health>();

            if (H == null) return;

            H.HealthPoints = 0;
        }
    }


}
