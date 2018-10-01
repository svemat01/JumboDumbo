using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour {

    public Animator anim;
    public GameObject gm;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.SetTrigger("open");
            gm.GetComponent<GameManager>().LevelComplete();
        }
    }
}
