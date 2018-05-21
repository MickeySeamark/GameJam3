using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    // temp, waiting for object pool.
    [Tooltip("Temporary until object pool is in.")]
    public GameObject bullet;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKey(KeyCode.Mouse0))
        {
            
        }
	}
}
