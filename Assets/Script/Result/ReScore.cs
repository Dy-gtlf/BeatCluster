using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ReScore : MonoBehaviour {


	public int score = 0;
	private float delay;
	public float time;

	private AudioSource ctSE;

	private float timer = 0;

	public int Count {
        set {
            score = value;
			// 値を更新
            this.GetComponent<Text> ().text = "Score:" + score.ToString ();
        }
        get {
            return score;
        }
    }

	void Start () {
		ctSE = GetComponent<AudioSource>();
		delay = GameObject.Find("Next").GetComponent<ResultMove>().delay + GameObject.Find("Next").GetComponent<ResultMove>().time + 0.5f;
		this.GetComponent<Text> ().text = "Score:" + score;
		// 移動後増加させる
		Invoke("CountUp",delay);
	}

	void Update() {
		timer += Time.deltaTime;
		if ( delay <= timer && timer <= delay + time ) {
			ctSE.PlayOneShot(ctSE.clip, 0.1f);
		}
	}

	void CountUp() {
		DOTween.To( () => Count,  (n) => Count = n, ScoreCounter.score, time);
	}		
}
