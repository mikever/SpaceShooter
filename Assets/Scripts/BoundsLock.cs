using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsLock : MonoBehaviour {
    //-------------------
    private Transform ThisTransform = null;
    public Vector2 HorzRange = Vector2.zero;
    public Vector2 VertRange = Vector2.zero;
    //-------------------
    // Use this for initialization
    void Awake()
    {
        ThisTransform = GetComponent<Transform>();
    }
    //-------------------
    // Update is called once per frame
    void LateUpdate()
    {
        //Clamp poition
        ThisTransform.position = new Vector3(Mathf.Clamp
            (ThisTransform.position.x, HorzRange.x, HorzRange.y),
            ThisTransform.position.y,
            Mathf.Clamp(ThisTransform.position.z, VertRange.x,
            VertRange.y));
    }
    //-------------------
}
//-------------------