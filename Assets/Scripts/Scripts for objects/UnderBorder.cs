using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderBorder : MonoBehaviour {

    //Refrence to GameManager
    public GameObject gamemanager;

    // Use this for initialization
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gamemanager.GetComponent<GameManager>().Respawnbutton(true);
        }
    }
}