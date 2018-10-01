using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumboDialogTrigger : MonoBehaviour {

    public Animator animator;
    public DialogManager diaman;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.SetBool("IsNear", true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.SetBool("IsNear", false);
        }
    }

    private void Update()
    {
        if (diaman.IsTalking == true)
        {
            animator.SetBool("IsNear", false);
        }
    }
}
