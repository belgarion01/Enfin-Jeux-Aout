using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float jumpTime;
    private float jumpTimeCounter;
    private bool stoppedJumping;
    public Transform GroundCheck;

    private float groundCheckRadius = 0.3f;

    private float hAxes;
    public float runSpeed = 5;
    public float jumpForce = 5;
    private bool grounded = true;
    //private LayerMask maskSol = 8;
    private int maskSol = 1 << 8;

    public bool facingRight = true;
    private Vector3 Scalex;

    private Rigidbody2D rb2d;


	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(facingRight);

        hAxes = Input.GetAxis("Horizontal");
        grounded = Physics2D.OverlapCircle(GroundCheck.position, groundCheckRadius, maskSol);

        if ((hAxes < 0 && facingRight) || (hAxes > 0 && !facingRight)){
            facingRight = !facingRight;

            Scalex = transform.localScale;
            Scalex.x *= -1;

            transform.localScale = Scalex;
            
        }

        Move();
        JumpFunction();
        
    }

    void Move() {
        rb2d.velocity = new Vector2(hAxes * runSpeed, rb2d.velocity.y);
    }

    void JumpFunction() {
        // jumpTime*5 = jumpForce
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
            jumpTimeCounter = jumpTime;
            stoppedJumping = false;
        }
        if (Input.GetKey(KeyCode.Space) && !stoppedJumping && jumpTimeCounter >= 0) {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
            jumpTimeCounter -= Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.Space)) {
            jumpTimeCounter = 0;
            stoppedJumping = true;
        }
    }

}
