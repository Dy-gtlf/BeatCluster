using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicNameRear : MonoBehaviour {

	public GameObject list;
	private MusicNameList musicNameList;
	public int listNum;
	private int pos;


	void Start () {
		musicNameList = list.GetComponent<MusicNameList> ();
		pos = musicNameList.len - listNum - 1;
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			pos++;
		}
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			pos--;
		}

		if (pos > musicNameList.len - 1) {
			pos = 0;
		} else if (pos < 0) {
			pos = musicNameList.len - 1;
		}

		GetComponent<Text> ().text = musicNameList.musicList [pos];

	}

}
