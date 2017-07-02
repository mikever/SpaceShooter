using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnce : MonoBehaviour
{
    public float MaxRadius = 1f;
    public float Interval = 5f;
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
        Spawn();
    }
    //-----------------------------
    void Spawn()
    {
        if (Origin == null) return;

        Vector3 SpawnPos = Origin.position + Random.onUnitSphere *
            MaxRadius;
        SpawnPos = new Vector3(SpawnPos.x, 0f, SpawnPos.z);
        Instantiate(ObjToSpawn, SpawnPos, Quaternion.identity);
    }
}
