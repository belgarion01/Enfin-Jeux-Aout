using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vomissement : MonoBehaviour {

    private SceneManagerScript scManager;


    public Transform vomissementPoint;

    public GameObject Fuel;

    private float countDown = 0;
    private float countDownReset = 0.2f;

	void Start () {
        scManager = GameObject.FindGameObjectWithTag("scManager").GetComponent<SceneManagerScript>();
	}
	
	
	void Update () {
        if (countDown >= 0) {
            countDown -= Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.F)&&countDown<=0&&scManager.fuelCount>0) {
            Instantiate(Fuel, vomissementPoint.position, Quaternion.identity);
            scManager.fuelCount--;
            countDown = countDownReset;
        }
	}
}
