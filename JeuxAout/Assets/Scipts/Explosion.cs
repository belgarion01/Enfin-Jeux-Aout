using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    public float explosionRadiusSpeed;
    private SceneManagerScript scManager;
    public float countdown;
    public int stade = 3;
    public float consummingSpeed;

    public List<GameObject> ListExplosion;
    private Cube cubeScript;

    private bool noMoreFuel = false;
    private Transform player;

    void Start () {
        scManager = FindObjectOfType<SceneManagerScript>();
        if (scManager.fuelCount <= 0) {
            Destroy(gameObject);
        }
        player = GameObject.FindGameObjectWithTag("Player").transform;
        scManager.fuelCount -= 0.2f;
	}
	
	// Update is called once per frame
	void Update () {
        countdown -= Time.deltaTime;
        transform.position = player.position;
        if (scManager.fuelCount <= 0)
        {
            noMoreFuel = true;
        }
        else {
            scManager.fuelCount -= consummingSpeed * Time.deltaTime;

        }
        /*if (countdown <= 0 && stade > 0)
        {
            transform.localScale += explosionRadiusSpeed * Vector3.one;
            countdown = 1f;
            stade--;
        }*/
        if (Input.GetKeyUp(KeyCode.A)||noMoreFuel){
            foreach (GameObject victime in ListExplosion) {
                cubeScript = victime.GetComponent<Cube>();
                cubeScript.Death();
                Destroy(victime.gameObject);
            }
            Destroy(this.gameObject);
        }
        if (scManager.fuelCount > 0 && countdown > 0)
        {
            transform.localScale += Vector3.one * explosionRadiusSpeed * Time.deltaTime;
        }

	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Prenable") || collision.gameObject.CompareTag("PrenableOr")|| collision.gameObject.CompareTag("Missile"))
        {
            ListExplosion.Add(collision.gameObject);
        }
    }

}
