using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loots : MonoBehaviour {

    private SceneManagerScript scManager;

	void Start () {
        scManager = GameObject.FindGameObjectWithTag("scManager").GetComponent<SceneManagerScript>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            scManager.fuelCount++;
            Destroy(this.gameObject);
        }
    }
}
