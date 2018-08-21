using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour {

    private bool droite = false;

    public float spawnRate = 1f;

    public GameObject[] SpawnersGauche;
    public GameObject[] SpawnersDroite;

    public GameObject Missiles;

    void Start () {
        SpawnersGauche = GameObject.FindGameObjectsWithTag("SGauche");
        SpawnersDroite = GameObject.FindGameObjectsWithTag("SDroite");

        InvokeRepeating("SpawnMissile", 2f, spawnRate);
    }
	
	// Update is called once per frame
	void Update () {

	}

    void SpawnMissile() {
        if (droite)
        {
            Instantiate(Missiles, SpawnersDroite[Random.Range(0, 6)].transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(Missiles, SpawnersGauche[Random.Range(0, 6)].transform.position, Quaternion.identity);
        }
        droite = !droite;
    }
}
