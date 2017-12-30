using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

 //   UIManager uiManager;

	//// Use this for initialization
	//void Start () {
 //       uiManager = GameObject.FindObjectOfType<UIManager>();
	//}
	
	//// Update is called once per frame
	//void Update () {
		
	//}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            //uiManager.AddScore(10);
            Destroy(gameObject);
        }
    }

}
