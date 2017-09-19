using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneEffect : MonoBehaviour {
	Renderer effect = new Renderer();
	public int laneNum; // レーン番号


	void Start () {
		effect = this.gameObject.GetComponent<Renderer> ();
		effect.enabled = false;
	}

	void Update () {
		switch (laneNum) {
		case 0:
			CheckInput (KeyCode.S);
			break;
		case 1:
			CheckInput (KeyCode.D);
			break;
		case 2:
			CheckInput (KeyCode.F);
			break;
		case 3:
			CheckInput (KeyCode.G);
			break;
		case 4:
			CheckInput (KeyCode.H);
			break;
		case 5:
			CheckInput (KeyCode.J);
			break;
		case 6:
			CheckInput (KeyCode.K);
			break;
		case 7:
			CheckInput (KeyCode.L);
			break;
		}
	}

	void CheckInput(KeyCode key) { // 押している間エフェクト表示
		if (Input.GetKey (key)) {
			effect.enabled = true;
		} else {
			effect.enabled = false;
		}

	}

}
