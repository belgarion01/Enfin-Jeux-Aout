using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PGuide : MonoBehaviour {

    public Camera mycam;
    public Transform Player;

    private Vector2 mousepos;
    public Vector2 dir;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        mousepos = mycam.ScreenToWorldPoint((Vector2)Input.mousePosition);
        dir = (mousepos - (Vector2)Player.position).normalized;
        dir = new Vector2(Mathf.Clamp(dir.x, -1f, 1f), Mathf.Clamp(dir.y, 0.25f, 1f));
        transform.position = (Vector2)Player.position+dir;

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, 0.5f);
    }
}
