using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDestroy : MonoBehaviour {
    public float DestroyTime = 2f;

	// Use this for initialization
	void Start () {
        Invoke("Die", DestroyTime);
	}
	
    void Die ()
    {
        Destroy(gameObject);
    }
}
