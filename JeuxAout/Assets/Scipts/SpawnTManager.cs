using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTManager : MonoBehaviour {

    public GameObject Missiles;
    public float spawnRate;

	void Start () {
        InvokeRepeating("SpawnMissile", 2f, spawnRate);
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    void SpawnMissile()
    {

        Instantiate(Missiles, new Vector2(Random.Range(-11f, 11f), 8f), Quaternion.identity);

    }
}
