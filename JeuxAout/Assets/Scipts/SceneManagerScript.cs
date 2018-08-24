using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour {

    public Text GameOver;
    public Text Victoire;

    public Slider Fueler;
    public int fuelCount = 0;

    public Slider But;
    public int butCount;


	void Start () {
		
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        Fueler.value = fuelCount;
        But.value = butCount;

        if (butCount >= 5) {
            Victoire.gameObject.SetActive(true);
        }

	}

    public void PlayerKilled() {
        GameOver.gameObject.SetActive(true);
    }
}
