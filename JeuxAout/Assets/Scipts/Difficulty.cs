using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Difficulty : MonoBehaviour {

	public static bool hardMode;
    public Animator difficultyAnim;

    private void Start()
    {
        DontDestroyOnLoad(this);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K)) {
            SceneManager.LoadScene("lancer");
        }
    }

    public void ChangeDifficulty() {
        hardMode = !hardMode;
        difficultyAnim.SetBool("Difficulty", hardMode);
    }
}
