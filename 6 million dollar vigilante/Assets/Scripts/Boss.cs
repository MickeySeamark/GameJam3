using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int BossHealth;
    //public bool isBigBoss;
    private bool bAlive;
    // Use this for initialization
    void Start()
    {
        bAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (BossHealth <= 0)
            bAlive = false;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet"
            )
        {
            BossHealth--;
        }
    }
}
