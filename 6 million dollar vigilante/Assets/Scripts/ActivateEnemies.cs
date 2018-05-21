using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateEnemies : MonoBehaviour {

    public List<GameObject> enemies = new List<GameObject>(); 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < enemies.Capacity; i++)
        {
            enemies[i].GetComponent<EnemyTrigger>().isActive = true;
        }
    }
}
