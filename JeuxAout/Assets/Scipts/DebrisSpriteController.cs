using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisSpriteController : MonoBehaviour {

    /*public GameObject[] Debris;
    public GameObject Boite;

	void Start () {
        int i = Random.Range(1, 6);
        if (i == 1)
        {
            Instantiate(Boite, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(Debris[Random.Range(0, 6)], transform.position, Quaternion.identity);
        }
	}
    */
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, 0.3f);
    }
}
