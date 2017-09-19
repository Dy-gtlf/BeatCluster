using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MusicName : MonoBehaviour {

	public GameObject list;
	private MusicNameList musicNameList;
	public int listNum;
	private int pos;
	public static string selected;
	public GameObject fadeout;
	public GameObject fadein;
	public string viewing;


	void Awake () {
		selected = "Empty";
		musicNameList = list.GetComponent<MusicNameList> ();
		pos = listNum;
		if (listNum == 0) {
			Instantiate (fadein);
			viewing = musicNameList.musicList [pos];
		}
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
		if (listNum == 0) {
			viewing = musicNameList.musicList [pos];
		}
		if (listNum == 0 && Input.GetKeyDown (KeyCode.Return)) {
			selected = musicNameList.musicList [pos];
			StartCoroutine ("GoToNextScene");
		}

	}

	IEnumerator GoToNextScene(){
		if (MusicName.selected != "Empty") {
			Instantiate (fadeout);
			yield return new WaitForSeconds (2f);
			SceneManager.LoadScene ("GamePlay");
		}
	}

}
