using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuM : MonoBehaviour {

    public Transform cam;

    public void PlayGame() {
        SceneManager.LoadScene("lancer");
    }

    public void Control() {
        cam.position = new Vector3(10f, 0f, -10f);
    }

    public void Credit()
    {
        cam.position = new Vector3(-10f, 0f, -10f);
    }

    public void MainMenu()
    {
        cam.position = new Vector3(0f, 0f, -10f);
    }

    public void Quit() {
        Application.Quit();
    }

}
