using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private bool stoppedJumping;
    public Transform GroundCheck;

    public float groundCheckRadius = 0.3f;

    private float hAxes;
    public float runSpeed = 5;
    public float jumpForce = 5;
    private bool grounded = true;
    private int maskSol = 1 << 8;

    public bool facingRight = true;
    private Vector3 Scalex;

    private Rigidbody2D rb2d;

    private float miniForce;
    public float diminutionMiniForce = 3f;



	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
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
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
            miniForce = jumpForce;
            stoppedJumping = false;
        }
        if (Input.GetKey(KeyCode.Space) && !stoppedJumping && miniForce>0) {
            rb2d.velocity = new Vector2(rb2d.velocity.x, miniForce);
            miniForce -= diminutionMiniForce * Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.Space)) {
            stoppedJumping = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(GroundCheck.position, groundCheckRadius);
    }
}
