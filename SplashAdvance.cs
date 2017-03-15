using UnityEngine;
using System.Collections;

public class SplashAdvance : MonoBehaviour {

	private LevelManager lvlManager;

	//gives access to the level manager
	void Start () {
		lvlManager = GameObject.Find ("LevelManager").GetComponent<LevelManager> ();
	}

	//waits for the player to do something before advancing
	void Update () {
		if (Input.anyKeyDown) {
			lvlManager.LoadNextLevel ();
		}
	}
}
