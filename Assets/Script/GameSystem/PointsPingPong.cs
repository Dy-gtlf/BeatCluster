using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsPingPong : MonoBehaviour {

	public float T;
	public float height;

	void Update () {
		transform.position = new Vector3(transform.position.x, height * Mathf.Sin (Time.frameCount * T ),transform.position.z);
	}
}
