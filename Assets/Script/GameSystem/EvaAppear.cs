using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvaAppear : MonoBehaviour {

	Renderer rd = new Renderer(); 
	float timer = 0;

	void Start(){
		rd = GetComponent<Renderer> ();
		rd.enabled = false;
	}

	void Update () {
		if (rd.enabled == true) {
			timer += Time.deltaTime;
			if (timer >= 1f) {
				rd.enabled = false;
				timer = 0;
			}
		}
	}
}
