using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    float timer = 60f;
    GameObject p;

	// Use this for initialization
	void Start () {
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
    }
}
