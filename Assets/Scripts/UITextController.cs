using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UITextController : MonoBehaviour {

    public Text begin;
    public bool defaultState = true;
    public float interval = 0.5f;
    public float startDelay = 0.5f;
    public bool currentState = true;
    bool isBlinking = false;
    int count = 0;

    public Text player1Win;
    public Text player2Win;

    //public Text P1Boost;
   // public Text P2Boost;



    // Use this for initialization
    void Start () {
       // GameObject thePlayer = GameObject.Find("ThePlayer");
       // Move player = thePlayer.GetComponent<Move>();

        begin.enabled = true;
        player1Win.enabled = false;
        player2Win.enabled = false;

      //  P1Boost.enabled = true;
      //  P2Boost.enabled = true;

        StartBlink();
	}

    public void StartBlink()
    {
        if (isBlinking)
            return;

        if (begin != null)
        {
            isBlinking = true;
            InvokeRepeating("ToggleState", startDelay, interval);
       
        }
    }

    public void ToggleState()
    {
        begin.enabled = !begin.enabled;
        count++;
    }

    // Update is called once per frame
    void Update () {
        if (count == 3)
        {
            CancelInvoke();
            begin.enabled = false;
        }
        if (GameObject.Find("player_1") == null) //player 1 died
        {
            player2Win.enabled = true;
            begin.enabled = false;
            Time.timeScale = 0;
        }
        if (GameObject.Find("player_2") == null) //player 2 died
        {
            player1Win.enabled = true;
            begin.enabled = false;
            Time.timeScale = 0;
        }

        
    }
}
