using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public float MaxRadius = 1f;
    public float Interval = 5f;
    public float firstInstance = 0f;
    public GameObject ObjToSpawn = null;
    private Transform Origin = null;
    //-----------------------------
    void Awake()
    {
        Origin = GameObject.FindGameObjectWithTag
            ("Player").GetComponent<Transform>();
    }
    //-----------------------------
    //Use this for initialization
    void Start()
    {
        InvokeRepeating("Spawn", firstInstance, Interval);
    }
    //-----------------------------
    void Spawn ()
    {
        if (Origin == null) return;

        Vector3 SpawnPos = Origin.position + Random.onUnitSphere *
            MaxRadius;
        SpawnPos = new Vector3(SpawnPos.x, 0f, SpawnPos.z);
        Instantiate(ObjToSpawn, SpawnPos, Quaternion.identity);
    }
}
