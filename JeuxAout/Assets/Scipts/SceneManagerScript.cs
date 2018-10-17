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

    public GameObject[] Debris;
    public GameObject Boite;


	void Start () {
        SpawnDebris();
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

    void  SpawnDebris() {
        int count = 0;
        GameObject[] spawners = GameObject.FindGameObjectsWithTag("SpawnerDebris");
        foreach (GameObject spa in spawners)
        {
            int rand1 = Random.Range(0, spawners.Length);
            int rand2 = Random.Range(0, spawners.Length);

            Swap(spawners, rand1, rand2);
        }
        foreach (GameObject spawner in spawners)
        {
            if (count / 5 == 1)
            {
                Instantiate(Boite, spawner.transform.position, Quaternion.identity);
                count = 0;
            }
            else
            {
                Instantiate(Debris[Random.Range(0, 6)], spawner.transform.position, Quaternion.identity);
                count++;
            }
        }
    }

    public void PlayerKilled() {
        GameOver.gameObject.SetActive(true);
    }

    void Swap(GameObject[]array, int first, int second) {
        GameObject temp = array[first];
        array[first] = array[second];
        array[second] = temp;
    }
}
