using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float runSpeed;
    public float jumpForce;

    private float hAxes;

    private Rigidbody2D rb2d;


	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        hAxes = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(hAxes * runSpeed, rb2d.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
        }
    }

    private void FixedUpdate()
    {
        
    }
}
