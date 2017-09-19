using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MusicNameList : MonoBehaviour {

	public string[] musicList;
	public int len;

	void Awake(){
		len = musicList.Length;
	}

}
