using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public string musicName;		// �Ȗ�
	public CSVReader musicData = new CSVReader (); // �ȃf�[�^
	private double timer = 0;	// �o�ߎ���
	private int height;		// ���ʂ̍s��
	private int lane;		// ���[���ʒu
	public int speed = 10;	// ���ʂ̑���
	public int beatLcm;


	// �I�u�W�F�N�g
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
		// �o�ߎ���
		timer += Time.deltaTime;
		mTimer += Time.deltaTime;
		if ( timer >= (musicData.bpm / 60f) / (float)(beatLcm) && musicData.height > 0) {
			NoteMake(height);
			// �ǂݍ��ލs���X�V
			height++;
			// �ǂݍ��ݎ��Ԃ����Z�b�g
			timer -= 60f / musicData.bpm / (float)(beatLcm / 4);
			// �c��̍s���X�V
			musicData.height--;
		}

		// ���U���g
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

	// �m�[�c����
	void NoteMake (int height) {
		// �ꏬ�߂��ƂɃ��C������
		if (height % (beatLcm / 4) == 0) {
			Instantiate (rhythmline,new Vector3 (0f,0.1f,75f), Quaternion.identity);
		}
		for (lane = 0; lane < 7; lane++) {
			// �f�[�^�̐��l�ŕ�����
			switch (musicData.csvDatas[height][lane]) {
			// Normal��lane�̈ʒu�ɐ���
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
