using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




public class GameManager : MonoBehaviour {

    // Public Variables
    [Header("Variables")]
    public GameObject player;
    public GameObject gameover;
    public GameObject levelcomplete;
    public GameObject pausemenu;
    public Animator sceneanim;
    public AudioManager audiomanager;
    public GameObject controlls;
    public static bool mobilecontrolls;


    [Header("Respawn Position")]
    public Vector3 RespawnPosition;

    [Header("Level")]
    public int levelNumber;

    // Private Variables

    bool pausewin;

    


    // Use this for initialization
    void Start () {
        
        sceneanim.SetBool("open", false);
        PlayerPrefs.SetInt("Level" + "0", 1);
        pausewin = false;
        if (PlayerPrefs.GetInt("mobilecontrolls") == 1) { mobilecontrolls = true; } else { mobilecontrolls = false; }
        controlls.SetActive(mobilecontrolls);
	}

    //toggle buttons
    public void Respawnbutton(bool buttonstoggle)
    {
        //player.GetComponent<CharacterController2D>().enabled = !buttonstoggle;
        if (buttonstoggle == true) {audiomanager.play("fail", false);}

        gameover.SetActive(buttonstoggle);
        player.GetComponent<PlayerMovement>().enabled = !buttonstoggle;
    }

    // Teleport player to start/checkpoint position
    void Respawn () {
        audiomanager.play("default", true);
        levelcomplete.SetActive(false);
        player.transform.position = RespawnPosition;
        Respawnbutton(false);
	}

    // Set Level as compelete when finished
    public void LevelComplete() {
        StartCoroutine(levelcompletescreen());
        PlayerPrefs.SetInt("Level" + levelNumber.ToString(), 1);
        PlayerPrefs.Save();
        PlayerPrefs.GetInt("Level" + levelNumber.ToString());
    }

    // paused
    void pausewindow(bool toggle)
    {
        
        player.GetComponent<PlayerMovement>().enabled = !toggle;
        audiomanager.playpause(toggle);
        pausemenu.SetActive(toggle);
    }

	// every frame
    public void pausebackbutton() { pausewin = false; pausewindow(pausewin); }
	private void Update()
	{
        if (Input.GetKeyDown(KeyCode.Escape)) {
            pausewin = !pausewin;
            pausewindow(pausewin);

        }
	}
	// Load Scene
	public void SceneLoad(int ctl) {
        StartCoroutine(LoadScene(ctl));



    }
    IEnumerator LoadScene(int ctl)
    {
        sceneanim.SetBool("open", true);
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene(ctl);
    }
    IEnumerator levelcompletescreen()
    {
        
        yield return new WaitForSeconds(0.25f);
        audiomanager.play("complete", false);
        levelcomplete.SetActive(true);
        player.GetComponent<PlayerMovement>().enabled = false;
    }
}
