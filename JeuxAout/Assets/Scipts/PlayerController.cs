using System.Collections;
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

    //SceneManager
    private SceneManagerScript scManager;

    //FixeingBug
    public Collider2D[] col;

    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        scManager = GameObject.FindGameObjectWithTag("scManager").GetComponent<SceneManagerScript>();
        col = this.gameObject.GetComponents<Collider2D>();
        foreach (Collider2D truc in col) {
            Debug.Log(truc.name);
        }


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
            grounded = false;
            Debug.Log(grounded);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Missile")){
            Debug.Log(collision.gameObject);
            Destroy(collision.gameObject);
            scManager.PlayerKilled();
            Destroy(this.gameObject);
        }
    }
}
