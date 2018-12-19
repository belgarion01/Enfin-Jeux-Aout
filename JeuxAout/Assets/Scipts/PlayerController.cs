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
    public float jumpForce = 7;
    public int jumpCounter;
    private bool isJumping;

    public bool canMove = true;


    //Facing
    public bool facingRight = true;
    private Vector3 Scalex;

    private Vector2 PlayertoMouse;

    //Component
    private Rigidbody2D rb2d;

    //Explosion
    public GameObject explosionRadius;

    public GameObject Curseur;
    public Vector2 curseurOffset;

    //God Mod
    public bool isGodmod = false;
    public Camera mycam;
    private Vector3 mousepos;
    private Vector3 screenpos;
    private LayerMask lMask = 1 << 8;
    private bool isGrabing = false;
    private GameObject grabed;

    //SceneManager
    private SceneManagerScript scManager;

    //Animation
    private Animator anim;

    public bool canRepair = false;

    private PrenableScript pScript;

    public float repairSpeed;

    private bool lookingRight = true;

    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        scManager = GameObject.FindGameObjectWithTag("scManager").GetComponent<SceneManagerScript>();
        anim = GetComponent<Animator>();
        pScript = FindObjectOfType<PrenableScript>();
        Curseur.SetActive(false);
    }
	
	void Update () {

        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
        anim.SetFloat("VelocityY", rb2d.velocity.y);
        anim.SetInteger("JumpCounter", jumpCounter);
        //anim.SetBool("isGodMod", isGodmod);

        if (Input.GetKey(KeyCode.E) && !pScript.isHolding)
        {
            Debug.Log("isrepairing");
            anim.SetBool("isRepairing", true);
            canMove = false;
            isGodmod = false;
            if (scManager.fuelCount < 5)
            {
                scManager.fuelCount += repairSpeed;
            }
        }
        else {
            anim.SetBool("isRepairing", false);
        }
        if (Input.GetKeyUp(KeyCode.E)) {
            canMove = true;
        }

        if (Input.GetKeyDown(KeyCode.A)&&!pScript.isHolding&&!isGodmod) {
            anim.SetBool("isExploding", true);
            Instantiate(explosionRadius, transform.position, Quaternion.identity);
            canMove = false;
            rb2d.velocity = Vector3.zero;
        }
        if (Input.GetKeyUp(KeyCode.A)&&!pScript.isHolding){
            canMove = true;
            anim.SetBool("isExploding", false);
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
        if (isGodmod)
        {
            anim.SetBool("withoutHand", true);
            Curseur.SetActive(true);
            Vector2 tempMousePos = mycam.ScreenToWorldPoint(Input.mousePosition);
            Curseur.transform.position = tempMousePos;
            if (Input.GetMouseButtonDown(0) && !isGrabing)
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
            if (isGrabing)
            {
                Vector3 pos = mycam.ScreenToWorldPoint(Input.mousePosition);
                pos.z = 0;
                grabed.transform.position = pos;
                if (Input.GetMouseButtonUp(0))
                {
                    isGrabing = false;
                    grabed.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                }
            }
        }
        else {
            Curseur.SetActive(false);
        }
    }

    void Move() {
        rb2d.velocity = new Vector2(hAxes * runSpeed, rb2d.velocity.y);
    }

    void JumpFunction() {
        if (Input.GetKeyDown(KeyCode.Space) && (grounded || jumpCounter > 0))
        {
            if (jumpCounter == 2)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
            }
            else {
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce+1);
            }
            jumpCounter--;
            grounded = false;
            
            anim.SetBool("Grounded", false);
        }
    }

    void FlipFunction() {
        /*if ((hAxes < 0 && facingRight) || (hAxes > 0 && !facingRight))
        {
            facingRight = !facingRight;

            Scalex = transform.localScale;
            Scalex.x *= -1;

            transform.localScale = Scalex;

        }*/
        mousepos = Input.mousePosition;
        mousepos.z = 10f;
        screenpos = mycam.ScreenToWorldPoint(mousepos);

        PlayertoMouse = (Vector2)(screenpos - transform.position);
        if (PlayertoMouse.x <= 0&&lookingRight)
        {
            //transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
            foreach (Transform child in transform) {
                child.transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
            }
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else {
            //transform.localScale = Vector3.one;
            GetComponent<SpriteRenderer>().flipX = false;
            foreach (Transform child in transform)
            {
                child.transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
            }
        }

    }

    public IEnumerator PowerUp() {
        isGodmod = true;
        yield return new WaitForSeconds(5f);
        isGodmod = false;
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

    /*IEnumerator CalculateDirection() {
        Vector3 lastPosition = transform.position;
        yield return Vector3.zero;
    }*/
}
