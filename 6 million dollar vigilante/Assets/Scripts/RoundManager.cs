﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Room
{
    // all the enemies in this room
    public List<Enemy> lstEnemy;

    // if all the enemies in this room are dead
    public bool bAllEnemiesDead;
}

public class RoundManager : MonoBehaviour
{
    // decalring a array of rooms
    public List<Room> lstRoom;
    // room count for designers
    public int nRoomCount = 0;
    // the current round
    private int nCurrRound = 0;

    // Use this for initialization
    void Start()
    {
        // new list of rooms
        lstRoom = new List<Room>();

        // if it can find go round manager then assign it if not debug log that it cannot
        if (name == "RoundManager")
            if (GetComponentInChildren<Transform>() && transform.GetChild(0).name.Contains("Room"))
            {
                // making the number of rooms specified
                for (int i = 0; i < transform.childCount; ++i)
                {
                    lstRoom.Add(new Room());
                    lstRoom[i].bAllEnemiesDead = false;

                    lstRoom[i].lstEnemy = new List<Enemy>();

                    for (int j = 0; j < transform.GetChild(i).transform.childCount; ++j)
                    {
                        lstRoom[i].lstEnemy.Add(transform.GetChild(i).transform.GetChild(j).GetComponent<Enemy>());
                    }
                }
                Debug.Log("Room/s found.");
            }
            else
            {
                for (int i = 0; i < 100; ++i)
                    Debug.LogError("The round mananaget does not have any rooms, please name them \"Room1, Room2 etc...\"!?!?! Silly designers!.");
                EditorApplication.isPlaying = false;
            }
        else
        {
            for (int i = 0; i < 100; ++i)
                Debug.LogError("Please spell the round mamanger as \"RoundManager\"!?!?! Silly designers!.");
            EditorApplication.isPlaying = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            int nHowManyDead = 0;

            // if all the enemies in this room have died, set bAllEnemiesDead to true for that round
            for (int i = 0; i < lstRoom[nCurrRound].lstEnemy.Count; ++i)
            {
                if (!lstRoom[nCurrRound].lstEnemy[i].bAlive)
                    ++nHowManyDead;

                if (nHowManyDead == lstRoom[nCurrRound].lstEnemy.Count)
                    lstRoom[nCurrRound].bAllEnemiesDead = true;
            }

            if (lstRoom[nCurrRound].bAllEnemiesDead)
            {
                ++nCurrRound;
            }


        }
    }
}

