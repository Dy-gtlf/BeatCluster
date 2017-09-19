using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectSE : MonoBehaviour {

	public AudioSource[] ses;
	public AudioSource select;
	public AudioSource decision;
	public AudioSource back;
	public GameObject selected;
	public GameObject fadeout;

	void Start(){
		ses = gameObject.GetComponents<AudioSource> ();
		select = ses [0];
		decision = ses [1];
		back = ses [2];
		select.clip = Resources.Load ("SEs/Select") as AudioClip;
		decision.clip = Resources.Load ("SEs/Decision") as AudioClip;
		back.clip = Resources.Load ("SEs/Back") as AudioClip;
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.DownArrow)) {
			AudioSource.PlayClipAtPoint (select.clip, new Vector3 (0f, 0f, 0f), 1.5f);
		}
		if (Input.GetKeyDown (KeyCode.Return)) {
			AudioSource.PlayClipAtPoint (decision.clip, new Vector3 (0f, 0f, 0f), 1.5f);
		}
		if (Input.GetKeyDown (KeyCode.Escape)) {
			AudioSource.PlayClipAtPoint (back.clip, new Vector3 (0f, 0f, 0f), 1.5f);
			Instantiate (fadeout);
			StartCoroutine ("GoToNextScene");
		}
	}

	IEnumerator GoToNextScene(){
			yield return new WaitForSeconds (1f);
			SceneManager.LoadScene ("Title");
	}

}
