using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    float timer = 60f;
    GameObject p;
    public bool isRunning = false;

	// Use this for initialization
	void Start () {
        Screen.SetResolution(720, 1280, true);

        isRunning = true;
        p = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            var touch = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(touch);

            p.GetComponent<Player>().x = ray.origin.x;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }
}
