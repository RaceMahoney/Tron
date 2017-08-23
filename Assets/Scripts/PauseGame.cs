using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour {

    private bool paused;

	// Use this for initialization
	void Start () {
        paused = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) && paused == false)
        {
            paused = true;
            Time.timeScale = 0;
            
            Debug.Log(paused + "1");
        }
        if (Input.GetKeyDown(KeyCode.Escape) && paused == true)
        {
            paused = false;
            Time.timeScale = 1;
            
            Debug.Log(paused + "2");
        }

    }
}
