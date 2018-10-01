using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikescript : MonoBehaviour {


    //Refrence to GameManager
    GameObject gamemanager;

	// Use this for initialization
	void Start () {
        gamemanager = GameObject.Find("GameManager");
	}
	
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gamemanager.GetComponent<GameManager>().Respawnbutton(true);
        }
    }
}
