using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {

    public PrenableScript prenableScript;

    public GameObject Debris;

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
            for (int i = 0; i < 5; i++)
            {
                Instantiate(Debris, collision.transform.position + (Vector3)(Random.insideUnitCircle), Quaternion.identity);
            }
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Missile"))
        {
            if (this.gameObject == prenableScript.objetPris)
            {
                prenableScript.objetPris = null;
            }
            Destroy(collision.gameObject);
            for (int i = 0; i < 5; i++)
            {
                Instantiate(Debris, collision.transform.position + (Vector3)(Random.insideUnitCircle), Quaternion.identity);
            }
            Destroy(this.gameObject);
        }
    }
}
