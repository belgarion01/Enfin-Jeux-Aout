using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
 
    //GroundCheck
    public Transform GroundCheck;
    public float groundCheckRadius = 0.3f;
    public bool grounded = true;

    //Mouvement
    private float hAxes;
    public float runSpeed = 5;
    public float jumpForce = 5;
    public int jumpCounter;
    private bool isJumping;

    public bool canMove = true;

    //Facing
    public bool facingRight = true;
    private Vector3 Scalex;

    //Component
    private Rigidbody2D rb2d;

    //Explosion
    public GameObject explosionRadius;

    //God Mod
    public bool isGodmod = true;
    public Camera mycam;
    private Vector3 mousepos;
    private Vector3 screenpos;
    private LayerMask lMask = 1 << 8;
    private bool isGrabing = false;
    private GameObject grabed;

    //SceneManager
    private SceneManagerScript scManager;

    //FixeingBug
    public Collider2D[] col;

    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        scManager = GameObject.FindGameObjectWithTag("scManager").GetComponent<SceneManagerScript>();
        col = this.gameObject.GetComponents<Collider2D>();
        foreach (Collider2D truc in col) {
        }
    }
	
	void Update () {

       


        if (Input.GetKeyDown(KeyCode.A)) {
            Instantiate(explosionRadius, transform.position, Quaternion.identity);
            canMove = false;
        }
        if (Input.GetKeyUp(KeyCode.A)){
            canMove = true;
        }

        hAxes = Input.GetAxis("Horizontal");
        if (grounded) {
            jumpCounter = 2;
        }

        //Mouvement
        FlipFunction();
        if (canMove)
        {
            Move();
            JumpFunction();
        }
        if (isGodmod) {
            if (Input.GetMouseButtonDown(0)&&!isGrabing)
            {
                mousepos = Input.mousePosition;
                mousepos.z = 10f;
                screenpos = mycam.ScreenToWorldPoint(mousepos);

                RaycastHit2D myhit = Physics2D.Raycast(screenpos, Vector2.zero, Mathf.Infinity, lMask);
                if (myhit)
                {
                    isGrabing = true;
                    grabed = myhit.transform.gameObject;
                }
            }
            if (isGrabing) {
                Vector3 pos = mycam.ScreenToWorldPoint(Input.mousePosition);
                pos.z = 0;
                grabed.transform.position = pos;
                if (Input.GetMouseButtonUp(0)) {
                    isGrabing = false;
                }
            }
        }
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
        }
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

    public void PowerUp() {

        Debug.Log("Bouya");
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
