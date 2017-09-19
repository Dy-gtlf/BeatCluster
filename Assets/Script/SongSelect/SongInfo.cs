using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongInfo : MonoBehaviour {

	public string musicName;
	public GameObject musicList;
	public CSVReader musicData = new CSVReader (); // 曲データ

	void Start () {
		musicList = GameObject.Find("MusicName0");
		musicName = musicList.GetComponent<MusicName>().viewing;
		musicData.MusicDataRead (musicName);
	}

	void Update(){
		musicName = musicList.GetComponent<MusicName>().viewing;
		musicData.MusicDataRead (musicName);
		GetComponent<Text>().text = "                   Rank:" + (musicData.rank);
	}

}
