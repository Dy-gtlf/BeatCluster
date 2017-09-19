using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PressS : MonoBehaviour {

	private AudioSource title;
	private ScoreCounter scoreCounter;

	public GameObject fadeout;
	public GameObject fadein;

	public float ffSpeed;
	private float red, blue, green, alpha;

	void Start(){
		title = gameObject.GetComponent<AudioSource> ();
		title.clip = Resources.Load ("SEs/Title") as AudioClip;
		Instantiate (fadein);

		red = GetComponent<Text>().color.r;
		blue = GetComponent<Text>().color.b;
		green = GetComponent<Text>().color.g;
		alpha = GetComponent<Text>().color.a;
	}

	void Update () {
		// シーン移動
		if (Input.GetKeyDown (KeyCode.Space)) {
			AudioSource.PlayClipAtPoint (title.clip, new Vector3 (0f, 0f, 0f), 0.5f);
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
