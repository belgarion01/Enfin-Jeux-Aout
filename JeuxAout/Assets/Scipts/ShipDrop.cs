﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDrop : MonoBehaviour {

    private SceneManagerScript scManager;

	void Start () {
        scManager = GameObject.FindGameObjectWithTag("scManager").GetComponent<SceneManagerScript>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Loot")) {
            scManager.butCount++;
            Destroy(collision.gameObject);
        }
    }
}
