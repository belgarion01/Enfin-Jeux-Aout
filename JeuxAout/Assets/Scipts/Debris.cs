using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debris : MonoBehaviour {

    public float countDown = 7f;

    public float dispSpeed = 0.2f;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        countDown -= Time.deltaTime;
        if (countDown <= 0) {
            transform.localScale -= Vector3.one * dispSpeed;
        }
        if (transform.localScale.x <= 0) {
            Destroy(this.gameObject);
        }
	}
}
