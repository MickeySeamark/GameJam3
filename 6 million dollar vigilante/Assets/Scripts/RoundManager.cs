using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Room
{
    // all the enemies in this room
    public List<Enemy> lstEnemy;

    // if all the enemies in this room are dead
}

public class RoundManager : MonoBehaviour
{
    public static bool bAllEnemiesDead;
    // decalring a array of rooms
    public List<Room> lstRoom;
    // room count for designers
    public int nRoomCount = 0;
    // the current round
    [HideInInspector]
    public static int nCurrRound = 0;
    // tracking how many died in each round
    public static int nHowManyDead = 0;
    // game over
    public static bool bGameOver = false;


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
                    bAllEnemiesDead = false;

                    lstRoom[i].lstEnemy = new List<Enemy>();

                    for (int j = 0; j < transform.GetChild(i).transform.childCount; ++j)
                    {
                        lstRoom[i].lstEnemy.Add(transform.GetChild(i).transform.GetChild(j).GetComponent<Enemy>());
                    }
                }
                //Debug.Log("Room/s found.");
            }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(nCurrRound);

        nHowManyDead = 0;

        if (nCurrRound < lstRoom.Count)
        {
            if (lstRoom[nCurrRound].lstEnemy[0].name == "skip")
                bAllEnemiesDead = true;

            // if all the enemies in this room have died, set bAllEnemiesDead to true for that round
            for (int i = 0; i < lstRoom[nCurrRound].lstEnemy.Count; ++i)
            {
                if (!lstRoom[nCurrRound].lstEnemy[i].bAlive)
                    ++nHowManyDead;
                
                if (nHowManyDead == lstRoom[nCurrRound].lstEnemy.Count)
                    bAllEnemiesDead = true;
            }
        }

        if (nCurrRound == lstRoom.Count)
            Debug.Log("GameOver");

    }
}

