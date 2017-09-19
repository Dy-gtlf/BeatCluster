using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ReBad : MonoBehaviour {

	public int bad = 0;
	private float delay = 0;
	public float time;
		
	public int Count {
        set {
            bad = value;
			// 値を更新
            this.GetComponent<Text> ().text = "Bad        :" + bad.ToString ();
        }
        get {
            return bad;
        }
    }
	void Start () {
		delay = GameObject.Find("Next").GetComponent<ResultMove>().delay + GameObject.Find("Next").GetComponent<ResultMove>().time + 0.5f;
		this.GetComponent<Text> ().text = "Bad        :" + bad;
		// 移動後増加させる
		Invoke("CountUp",delay);
	}


	void CountUp() {
		DOTween.To( () => Count,  (n) => Count = n, ScoreCounter.bad, time);
	}	
}
