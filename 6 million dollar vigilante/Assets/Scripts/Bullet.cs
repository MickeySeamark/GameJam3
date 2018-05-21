using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private int bounceCount;

    // Use this for initialization
    void Awake()
    {
        bounceCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(bounceCount);

        if(bounceCount > 3)
        {
            gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        bounceCount++;
    }
}
