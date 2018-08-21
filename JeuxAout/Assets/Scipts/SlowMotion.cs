using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotion : MonoBehaviour {

    private Missiles missile;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Missile")){

            missile = collision.gameObject.GetComponent<Missiles>();
            missile.isSlow = true;
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Missile"))
        {
            missile = collision.gameObject.GetComponent<Missiles>();
            missile.isSlow = false;

        }
    }
}
