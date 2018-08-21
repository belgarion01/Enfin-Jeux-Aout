using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileTeleguide : MonoBehaviour
{

    private Rigidbody2D rb2d;

    public float speed = 5f;
    public float depart;

    public bool isSlow = false;
    public float slowNumber = 1f;
    public float slowPower = 0.2f;

    private Vector2 direction;
    private float rotateAmount;
    public float rotateSpeed = 200f;

    public SceneManagerScript scManager;
    public GameObject player;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        scManager = GameObject.FindGameObjectWithTag("scManager").GetComponent<SceneManagerScript>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = transform.right * speed;
        direction = (player.transform.position - transform.position).normalized;
        rotateAmount = Vector3.Cross(direction, transform.right).z;
        rb2d.angularVelocity = -rotateAmount * rotateSpeed;

        if (isSlow)
        {
            slowNumber = slowPower;
        }
        else
        {
            slowNumber = 1f;
        }


        //rb2d.velocity = new Vector2(speed * depart * slowNumber, rb2d.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            scManager.PlayerKilled();
        }
    }
}
