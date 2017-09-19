using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ReGood : MonoBehaviour {

	public int good = 0;
	private float delay;
	public float time;

	public int Count {
        set {
            good = value;
			// 値を更新
            this.GetComponent<Text> ().text = "Good      :" + good.ToString ();
        }
        get {
            return good;
        }
    }
	void Start () {
		delay = GameObject.Find("Next").GetComponent<ResultMove>().delay + GameObject.Find("Next").GetComponent<ResultMove>().time + 0.5f;
		this.GetComponent<Text> ().text = "Good      :" + good;
		// 移動後増加させる
		Invoke("CountUp",delay);
	}


	void CountUp() {
		DOTween.To( () => Count,  (n) => Count = n, ScoreCounter.good, time);
	}	
}
