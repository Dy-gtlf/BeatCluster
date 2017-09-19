using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class Next : MonoBehaviour {

	private AudioSource result;
	private ScoreCounter scoreCounter;
	public GameObject fadeout;
	public GameObject fadein;

	public float ffSpeed;
	private float red, blue, green, alpha;

	void Start(){
		result = gameObject.GetComponent<AudioSource> ();
		result.clip = Resources.Load ("SEs/decision") as AudioClip;
		Instantiate (fadein);

		red = GetComponent<Text>().color.r;
		blue = GetComponent<Text>().color.b;
		green = GetComponent<Text>().color.g;
		alpha = GetComponent<Text>().color.a;
	}

	void Update () {
		// シーン移動
		if (Input.GetKeyDown (KeyCode.Space)) {
			AudioSource.PlayClipAtPoint (result.clip, new Vector3 (0f, 0f, 0f), 1f);
			Instantiate(fadeout);
			StartCoroutine ("GoToNextScene");
		}

		// 点滅
		alpha += ffSpeed;
		GetComponent<Text>().color = new Color(red,blue,green,alpha);
		if ( alpha > 1 ) {
			ffSpeed *= -1;
		} else if ( alpha < 0 ) {
			ffSpeed *= -1;
		}

	}

	IEnumerator GoToNextScene(){
		yield return new WaitForSeconds (1.5f);
		SceneManager.LoadScene ("SongSelect");
	}

}
