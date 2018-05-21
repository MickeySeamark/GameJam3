using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {


    // Access to the shoot script
    private GameObject shoot;

    // Shoot speed
    public float shootSpeed = 100;

    // Whether the player is out of ammo or not.
    private bool outOfAmmo;

    // shotCount
    private int shotCount;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (shotCount > 6)
        {
            outOfAmmo = true;
        }

        // Rootin' Tootin' Shootin' 
        if (Input.GetKeyDown(KeyCode.Mouse0) && !outOfAmmo && ObjectPool.m_SharedInstance.ObjectsAvailable() <= ObjectPool.m_SharedInstance.m_nAmountToPool)
        {
            // Get access to the bullet in the object pool.
            GameObject copy = ObjectPool.m_SharedInstance.GetPooledObject();
            
            // Set the spawn point of the bullet at the players arm position.
            copy.transform.position = transform.position + transform.forward + (transform.up * 0.6f) * 1;

            // Get the snowballs rigidbody
            Rigidbody rb = copy.GetComponent<Rigidbody>();

            // Apply a 'shooting' force to the bullet.
            rb.AddForce(transform.forward * shootSpeed, ForceMode.Impulse);

            //// Tell the animator the bullet is finished being shot.
            //m_Animator.SetBool("shooting", false);

            shotCount++;
        }

        if(Input.GetKeyDown(KeyCode.R))
        {

        }

    }

    void MagneticPull()
    {
        shotCount = 0;
    }
}
