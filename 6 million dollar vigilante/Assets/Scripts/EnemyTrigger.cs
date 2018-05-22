using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyTrigger : MonoBehaviour {

    Quaternion rosPos = new Quaternion(0, 0, 0, 0);
    Quaternion deadPos = new Quaternion(90.0f, 0, 0, 90.0f);
    public bool isActive = false;

	// Use this for initialization
	void Start ()
    {
        transform.rotation = deadPos;
    }
	
	// Update is called once per frame
	void Update ()
    {       
        if (isActive)
        {
            transform.rotation = rosPos;
        }
    }
}
