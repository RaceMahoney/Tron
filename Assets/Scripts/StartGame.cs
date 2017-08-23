using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class StartGame : MonoBehaviour {

    public Text start;

	// Use this for initialization
	void Start () {
        start.enabled = true;
        Time.timeScale = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKey)
        {
            start.enabled = false;
            Time.timeScale = 1;
        }
	}
}
