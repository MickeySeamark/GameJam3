using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Camera MainCamera;

    public LayerMask layerMask;



    // Shoot speed
    public float shootSpeed = 100;

    private Transform shootLocation;

    // Access to the shoot script
    private GameObject shoot;

    // Whether the player is out of ammo or not.
    private bool outOfAmmo;

    // shotCount
    private int shotCount;

    // Use this for initialization
    void Start()
    {
        layerMask = ~(LayerMask.NameToLayer("Enemy"));
    }

    // Update is called once per frame
    void Update()
    {
        // Checks amount of ammo to see whether
        // they have any ammo left to shoot.
        AmmoAmountCheck();

        // Raycast to screen
        RayCheck();

        // Shoot function
        Shoot();


        // Magnetic Pull(Reload)
        MagneticPull();
    }


    //--------------------------------------------
    // functions
    //--------------------------------------------

    /*
        Shoot, it shoots a bullet at the mouse's pos.
    */
    void Shoot()
    {

        // Rootin' Tootin' Shootin' 
        if (Input.GetKeyDown(KeyCode.Mouse0) && !outOfAmmo && ObjectPool.m_SharedInstance.ObjectsAvailable() <= ObjectPool.m_SharedInstance.m_nAmountToPool)
        {
            // Get access to the bullet in the object pool.
            GameObject copy = ObjectPool.m_SharedInstance.GetPooledObject();

            // Set the spawn point of the bullet at the players arm position.
            copy.transform.position = transform.position + transform.forward + (transform.up * 0.6f) * 1;

            // Get the snowballs rigidbody
            Rigidbody rb = copy.GetComponent<Rigidbody>();

            copy.transform.LookAt(shootLocation);

            // Apply a 'shooting' force to the bullet.
            rb.AddForce(copy.transform.forward * shootSpeed, ForceMode.Impulse);

            //// Tell the animator the bullet is finished being shot.
            //m_Animator.SetBool("shooting", false);

            shotCount++;
        }
    }

    /* 
        Magnetic pull the bullets back to the player
        This is the same as reloading.
     */
    void MagneticPull()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            shotCount = 0;
        }
    }

    /*
        Ammo Amount Check
    */
    void AmmoAmountCheck()
    {
        if (shotCount > 6)
        {
            outOfAmmo = true;
        }
    }

    void RayCheck()
    {
        RaycastHit hit; // Information on what a raycast hits
        Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition); // Ray to use when raycasting

        if (Input.GetKeyDown(KeyCode.Mouse0)) // Checks if left mouse button is pressed
        {
            if (Physics.Raycast(ray, out hit, 1000.0f, layerMask)) // Sends raycast and checks if anything is hit
            {
                Transform objectHit = hit.transform; // Stores the hit object
                //objectHit.GetComponent<Rigidbody>().AddForce(0, 0, 200.0f); // Applies a force to the object hit
                shootLocation = hit.transform;
            }
        }
        Debug.Log(Input.mousePosition);
    }

    void BulletMassToHeavy()
    {
        // Invoke after 2.5 seconds, mass gets set to 1.

        // 
    }
}
