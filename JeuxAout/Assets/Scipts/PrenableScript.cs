using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrenableScript : MonoBehaviour {

    //State
    public bool isHolding = false;
    //Quel objet prendre
    public List<GameObject> ListePrenables;
    public GameObject objetPris;
    private Rigidbody2D orb2d;
    //Comparateur
    private float distance = 0f;
    private float distancemin = 100f;
    //Ou va aller l'objet
    public Transform prenableGuide;

    void Start () {
		
	}
	
	void Update () {

        //(Attention c'est la 2ème partie du code)
        //Si le joueur porte qqchose
        if (isHolding)
        {
            //Met l'objet qu'il porte devant lui
            objetPris.transform.position = prenableGuide.position;
            //Si il appuie sur E, il reset les propriétés physique de l'objet et se remet en mode "ne porte rien"
            if (Input.GetKeyDown(KeyCode.E))
            {
                orb2d.gravityScale = 1f;
                objetPris.GetComponent<BoxCollider2D>().enabled = true;
                isHolding = false;
                //Reset aussi ce qui permet de déterminer quel objet prendre
                objetPris = null;
                distancemin = 100f;
            }
        }
        //Si il ne porte rien et quil appuie sur E
        if (Input.GetKeyDown(KeyCode.E)&&!isHolding) {
            //Il vérifie si la liste des objets prenables et vide
            if (ListePrenables.Count == 0)
            {
                return;
            }
            //Si elle est remplie, il détermine l'objet le plus proche et le mets dans la variable objetPris qui est repris en haut
            else if (ListePrenables.Count > 0)
            {
                foreach (GameObject pren in ListePrenables)
                {
                    distance = (transform.position - pren.transform.position).magnitude;
                    if (distance < distancemin)
                    {
                        distancemin = distance;
                        objetPris = pren;
                    }
                }
                //De plus, on enlève les propriétés physiques de l'objets et on met le joueur en mode "porte qqchose"
                isHolding = true;
                objetPris.GetComponent<BoxCollider2D>().enabled = false;
                orb2d = objetPris.GetComponent<Rigidbody2D>();
                orb2d.gravityScale = 0f;
                orb2d.angularVelocity = 0f;
            }
        }
    }

    //Met dans une liste les objets à porter
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Prenable") && !isHolding&& !ListePrenables.Contains(collision.gameObject))
        {
            ListePrenables.Add(collision.gameObject);
        }
    }

    //Enlève les objets de la liste qui sortent de la portée
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (ListePrenables.Contains(collision.gameObject)) {
            ListePrenables.Remove(collision.gameObject);
        } 
    }

}
