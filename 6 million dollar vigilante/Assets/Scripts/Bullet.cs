using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int bounceCount;

    public static int scoreOnBullet;

    public int Enemy1Score;
    public int Enemy2Score;
    public int Enemy3Score;



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

        if (collision.gameObject.tag == "Enemy")
        {
            if (collision.gameObject.GetComponent<Enemy>().bAlive && collision.gameObject.GetComponent<Enemy>().playerNumber == 1)
            {
                scoreOnBullet += Enemy1Score;
            }
            if (collision.gameObject.GetComponent<Enemy>().bAlive && collision.gameObject.GetComponent<Enemy>().playerNumber == 2)
            {
                scoreOnBullet += Enemy2Score;
            }
            if (collision.gameObject.GetComponent<Enemy>().bAlive && collision.gameObject.GetComponent<Enemy>().playerNumber == 3)
            {
                scoreOnBullet += Enemy3Score;
            }
        }
        //if (collision.gameObject.tag == "Enemy2")
        //{
        //    scoreOnBullet += Enemy2Score;
        //}

        //if (collision.gameObject.tag == "Enemy3")
        //{
        //    scoreOnBullet += Enemy3Score;
        //}
    }

    private void ResetValues()
    {
        gameObject.GetComponent<CapsuleCollider>().isTrigger = false;
    }
}
