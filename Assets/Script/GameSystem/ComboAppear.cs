using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboAppear : MonoBehaviour {

	Renderer rd = new Renderer();
	public GameObject sc;
	ScoreCounter script = new ScoreCounter();

	void Start () {
		rd = GetComponent<Renderer> ();
		rd.enabled = false;
		script = sc.GetComponent<ScoreCounter>();
	}



	void Update () {
		if (script.combo == 0) {
			rd.enabled = false;
		}
		if (script.combo >= 1) {
			rd.enabled = true;
		}
	}
}
