using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {


    // Access to the shoot script
    private GameObject shoot;

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



	}
}
