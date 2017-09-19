using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class RePerfect : MonoBehaviour {

	public int perfect = 0;
	private float delay = 0;
	public float time;

	public int Count {
        set {
            perfect = value;
			// 値を更新
            this.GetComponent<Text> ().text = "Perfect:" + perfect.ToString ();
        }
        get {
            return perfect;
        }
    }
	void Start () {
		delay = GameObject.Find("Next").GetComponent<ResultMove>().delay + GameObject.Find("Next").GetComponent<ResultMove>().time + 0.5f;
		this.GetComponent<Text> ().text = "Perfect:" + perfect;
		// 移動後増加させる
		Invoke("CountUp",delay);
	}

	void CountUp() {
		DOTween.To( () => Count,  (n) => Count = n, ScoreCounter.perfect, time);
	}	

}
