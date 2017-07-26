using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    private Rigidbody ThisBody = null;
    private Transform ThisTransform = null;

    public bool MouseLook = true;
    public string HorizAxis = "Horizontal";
    public string VertAxis = "Vertical";
    public string FireAxis = "Fire1";

    public float MaxSpeed = 5f;
    public float ReloadDelay = 0.3f;
    public bool CanFire = true;

    public static bool superShot = false;
    public int superCount = 0;

    public Transform[] TurretTransforms;
    public Transform[] SuperTurretTransforms;
    //--------------------------
    // Use this for initialization
    void Awake()
    {
        ThisBody = GetComponent<Rigidbody>();
        ThisTransform = GetComponent<Transform>();
    }

    //--------------------------
    // Update is called once per frame
    void FixedUpdate()
    {
        //Update movement
        float Horz = CrossPlatformInputManager.GetAxis("Horizontal");//Input.GetAxis(HorizAxis);
        float Vert = CrossPlatformInputManager.GetAxis("Vertical");//Input.GetAxis(VertAxis);
        Vector3 MoveDirection = new Vector3(Horz, 0.0f, Vert);
        ThisBody.AddForce(MoveDirection.normalized * MaxSpeed);

        //Clamp Speed
        ThisBody.velocity = new Vector3
            (Mathf.Clamp(ThisBody.velocity.x, -MaxSpeed, MaxSpeed),
            Mathf.Clamp(ThisBody.velocity.y, -MaxSpeed, MaxSpeed),
            Mathf.Clamp(ThisBody.velocity.z, -MaxSpeed, MaxSpeed));

        //Should look with mouse?
        if (MouseLook)
        {
            //Update rotation - turn to face mouse pointer
            //Vector3 MousePosWorld = Camera.main.ScreenToWorldPoint(new
            //Vector3(Input.mousePosition.x,
            //Input.mousePosition.y, 0.0f));
            //MousePosWorld = new Vector3(MousePosWorld.x, 0.0f, MousePosWorld.z);
            //Get direction to cursor
            //Vector3 LookDirection = MousePosWorld - ThisTransform.position;

            // FixedUpdate rotation
            //ThisTransform.localRotation = Quaternion.LookRotation
            //(LookDirection.normalized, Vector3.up);
            ThisTransform.localRotation = Quaternion.LookRotation(MoveDirection.normalized, Vector3.up);
        }

        //Check fire control
        fireWeapon();



    }

    public void fire()
    {

        if (Input.GetButtonDown(FireAxis) && CanFire)
        {
            foreach (Transform T in TurretTransforms)
                AmmoManager.SpawnAmmo(T.position, T.rotation);

            CanFire = false;
            Invoke("EnableFire", ReloadDelay);
        }
    }

    public void fire2()
    {
        if (Input.GetButtonDown(FireAxis) && CanFire)
        {
            foreach (Transform U in SuperTurretTransforms)
                SuperAmmoManager.SuperSpawnAmmo(U.position, U.rotation);

            CanFire = false;
            Invoke("EnableFire", ReloadDelay);
            superCount++;
            if (superCount % 7 == 0)
            {
                superShot = false;
            }
        }
    }

    void EnableFire()
    {
        CanFire = true;
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public void fireWeapon()
    {
        if (superShot == false)
        {
            fire();
        }
        else
        {
            fire2();
        }
    }

}