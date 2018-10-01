using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawScript : MonoBehaviour {

    public float maxMoveDistance = 10;
    //Set this to your objects initial position when game starts.
    Vector3 origin;
    public Vector3 offset;
    public float speed = 10;
    Vector3 destination;
   

    bool Up;

    public bool rotate;

    //Refrence to GameManager
    GameObject gamemanager;

	// Use this for initialization
	void Start () {
        gamemanager = GameObject.Find("GameManager");
        origin = transform.position;
        destination = origin + offset;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 0, -5);
        if (transform.position == origin)
		{
            Up = true;

        }
        else if (transform.position == destination)
        {
            Up = false;

        }
        if (Up == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        }
        if (Up == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, origin, speed * Time.deltaTime);
        }
	}

    //Respawn player on collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gamemanager.GetComponent<GameManager>().Respawnbutton(true);
        }
    }
}
