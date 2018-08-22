using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour {

    public Text GameOver;

    public Slider Fueler;
    public int fuelCount = 0;

	void Start () {
		
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        Fueler.value = fuelCount;
	}

    public void PlayerKilled() {
        GameOver.gameObject.SetActive(true);
    }
}
