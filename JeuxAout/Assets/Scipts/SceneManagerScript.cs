using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour {

    public GameObject GameOver;
    //public Text Victoire;

    public Image Fueler;
    public float fuelCount = 0;

    public Slider But;
    public int butCount;

    public GameObject[] Debris;
    public GameObject Boite;

    public Animator shipAnim;

	void Start () {
        SpawnDebris();
        FindObjectOfType<AudioManager>().Play("MainMusic");
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        fuelCount = Mathf.Clamp(fuelCount, 0f, 1f);
        Fueler.fillAmount = fuelCount;

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
        StartCoroutine(GameOverIE());
    }

    IEnumerator GameOverIE() {
        GameOver.SetActive(true);
        FindObjectOfType<AudioManager>().Play("GameOver");
        FindObjectOfType<AudioManager>().Stop("MainMusic");
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(0);
    }

    void Swap(GameObject[]array, int first, int second) {
        GameObject temp = array[first];
        array[first] = array[second];
        array[second] = temp;
    }

    IEnumerator Decollage() {
        yield return new WaitForSeconds(1f);
        shipAnim.SetTrigger("Decollage");
        FindObjectOfType<AudioManager>().Play("Decollage");
    }

    public void FFinish() {
        StartCoroutine(Decollage());
    }


}
