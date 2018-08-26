using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    public float explosionRadiusSpeed;

    public float countdown;
    public int stade = 3;

    public List<GameObject> ListExplosion;
    private Cube cubeScript;



    void Start () {
        countdown = 1f;
	}
	
	// Update is called once per frame
	void Update () {
        countdown -= Time.deltaTime;

        if (countdown <= 0 && stade > 0)
        {
            transform.localScale += explosionRadiusSpeed * Vector3.one;
            countdown = 1f;
            stade--;
        }
        if (Input.GetKeyUp(KeyCode.A)){
            foreach (GameObject victime in ListExplosion) {
                cubeScript = victime.GetComponent<Cube>();
                cubeScript.Death();
                Destroy(victime.gameObject);
            }
            Destroy(this.gameObject);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Prenable") || collision.gameObject.CompareTag("PrenableOr")){
            ListExplosion.Add(collision.gameObject);
        }
    }

}
