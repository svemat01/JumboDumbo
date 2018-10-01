using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Clips")]
    public AudioClip a_default;
    public AudioClip a_completed;
    public AudioClip a_fail;
    AudioSource audiodata;


    // Start is called before the first frame update
    void Start()
    {
        
        audiodata = GetComponent<AudioSource>();
        audiodata.volume = PlayerPrefs.GetFloat("volume");
        play("default", true);
    }

    // Update is called once per frame
    public void play(string clipv, bool loop)
    {
        audiodata.Stop();

        if (clipv == "default") { audiodata.clip = a_default; }
        else if (clipv == "fail") { audiodata.clip = a_fail; }
        else if (clipv == "complete") { audiodata.clip = a_completed; }

        audiodata.loop = loop;

        audiodata.Play(0);
    }

    public void playpause(bool pause) {
        if (pause == true) { audiodata.Pause(); } else if (pause == false) { audiodata.UnPause(); }
    }
}