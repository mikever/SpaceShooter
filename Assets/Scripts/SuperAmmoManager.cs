using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperAmmoManager : MonoBehaviour {

    // reference to super ammo prefab
    public GameObject SuperAmmoPrefab = null;

    //Ammo pool count
    public int SuperPoolSize = 100;

    public Queue<Transform> SuperAmmoQueue = new Queue<Transform>();

    //Array of ammo objects to generate
    private GameObject[] SuperAmmoArray;

    public static SuperAmmoManager SuperAmmoManagerSingleton = null;

    void Awake()
    {
        if (SuperAmmoManagerSingleton != null)
        {
            Destroy(GetComponent<SuperAmmoManager>());
            return;
        }

        SuperAmmoManagerSingleton = this;
        SuperAmmoArray = new GameObject[SuperPoolSize];

        for (int i = 0; i < SuperPoolSize; i++)
        {
            SuperAmmoArray[i] = Instantiate(SuperAmmoPrefab, Vector3.zero, Quaternion.identity) as GameObject;
            Transform ObjTransform = SuperAmmoArray[i].GetComponent<Transform>();
            ObjTransform.parent = GetComponent<Transform>();
            SuperAmmoQueue.Enqueue(ObjTransform);
            SuperAmmoArray[i].SetActive(false);
        }
    }

    public static Transform SuperSpawnAmmo (Vector3 Position, Quaternion Rotation)
    {
        //Get ammo
        Transform SuperSpawnedAmmo = SuperAmmoManagerSingleton.SuperAmmoQueue.Dequeue();

        SuperSpawnedAmmo.gameObject.SetActive(true);
        SuperSpawnedAmmo.position = Position;
        SuperSpawnedAmmo.localRotation = Rotation;

        //Add to queue end
        SuperAmmoManagerSingleton.SuperAmmoQueue.Enqueue(SuperSpawnedAmmo);

        //Return ammo
        return SuperSpawnedAmmo;
    }

}
