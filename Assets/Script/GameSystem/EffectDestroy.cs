using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDestroy : MonoBehaviour {

	private float timer = 0; // 生成からの時間

	void Update () {
		timer += Time.deltaTime;
		if (timer >= 1) {
			Destroy (this.gameObject);
			this.gameObject.SetActive (false);
		}
	}
}
