using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    //Quaternion rosPos = new Quaternion(0, 0, 0, 0);
    //Quaternion deadPos = new Quaternion(90.0f, 0, 0, 90.0f);
    
    public bool bAlive = true;
    //
    public int playerNumber;

    // Use this for initialization
    void Start ()
    {
        gameObject.tag = "Enemy";
        //gameObject.GetComponent<BoxCollider>().
        //transform.rotation = deadPos;
    }

    // Update is called once per frame
    void Update ()
    {
        //if (bAlive)
        //{
        //    transform.rotation = rosPos;
        //    gameObject.tag = "Enemy";
        //}
        //if(!bAlive)
        //{
        //    gameObject.tag = "DeadEnemy";
        //}

    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Bullet" && bAlive)
        {
            bAlive = false;
            gameObject.tag = "DeadEnemy";
            col.GetComponent<Rigidbody>().useGravity = true;

            Vector3 rotateAxis = transform.right;
            Quaternion rotator = Quaternion.AngleAxis(90.0f, rotateAxis);

            transform.rotation = rotator * transform.rotation;

            //transform.rotation = rosPos;
        }
    }

}
