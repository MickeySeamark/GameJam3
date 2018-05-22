using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Room
{
    // all the enemies in this room
    public List<GameObject> lstEnemy;

    // if all the enemies in this room are dead
    public bool bAllEnemiesDead;
}

public class RoundManager : MonoBehaviour
{
    // decalring a array of rooms
    public List<Room> lstRoom;
    // room count for designers
    public int nRoomCount = 0;


    // Use this for initialization
    void Start()
    {
        // new list of rooms
        lstRoom = new List<Room>();

        // if it can find go round manager then assign it if not debug log that it cannot
        if (name == "RoundManager")
            if (GetComponentInChildren<Transform>())
            {
                // making the number of rooms specified
                for (int i = 0; i < transform.childCount; ++i)
                {
                    lstRoom.Add(new Room());
                    lstRoom[i].bAllEnemiesDead = false;

                    lstRoom[i].lstEnemy = new List<GameObject>();

                    for (int j = 0; j < transform.GetChild(i).transform.childCount; ++j)
                    {
                        lstRoom[i].lstEnemy.Add(transform.GetChild(i).transform.GetChild(j).gameObject);
                    }
                }

                Debug.Log("Room/s found.");
            }
            else
            {
                Debug.LogError("The round mananaget does not have any rooms!?!?! Silly designers!.");
                EditorApplication.isPlaying = false;
            }
        else
        {
            Debug.LogError("Please spell the round mamanger as \"RoundManager\"!?!?! Silly designers!.");
            EditorApplication.isPlaying = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
