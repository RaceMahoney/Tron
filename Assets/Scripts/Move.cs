using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Move : MonoBehaviour {

    //keys
    public KeyCode upKey;
    public KeyCode downKey;
    public KeyCode rightKey;
    public KeyCode leftKey;
    public KeyCode shift;

    //audio
    public AudioSource audio;

    //speed
    public int speed = 16;
    public float boostCooldown = 5f;
    public float boostDuration = 0.75f;
 
    private bool hasCooldown;
    private Vector2 lastDirection = Vector2.up; //default direction

  
    //light wall prefab
    public GameObject wallPrefab;
    //current wall
    Collider2D wall;
    //last wall's end
    Vector2 lastWallEnd;
    //rigidbody
    private Rigidbody2D rb;


    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();

        //inital velocity
        rb.velocity = Vector2.up * speed;
        SpwanWall();

    
    }
	
	// Update is called once per frame
	void Update () {
        //check for keys pressed
        if (Input.GetKeyDown(upKey))
        {
            audio.pitch = Random.Range(0.6f, .9f);
            audio.Play();
            rb.velocity = Vector2.up * speed;
            SpwanWall();

            lastDirection = Vector2.up;
        }
        else if (Input.GetKeyDown(downKey))
        {
            audio.pitch = Random.Range(0.6f, .9f);
            audio.Play();
            rb.velocity = -Vector2.up * speed;
            SpwanWall();

            lastDirection = -Vector2.up;
        }
        else if (Input.GetKeyDown(rightKey))
        {
            audio.pitch = Random.Range(0.6f, .9f);
            audio.Play();
            rb.velocity = Vector2.right * speed;
            SpwanWall();

            lastDirection = Vector2.right;
        }
        else if (Input.GetKeyDown(leftKey))
        {
            audio.pitch = Random.Range(0.6f, .9f);
            audio.Play();
            rb.velocity = -Vector2.right * speed;
            SpwanWall();

            lastDirection = -Vector2.right;
        }
        else if (Input.GetKeyDown(shift) && !hasCooldown)
        {
            speed = 50;
            rb.velocity = lastDirection * speed;

            StartCoroutine(ActivateCooldown());
            StartCoroutine(ResetMovementVector());
            SpwanWall();
        }

        fitColliderBetween(wall, lastWallEnd, transform.position);
    } //update

    IEnumerator ActivateCooldown()
    {
        // put some code to disable the boost-is-ready bar
        // diable the ability to use boost
        hasCooldown = true;
        // wait until the boost is ready again
        yield return new WaitForSeconds(boostCooldown);
        // make the boost usable
        hasCooldown = false;
       
        // put some code to enable the boost-is-ready bar
    }

    IEnumerator ResetMovementVector()
    {
        // wait some seconds
        yield return new WaitForSeconds(boostDuration);
        // return to normal speed
        speed = 16;
    }

    void SpwanWall()
    {
        //save last walls function
        lastWallEnd = transform.position;

        //spwan a new light wall
        GameObject gameobject = (GameObject)Instantiate(wallPrefab, transform.position, Quaternion.identity);
        wall = gameobject.GetComponent<Collider2D>();
    } //spqanwall

    void fitColliderBetween(Collider2D col, Vector2 alpha, Vector2 beta)
    {
        //calculate the center position
        col.transform.position = alpha + (beta - alpha) * 0.5f;

        //scale wall
        float dist = Vector2.Distance(alpha, beta);
        if (alpha.x != beta.x)
            col.transform.localScale = new Vector2(dist + 1, 1);
        else
            col.transform.localScale = new Vector2(1, dist + 1);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col != wall)
        {
           // print("player " + this.gameObject.name + " lost");
            Destroy(gameObject);
        }
    }

   
}
