using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmLineMove : MonoBehaviour {

	int speed;

	void Awake() {
		GameObject gm = GameObject.Find ("GameManager");
		GameManager gms = gm.GetComponent<GameManager> ();
		speed = gms.speed;
	}

	void Update () {
		this.transform.position += new Vector3 (0, 0, Time.deltaTime * -10 * speed);
	}

	void OnBecameInvisible () {
		Destroy (this.gameObject);
	}
}
