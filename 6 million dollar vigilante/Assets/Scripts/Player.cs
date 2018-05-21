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

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
       

		if(outOfAmmo)
        {
            // Can't shoot
            // Display text saying out of ammo.
        }

        // Rootin' Tootin' Shootin' 
        if (Input.GetKeyDown(KeyCode.Mouse0) && !outOfAmmo)
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
        }

    }
}
