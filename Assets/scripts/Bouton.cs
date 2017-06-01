using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    bool paused = false;
	// Update is called once per frame
	public void pause () {
        if (paused == false)
        {
            print("Paused");
            Time.timeScale = 0.0f;
            paused = true;
        }
        else
        {
            print("Unpaused");
            Time.timeScale = 1.0f;
            paused = false;
        }
    }
}
