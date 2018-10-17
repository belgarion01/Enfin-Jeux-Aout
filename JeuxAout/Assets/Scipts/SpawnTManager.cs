using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTManager : MonoBehaviour {

    public GameObject Missiles;
    public float spawnRate = 5f;
    public float beginTime = 2f;

    public float rangeSpawn = 5f;

	void Start () {
        InvokeRepeating("SpawnMissile", beginTime, spawnRate);
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    void SpawnMissile()
    {

        Instantiate(Missiles, new Vector2(Random.Range(transform.position.x- rangeSpawn, transform.position.x+ rangeSpawn), transform.position.y), Quaternion.identity);

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere((Vector3)new Vector2(transform.position.x - rangeSpawn, transform.position.y), 0.5f);
        Gizmos.DrawSphere((Vector3)new Vector2(transform.position.x + rangeSpawn, transform.position.y), 0.5f);
    }
}
