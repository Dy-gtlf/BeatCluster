using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

	private AudioSource audioSource;
	public float musicLength;

	void Start () {
		GameObject gm = GameObject.Find ("GameManager");
		GameManager gms = gm.GetComponent<GameManager> ();
		audioSource = gameObject.GetComponent<AudioSource> ();
		audioSource.clip = Resources.Load ("BGMs/" + gms.musicName) as AudioClip;
		musicLength = audioSource.clip.length;
		audioSource.Play ();
	}

}
