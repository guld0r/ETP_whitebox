using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jeu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public void jouer(int sceneIndex) { 
        Application.LoadLevel(sceneIndex);
	}
}
