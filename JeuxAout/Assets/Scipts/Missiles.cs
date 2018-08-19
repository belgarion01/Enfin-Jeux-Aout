using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Missiles : MonoBehaviour {

    private Rigidbody2D rb2d;

    public float speed; 
    public float depart;

    public SceneManagerScript scManager;

	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        scManager = GameObject.FindGameObjectWithTag("scManager").GetComponent<SceneManagerScript>();
        if (transform.position.x > 0)
        {
            depart = -1;
        }
        else {
            depart = 1;
        }
	}
	
	// Update is called once per frame
	void Update () {
        rb2d.velocity = new Vector2(speed * depart, rb2d.velocity.y);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")){
            Destroy(collision.gameObject);
            scManager.PlayerKilled();
        }
    }
}
