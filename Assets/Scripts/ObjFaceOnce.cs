using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjFaceOnce : MonoBehaviour
{
    //----------------
    public Transform ObjToFollow = null;
    public bool FollowPlayer = false;
    private Transform ThisTransform = null;
    //----------------
    // Use this for initialization
    void Awake()
    {
        //Get local transform
        ThisTransform = GetComponent<Transform>();

        //Should face player?
        if (!FollowPlayer) return;

        //Get Player Transform
        GameObject PlayerObj =
            GameObject.FindGameObjectWithTag("Player");
        if (PlayerObj != null)
            ObjToFollow = PlayerObj.GetComponent<Transform>();

        //Follow destination object
        if (ObjToFollow == null) return;

        //Get direction to follow object
        Vector3 DirToObject = ObjToFollow.position -
            ThisTransform.position;

        if (DirToObject != Vector3.zero)
        {
            ThisTransform.localRotation = Quaternion.LookRotation
                (DirToObject.normalized, Vector3.up);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
