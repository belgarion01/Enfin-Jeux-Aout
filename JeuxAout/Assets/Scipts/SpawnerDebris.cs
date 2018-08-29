﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerDebris : MonoBehaviour {

    public int nombreDebris;
    public float pushSpeed;

    public GameObject[] DebrisList;
    public GameObject Debris;

    private Vector2 dir;
    private Rigidbody2D rb2dD;


	void Start () {
        DebrisList = new GameObject[nombreDebris];
        for (int i = 0; i < nombreDebris; i++)
        {
            DebrisList[i] = Instantiate(Debris, transform.position + (Vector3)(Random.insideUnitCircle), Quaternion.identity);   
        }
        foreach (GameObject debris in DebrisList) {
            rb2dD = debris.GetComponent<Rigidbody2D>();
            dir = (debris.transform.position - transform.position).normalized;
            rb2dD.velocity = dir * pushSpeed;
        }
        Destroy(this.gameObject, 0.2f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
