﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
 
    //GroundCheck
    public Transform GroundCheck;
    public float groundCheckRadius = 0.3f;
    public bool grounded = true;
    private int maskSol = 1 << 8;

    //Mouvement
    private float hAxes;
    public float runSpeed = 5;
    public float jumpForce = 5;
    public int jumpCounter;
    private bool isJumping;

    //Facing
    public bool facingRight = true;
    private Vector3 Scalex;

    //Component
    private Rigidbody2D rb2d;

    //Explosion
    public GameObject explosionRadius;

    //Jump Mario
    //private float miniForce;
    //public float diminutionMiniForce = 3f;
    //private bool stoppedJumping;



    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.A)) {
            Instantiate(explosionRadius, transform.position, Quaternion.identity);
        }

        hAxes = Input.GetAxis("Horizontal");
        //grounded = Physics2D.OverlapCircle(GroundCheck.position, groundCheckRadius, maskSol);
        if (grounded) {
            jumpCounter = 2;
        }

        //Mouvement
        FlipFunction();
        Move();
        JumpFunction();
        
    }
    private void FixedUpdate()
    {
        //Move();
        //FlipFunction();
    }

    void Move() {
        rb2d.velocity = new Vector2(hAxes * runSpeed, rb2d.velocity.y);
    }

    void JumpFunction() {
        if (Input.GetKeyDown(KeyCode.Space) && (grounded || jumpCounter > 0))
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
            jumpCounter--;
            //miniForce = jumpForce;
            //stoppedJumping = false;
        }
        /*if (Input.GetKey(KeyCode.Space) && !stoppedJumping && miniForce>0) {
            rb2d.velocity = new Vector2(rb2d.velocity.x, miniForce);
            miniForce -= diminutionMiniForce * Time.deltaTime;
        }
        
        if (Input.GetKeyUp(KeyCode.Space)) {
            stoppedJumping = true;
        }
        */
    }

    void FlipFunction() {
        if ((hAxes < 0 && facingRight) || (hAxes > 0 && !facingRight))
        {
            facingRight = !facingRight;

            Scalex = transform.localScale;
            Scalex.x *= -1;

            transform.localScale = Scalex;

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(GroundCheck.position, groundCheckRadius);
    }
}
