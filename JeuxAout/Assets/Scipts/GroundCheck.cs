using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {


    private PlayerController pController;
    private Animator anim;

	void Start () {
        pController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        anim = GetComponentInParent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Sol") || collision.gameObject.layer == LayerMask.NameToLayer("Cube"))
        {
            pController.grounded = true;
            Debug.Log("caca");
            anim.SetBool("Grounded", true);
        }
    }
}
