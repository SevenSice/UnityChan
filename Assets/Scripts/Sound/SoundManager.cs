using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public AudioSource bgm;
    public AudioSource se;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlaySE(AudioClip au)
    {
        se.PlayOneShot(au);
    }

    void PlayBGM(AudioClip au)
    {
        bgm.PlayOneShot(au);
    }
}
