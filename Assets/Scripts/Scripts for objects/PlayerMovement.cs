using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public CharacterController2D controller;
    public Animator anim;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (GameManager.mobilecontrolls == false) {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        }


        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            anim.SetTrigger("Jump");
        }
        
    }
    public void onPress(float btn)
    {
        horizontalMove = btn;
    }

    public void onRelease()
    {
        horizontalMove = 0;
    }

    public void Jump()
    {
        jump = true;
        anim.SetTrigger("Jump");
    }

    private void LateUpdate()
    {
        anim.SetBool("Grounded", controller.m_Grounded);
        if (horizontalMove != 0f) { anim.SetBool("Running", true); } else { anim.SetBool("Running", false); }
    }

    void FixedUpdate()
    {
        // move player
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    } 
}
