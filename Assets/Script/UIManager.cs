using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Text score;
    int scoreVal;

	// Use this for initialization
	void Start () {
        score.text = "0";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //public void AddScore(int val)
    //{
    //    scoreVal += val;
    //    score.text = scoreVal.ToString();
    //}
}
