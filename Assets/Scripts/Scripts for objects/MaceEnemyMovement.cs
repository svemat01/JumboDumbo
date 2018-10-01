using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaceEnemyMovement : MonoBehaviour {

    public float maxMoveDistance = 10;
    //Set this to your objects initial position when game starts.
    Vector3 origin;
    public Vector3 offset;
    Vector3 destination;
    public float speed = 10;
    public float downspeed;
    bool Up = true;
    int random;

    public bool rotate;

    //Refrence to GameManager
    GameObject gamemanager;


    void Start()
    {
        gamemanager = GameObject.Find("GameManager");
        origin = transform.position;
        Debug.Log(transform.position);
        StartCoroutine(GoDown());
        destination = origin + offset;
    }

    IEnumerator GoDown()
    {
        
        yield return new WaitForSecondsRealtime(1);
        transform.position = Vector3.MoveTowards(transform.position, destination, (speed * downspeed) * Time.deltaTime);

    }

    IEnumerator GoUp()
    {
        random = Random.Range(3, 7);
        Debug.Log(random);
        yield return new WaitForSecondsRealtime(random);
    }

    void Update()
    {
        if (transform.position == origin)
        {
            Up = true;
        } else if (transform.position == destination)
        {
            Up = false;
        }


        if (Up == true)
        {
            StartCoroutine(GoDown());
        }
        if (Up == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, origin, speed * Time.deltaTime);
        }

        if (rotate == true) {
            transform.Rotate(0, 0, -5);
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
