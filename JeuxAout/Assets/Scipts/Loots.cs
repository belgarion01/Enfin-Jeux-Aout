using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loots : MonoBehaviour {

    private SceneManagerScript scManager;

	void Start () {
        scManager = GameObject.FindGameObjectWithTag("scManager").GetComponent<SceneManagerScript>();
        StartCoroutine(IgnoreCollision(1f));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator IgnoreCollision(float t) {
        Physics2D.IgnoreCollision(GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider2D>(), this.GetComponent<BoxCollider2D>(), true);
        yield return new WaitForSeconds(t);
        Physics2D.IgnoreCollision(GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider2D>(), this.GetComponent<BoxCollider2D>(), false);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            scManager.fuelCount += 0.625f;
            Destroy(this.gameObject);
        }
    }
}
