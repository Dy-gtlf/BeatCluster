using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public class CSVReader : MonoBehaviour {

	public List<string[]> csvDatas = new List<string[]>();
	public int height = 0;
	public float bpm;	// bpm
	public float offset;	// オフセット
	public float rhythm;	// 拍子
	public string by;	// 作成者
	public int rank;	// 難易度

	public void CsvRead (string musicName) {
		// csvをロード
		TextAsset csv = Resources.Load ("Measures/" + musicName) as TextAsset;
		StringReader reader = new StringReader (csv.text);
		while (reader.Peek () > -1) {
			// ','ごとに区切って配列へ格納
			string line = reader.ReadLine ();
			this.csvDatas.Add (line.Split (','));
			height++;
		}
	}

	public void MusicDataRead (string musicName) {
		// csvをロード
		TextAsset csv = Resources.Load ("Measures/" + musicName + "Data") as TextAsset;
		StringReader reader = new StringReader (csv.text);
		while (reader.Peek () > -1) {
			// ','ごとに区切って配列へ格納
			string line = reader.ReadLine ();
			string[] values = line.Split (',');
			this.bpm = float.Parse (values [0]);
			this.rhythm = float.Parse (values [1]);
			this.offset = float.Parse (values [2]);
			this.rank = int.Parse (values [3]);
			this.by = values [4];
		}
	}



}
