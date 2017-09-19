using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ReMiss : MonoBehaviour {

	public int miss = 0;
	private float delay = 0;
	public float time;

	public int Count {
        set {
            miss = value;
			// 値を更新
            this.GetComponent<Text> ().text = "Miss       :" + miss.ToString ();
        }
        get {
            return miss;
        }
    }
	void Start () {
		delay = GameObject.Find("Next").GetComponent<ResultMove>().delay + GameObject.Find("Next").GetComponent<ResultMove>().time + 0.5f;
		this.GetComponent<Text> ().text = "Miss       :" + miss;
		// 移動後増加させる
		Invoke("CountUp",delay);
	}


	void CountUp() {
		DOTween.To( () => Count,  (n) => Count = n, ScoreCounter.miss, time);
	}	
}
