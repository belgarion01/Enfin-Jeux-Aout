using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {

    public Vector3 boxDimension;
    public Vector3 offset;
    public Collider2D[] cols;
    public LayerMask lMask;
    public bool gizmos = false;
    private PlayerController pController;
    private SceneManagerScript scManager;
    private Animator anim;

	void Start () {
        scManager = FindObjectOfType<SceneManagerScript>();
        pController = FindObjectOfType<PlayerController>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Physics2D.OverlapBox(transform.position + offset, boxDimension, 0f, lMask))
        {
            pController.canRepair = true;
        }
        else {
            pController.canRepair = false;
        }
        anim.SetFloat("Fuel", scManager.fuelCount);
	}

    private void OnDrawGizmos()
    {
        if (gizmos)
        {
            Gizmos.DrawCube(transform.position + offset, boxDimension);
        }
    }
}
