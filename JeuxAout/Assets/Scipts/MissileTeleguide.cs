using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileTeleguide : MonoBehaviour
{

    private Rigidbody2D rb2d;

    public float speed = 5f;

    private bool isSlow = false;
    private float slowNumber = 1f;
    public float slowPower = 0.2f;

    private Vector2 direction;
    private float rotateAmount;
    public float rotateSpeed = 100f;

    private SceneManagerScript scManager;
    private GameObject player;
    public GameObject Loots;
    public GameObject Debris;

    public PrenableScript prenableScript;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        scManager = GameObject.FindGameObjectWithTag("scManager").GetComponent<SceneManagerScript>();
        player = GameObject.FindGameObjectWithTag("Player");
        prenableScript = FindObjectOfType<PrenableScript>();
        FindObjectOfType<AudioManager>().Play("MissilePcht");
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = -transform.up * speed;
        direction = (player.transform.position - transform.position).normalized;
        rotateAmount = Vector3.Cross(direction, -transform.up).z;
        rb2d.angularVelocity = -rotateAmount * rotateSpeed;

        if (isSlow)
        {
            slowNumber = slowPower;
        }
        else
        {
            slowNumber = 1f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Sol"))
        {
            FindObjectOfType<AudioManager>().Stop("MissilePcht");
            FindObjectOfType<AudioManager>().Play("MissileExplode");
            Destroy(this.gameObject);
        }
    }
}
