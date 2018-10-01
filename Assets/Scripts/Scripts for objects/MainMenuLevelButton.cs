using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuLevelButton : MonoBehaviour {
    
    [Header("Level")]
    public int levelNumber;

    int completedint;

    public Sprite completed;
    public Sprite ncompleted;

	// Use this for initialization
	private void Start()
	{
        
	}

    public void OnEnable() {
        
        completedint = PlayerPrefs.GetInt("Level" + (levelNumber).ToString());

        if ( completedint == 1)
        {
            GetComponent<Image>().sprite = completed;
            GetComponent<Button>().interactable = true;

        } else {
            GetComponent<Image>().sprite = ncompleted;
            GetComponent<Button>().interactable = false;
        }
	}


	

}
