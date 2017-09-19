using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugRestart : MonoBehaviour {
	
	void Update () {
		// Rでリスタート
		if (Input.GetKeyDown (KeyCode.R)) {
			SceneManager.LoadScene ("GamePlay");
		}
	}
}
