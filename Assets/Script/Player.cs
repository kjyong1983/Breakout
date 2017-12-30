using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float x;

    int power = 1;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        gameObject.transform.position = new Vector3(x, gameObject.transform.position.y);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            Destroy(gameObject);
            GameObject.FindObjectOfType<GameManager>().isRunning = false;
        }
    }
}
