using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Missiles : MonoBehaviour {

    private Rigidbody2D rb2d;

    public float speed; 
    public float depart;

    public bool isSlow = false;
    public float slowNumber = 1f;
    public float slowPower = 0.2f;

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
        if (isSlow)
        {
            slowNumber = slowPower;
        }
        else {
            slowNumber = 1f;
        }


        rb2d.velocity = new Vector2(speed * depart*slowNumber, rb2d.velocity.y);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")){
            Destroy(collision.gameObject);
            scManager.PlayerKilled();
        }
    }
}
