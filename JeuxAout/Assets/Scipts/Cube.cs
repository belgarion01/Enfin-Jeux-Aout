using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {

    public PrenableScript prenableScript;

    public GameObject Debris;
    public GameObject Loots;

    public int nombreDebris = 4;
    public int nombreLoots = 3;

    void Start () {
        prenableScript = GameObject.FindGameObjectWithTag("PrenableScript").GetComponent<PrenableScript>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Missile"))
        {
            Destroy(collision.gameObject);
            Death();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Missile"))
        {
            Death();
            Destroy(collision.gameObject);
        }
    }
    public void Death() {
        if (this.gameObject == prenableScript.objetPris)
        {
            prenableScript.objetPris = null;
        }
        if (this.gameObject.CompareTag("Prenable"))
        {
            for (int i = 0; i < nombreDebris; i++)
            {
                Instantiate(Debris, transform.position + (Vector3)(Random.insideUnitCircle), Quaternion.identity);
                Debug.Log("&");
            }
        }
        if (this.gameObject.CompareTag("PrenableOr")){
            if (this.gameObject == prenableScript.objetPris)
            {
                prenableScript.objetPris = null;
            }

            for (int i = 0; i < nombreDebris; i++)
            {
                Instantiate(Debris, transform.position + (Vector3)(Random.insideUnitCircle), Quaternion.identity);
            }
            for (int i = 0; i < nombreLoots; i++)
            {
                Instantiate(Loots, transform.position + (Vector3)(Random.insideUnitCircle), Quaternion.identity);
            }
        }
        Destroy(this.gameObject);
    }
}
