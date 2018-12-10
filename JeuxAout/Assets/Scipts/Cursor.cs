using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour {

    public List<SpriteRenderer> childSprites;
    public Sprite Open;
    public Sprite Close;

	void Start () {
        foreach (Transform child in transform) {
            childSprites.Add(child.GetComponent<SpriteRenderer>());
            Debug.Log("hein ?");

        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)){
            foreach (SpriteRenderer sprite in childSprites) {
                Debug.Log("hein ?");
                sprite.sprite = Close;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            foreach (SpriteRenderer sprite in childSprites)
            {
                sprite.sprite = Open;
            }
        }

    }
}
