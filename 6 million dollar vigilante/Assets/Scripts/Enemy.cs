using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    Quaternion rosPos = new Quaternion(0, 0, 0, 0);
    Quaternion deadPos = new Quaternion(90.0f, 0, 0, 90.0f);
    
    public bool bAlive = true;

    public int playerNumber;

    // Use this for initialization
    void Start ()
    {
        transform.rotation = deadPos;
    }

    // Update is called once per frame
    void Update ()
    {
        if (bAlive)
        {
            transform.rotation = rosPos;
            gameObject.tag = "Enemy";
        }
        if(!bAlive)
        {
            gameObject.tag = "DeadEnemy";
        }

    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            bAlive = false;
            transform.rotation = deadPos;
        }

        if (col.tag == ("Bullet"))
        {
            col.GetComponent<Rigidbody>().useGravity = true;
        }
    }

}
