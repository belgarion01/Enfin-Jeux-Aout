using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrenableScript : MonoBehaviour {

    public bool isHolding = false;

    public GameObject objetPris;
    private Rigidbody2D orb2d;

    public List<GameObject> ListePrenables;
    public Transform prenableGuide;

    public bool canHold;

    private float distance = 0f;
    private float distancemin = 100f;

	void Start () {
		
	}
	
	void Update () {

        if (isHolding)
        {
            objetPris.transform.position = prenableGuide.position;
            if (Input.GetKeyDown(KeyCode.E))
            {
                orb2d.gravityScale = 1f;
                objetPris.GetComponent<BoxCollider2D>().enabled = true;
                isHolding = false;
                objetPris = null;
                distancemin = 100f;
            }
        }
        if (canHold && Input.GetKeyDown(KeyCode.E)) {
            if (ListePrenables.Count == 0)
            {
                canHold = false;
            }
            else if (ListePrenables.Count > 0)
            {
                foreach (GameObject pren in ListePrenables)
                {
                    distance = (transform.position - pren.transform.position).magnitude;
                    if (distance < distancemin)
                    {
                        distancemin = distance;
                        objetPris = pren;
                    }
                }
                isHolding = true;
                canHold = false;
                objetPris.GetComponent<BoxCollider2D>().enabled = false;
                orb2d = objetPris.GetComponent<Rigidbody2D>();
                orb2d.gravityScale = 0f;
                orb2d.angularVelocity = 0f;
            }
            
        }
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Prenable") && !isHolding&& !ListePrenables.Contains(collision.gameObject))
        {
            ListePrenables.Add(collision.gameObject);
            //objetPris = collision.gameObject;
            canHold = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (ListePrenables.Contains(collision.gameObject)) {
            ListePrenables.Remove(collision.gameObject);
        }
        canHold = false;    
    }

}
