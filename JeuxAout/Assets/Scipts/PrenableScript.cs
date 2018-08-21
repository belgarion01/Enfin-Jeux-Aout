using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrenableScript : MonoBehaviour {

    public bool isHolding = false;

    public GameObject objetPris;
    private Rigidbody2D orb2d;

    public Transform prenableGuide;

    public bool canHold;

	void Start () {
		
	}
	
	void Update () {
        if (isHolding) {
            objetPris.transform.position = prenableGuide.position;
            if (Input.GetKeyDown(KeyCode.E)) {
                orb2d.gravityScale = 1f;
                objetPris.GetComponent<BoxCollider2D>().enabled = true;
                isHolding = false;
            }
        }
        if (canHold && Input.GetKeyDown(KeyCode.E)) {
            isHolding = true;
            canHold = false;
            objetPris.GetComponent<BoxCollider2D>().enabled = false;
            orb2d = objetPris.GetComponent<Rigidbody2D>();
            orb2d.gravityScale = 0f;
            orb2d.angularVelocity = 0f;
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Prenable") && !isHolding) {
            Debug.Log("prouta");

        }
            if (collision.gameObject.CompareTag("Prenable")&&!isHolding) {
            objetPris = collision.gameObject;
            canHold = true;
        }
    }

}
