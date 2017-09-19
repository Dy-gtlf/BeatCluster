using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalNoteMove : MonoBehaviour {

	public int laneNum;	// レーン番号
	private float timer = 0; // 生成からの時間
	public GameObject hitEffect; // ヒットエフェクト
	private AudioSource audioSource;
	private ScoreCounter scoreCounter;
	private int speed;

	void Awake(){
		GameObject gm = GameObject.Find ("GameManager");
		GameManager gms = gm.GetComponent<GameManager> ();
		speed = gms.speed;
	}

	void Start(){
		scoreCounter = GameObject.Find ("ScoreCounter").GetComponent<ScoreCounter> ();
		audioSource = gameObject.GetComponent<AudioSource> ();
		audioSource.clip = Resources.Load ("SEs/Hit") as AudioClip;
	}
		

	void Update () {
		this.transform.position += new Vector3 (0, 0, Time.deltaTime * -10 * speed);
		timer += Time.deltaTime;
		// 時間による判定 1.5sでjudgeLine
		// perfect判定
		if (1.46f <= timer && timer <= 1.54f) {
			switch (laneNum) {
			case 0:
				if (Input.GetKeyDown (KeyCode.S) || Input.GetKeyDown (KeyCode.D)) {
					scoreCounter.addPerfect ();
					Hit ();
				}
				break;
			case 2:
				if (Input.GetKeyDown (KeyCode.F) || Input.GetKeyDown (KeyCode.G)) {
					scoreCounter.addPerfect ();
					Hit ();
				}
				break;
			case 4:
				if (Input.GetKeyDown (KeyCode.H) || Input.GetKeyDown (KeyCode.J)) {
					scoreCounter.addPerfect ();
					Hit ();
				}
				break;
			case 6:
				if (Input.GetKeyDown (KeyCode.K) || Input.GetKeyDown (KeyCode.L)) {
					scoreCounter.addPerfect ();
					Hit ();
				}
				break;
			}
				
		}
		// good判定
		if ( (1.44f <= timer && timer < 1.46f) || (1.54f < timer && timer <= 1.56f) ) {
			switch (laneNum) {
			case 0:
				if (Input.GetKeyDown (KeyCode.S) || Input.GetKeyDown (KeyCode.D)) {
					scoreCounter.addGood ();
					Hit ();
				}
				break;
			case 2:
				if (Input.GetKeyDown (KeyCode.F) || Input.GetKeyDown (KeyCode.G)) {
					scoreCounter.addGood ();
					Hit ();
				}
				break;
			case 4:
				if (Input.GetKeyDown (KeyCode.H) || Input.GetKeyDown (KeyCode.J)) {
					scoreCounter.addGood ();
					Hit ();
				}
				break;
			case 6:
				if (Input.GetKeyDown (KeyCode.K) || Input.GetKeyDown (KeyCode.L)) {
					scoreCounter.addGood ();
					Hit ();
				}
				break;
			}

		}
		// nice判定
		if ( (1.42f <= timer && timer < 1.44f) || (1.56f < timer && timer <= 1.58f) ) {
			switch (laneNum) {
			case 0:
				if (Input.GetKeyDown (KeyCode.S) || Input.GetKeyDown (KeyCode.D)) {
					scoreCounter.addNice ();
					Hit ();
				}
				break;
			case 2:
				if (Input.GetKeyDown (KeyCode.F) || Input.GetKeyDown (KeyCode.G)) {
					scoreCounter.addNice ();
					Hit ();
				}
				break;
			case 4:
				if (Input.GetKeyDown (KeyCode.H) || Input.GetKeyDown (KeyCode.J)) {
					scoreCounter.addNice ();
					Hit ();
				}
				break;
			case 6:
				if (Input.GetKeyDown (KeyCode.K) || Input.GetKeyDown (KeyCode.L)) {
					scoreCounter.addNice ();
					Hit ();
				}
				break;
			}

		}
		// bad判定
		if ( (1.4f <= timer && timer < 1.42f) || (1.58f < timer && timer <= 1.6f) ) {
			switch (laneNum) {
			case 0:
				if (Input.GetKeyDown (KeyCode.S) || Input.GetKeyDown (KeyCode.D)) {
					scoreCounter.addBad ();
					Hit ();
				}
				break;
			case 2:
				if (Input.GetKeyDown (KeyCode.F) || Input.GetKeyDown (KeyCode.G)) {
					scoreCounter.addBad ();
					Hit ();
				}
				break;
			case 4:
				if (Input.GetKeyDown (KeyCode.H) || Input.GetKeyDown (KeyCode.J)) {
					scoreCounter.addBad ();
					Hit ();
				}
				break;
			case 6:
				if (Input.GetKeyDown (KeyCode.K) || Input.GetKeyDown (KeyCode.L)) {
					scoreCounter.addBad ();
					Hit ();
				}
				break;
			}

		}

		// miss判定
		if (timer > 1.62f ) {
			scoreCounter.addmiss ();
			Destroy (this.gameObject);
		}
			
	}

	// カメラ外で削除
	//void OnBecameInvisible () {
	//	scoreCounter.addmiss ();
	//	this.gameObject.SetActive (false);
	//	Destroy (this.gameObject);
	//}

	// ヒット処理
	void Hit(){
		Instantiate (hitEffect, this.transform.position, Quaternion.identity);
		AudioSource.PlayClipAtPoint (audioSource.clip, new Vector3 (0f, 0f, -75f), 1f);
		Destroy (this.gameObject);
	}

}
