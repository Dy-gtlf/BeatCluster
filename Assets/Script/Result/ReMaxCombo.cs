using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ReMaxCombo : MonoBehaviour {

	public int combo = 0;
	private float delay = 0;
	public float time;

	public int Count {
        set {
            combo = value;
			// 値を更新
            this.GetComponent<Text> ().text = "Max Combo:" + combo.ToString ();
        }
        get {
            return combo;
        }
    }

	void Start () {
		delay = GameObject.Find("Next").GetComponent<ResultMove>().delay + GameObject.Find("Next").GetComponent<ResultMove>().time + 0.5f;
		this.GetComponent<Text> ().text = "Max Combo:" + combo;
		// 移動後増加させる
		Invoke("CountUp",delay);
	}

	void CountUp() {
		if ( ScoreCounter.miss == 0 && ScoreCounter.bad == 0 ) {
			DOTween.To( () => Count,  (n) => Count = n, ScoreCounter.perfect + ScoreCounter.good + ScoreCounter.nice, time);
		} else {
				DOTween.To( () => Count,  (n) => Count = n, ScoreCounter.maxCombo, time);
		}
	}
}
