using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTManager : MonoBehaviour {

    public GameObject Missiles;
    public float spawnRate = 5f;
    public float beginTime = 2f;

	void Start () {
        InvokeRepeating("SpawnMissile", beginTime, spawnRate);
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    void SpawnMissile()
    {

        Instantiate(Missiles, new Vector2(Random.Range(transform.position.x-11f, transform.position.x+ 11f), transform.position.y), Quaternion.identity);

    }
}
