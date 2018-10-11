using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour {

    public SoundManager sound;

    void Awake()
    {
        sound = Object.FindObjectOfType<SoundManager>();
    }
	// Use this for initialization
	void Start () { 
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
