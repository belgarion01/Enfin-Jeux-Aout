using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {

    public PrenableScript prenableScript;

    public GameObject SpawnerDebris;
    public GameObject SpawnerLoot;

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
            Instantiate(SpawnerDebris, transform.position, Quaternion.identity);
        }
        if (this.gameObject.CompareTag("PrenableOr"))
        {
            Instantiate(SpawnerLoot, transform.position, Quaternion.identity);
        }
        Destroy(this.gameObject);
    }
}
