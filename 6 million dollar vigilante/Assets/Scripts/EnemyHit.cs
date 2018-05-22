﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("Bullet"))
        {
            other.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
