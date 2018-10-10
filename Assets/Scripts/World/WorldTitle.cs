using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldTitle : World {

    public GameObject btns;
    public GameObject anyKeyText;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.anyKey)
        {
            btns.SetActive(true);
            anyKeyText.SetActive(false);
        }
    }
}
