using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {

    public Text NameText;
    public Text DialogText;

    public Animator animator;
    public bool IsTalking;

    private Queue<string> sentences;

	// Use this for initialization
	void Start () {
        sentences = new Queue<string>();
	}

    // start dialog
    public void StartDialog (Dialog dialog)
    {
        IsTalking = true;
        animator.SetBool("IsOpen", true);

        NameText.text = dialog.name;

        sentences.Clear();
        
        foreach (string sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentance();
        
    }

    // display next Sentence
    public void DisplayNextSentance ()
    {
        if ( sentences.Count == 0)
        {
            EndDialog();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
	{
		DialogText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			DialogText.text += letter;

            yield return null;

        }
	}

    // end dialog
    public void EndDialog ()
    {
        IsTalking = false;
        animator.SetBool("IsOpen", false);
    }

	
}
