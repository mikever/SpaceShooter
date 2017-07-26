using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public Transform[] EnemyTurretTransforms;
    public float fireDelay = 5.0f;
    public Transform prefab;
    
    // Update is called once per frame
	void Start () {
        // Fire control
        InvokeRepeating("enemyFire", 5, fireDelay);
	}

    public void enemyFire()
    {
        foreach (Transform T in EnemyTurretTransforms)
        {
            Instantiate(prefab, T.position, T.rotation);
        }
    }
}
