using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int bounceCount;

    private Player player = new Player();
    // Use this for initialization
    void Awake()
    {
        bounceCount = 0;

        //gameObject.GetComponent<Rigidbody>().useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(bounceCount);

        if (Input.GetKeyDown(KeyCode.R))
        {
            bounceCount = 0;
            gameObject.GetComponent<CapsuleCollider>().isTrigger = true;
            Invoke("ResetValues", player.GetReloadDuration());
        }
        

        if(bounceCount > 3)
        {
            gameObject.GetComponent<Rigidbody>().useGravity = true;
        }

        else
        {
            gameObject.GetComponent<Rigidbody>().useGravity = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        bounceCount++;
    }

    private void ResetValues()
    {
        gameObject.GetComponent<CapsuleCollider>().isTrigger = false;
    }
}
