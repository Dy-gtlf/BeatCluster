using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public string musicName;		// 曲名
	public CSVReader musicData = new CSVReader (); // 曲データ
	private double timer = 0;	// 経過時間
	private int height;		// 譜面の行数
	private int lane;		// レーン位置
	public int speed = 10;	// 譜面の速さ
	public int beatLcm;


	// オブジェクト
	public GameObject mp; // MusicPlayer
	public MusicPlayer mpSc = new MusicPlayer(); // Script 
	public float mTimer = 0;
	public GameObject rhythmline;
	public GameObject[] normal = new GameObject[4];
	public GameObject[] miniNormal = new GameObject[8];

	public GameObject fadeout;
	public GameObject fadein;

	void Awake() {
		musicName = MusicName.selected;
	}

	void Start() {
		Instantiate (fadein);
		musicData.CsvRead (musicName);
		musicData.MusicDataRead (musicName);
		timer = musicData.offset;
		mpSc = mp.GetComponent<MusicPlayer>();
	}

	void Update () {
		// 経過時間
		timer += Time.deltaTime;
		mTimer += Time.deltaTime;
		if ( timer >= (musicData.bpm / 60f) / (float)(beatLcm) && musicData.height > 0) {
			NoteMake(height);
			// 読み込む行を更新
			height++;
			// 読み込み時間をリセット
			timer -= 60f / musicData.bpm / (float)(beatLcm / 4);
			// 残りの行を更新
			musicData.height--;
		}

		// リザルト
		// if ( mTimer - 3 > mpSc.musicLength ) { // mpSc.musicLength
		// 	Instantiate(fadeout);
		// 	StartCoroutine ("GoToNextScene");
		// }
		if ( mTimer - 3 > 10 ) { // mpSc.musicLength
			Instantiate(fadeout);
			StartCoroutine ("GoToNextScene");
		}

		if ( Input.GetKeyDown(KeyCode.Escape) ) {
			Instantiate(fadeout);
			// debug
			ScoreCounter.score = 114514;
			ScoreCounter.maxCombo = 810;
			ScoreCounter.perfect = 114;
			ScoreCounter.good = 514;
			ScoreCounter.nice = 810;
			ScoreCounter.bad = 19;
			ScoreCounter.miss = 19;
			StartCoroutine ("GoToNextScene");
		}
		if ( Input.GetKeyDown(KeyCode.A)) {
			Debug.Log(mTimer);
		}
	}

	// ノーツ生成
	void NoteMake (int height) {
		// 一小節ごとにライン生成
		if (height % (beatLcm / 4) == 0) {
			Instantiate (rhythmline,new Vector3 (0f,0.1f,75f), Quaternion.identity);
		}
		for (lane = 0; lane < 7; lane++) {
			// データの数値で分ける
			switch (musicData.csvDatas[height][lane]) {
			// Normalをlaneの位置に生成
			case "1":
				Instantiate (normal[lane / 2]);
				break;
			case "2":
				Instantiate (miniNormal[lane]);
				break;
			}
		}

	}

	IEnumerator GoToNextScene(){
		yield return new WaitForSeconds (1f);
		SceneManager.LoadScene ("Result");
	}

}
