using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class ScoreCounter : MonoBehaviour {

	public static int score = 0;
	public static int perfect = 0;
	public static int good = 0;
	public static int nice = 0;
	public static int bad = 0;
	public static int miss = 0;
	public static int maxCombo = 0;
	public int combo = 0;
	private int p_score = 0;
	private int p_perfect = 0;
	private int p_good = 0;
	private int p_nice = 0;
	private int p_bad = 0;
	private int p_miss = 0;
	private int p_combo = 0;

	public GameObject combo3d;
	public TextMesh combo3dTm = new TextMesh();
	public GameObject score3d;
	public TextMesh score3dTm = new TextMesh();
	public GameObject eva;
	public TextMesh evaTm = new TextMesh();
	Renderer rd;


	void Start () {
		score = 0;
		perfect = 0;
		good = 0;
		nice = 0;
		bad = 0;
		miss = 0;
		maxCombo = 0;
		combo = 0;
		p_score = 0;
		p_perfect = 0;
		p_good = 0;
		p_nice = 0;
		p_bad = 0;
		p_miss = 0;
		p_combo = 0;
		combo3d = GameObject.Find ("Combo3d");
		combo3dTm = combo3d.GetComponent ("TextMesh").GetComponent<TextMesh>();
		eva = GameObject.Find ("Evaluation");
		evaTm = eva.GetComponent ("TextMesh").GetComponent<TextMesh>();
		score3d = GameObject.Find ("Score3d");
		score3dTm = score3d.GetComponent ("TextMesh").GetComponent<TextMesh>();
		rd = eva.gameObject.GetComponent<Renderer> ();
	}

	void Update () {
		if (score > p_score) {
			p_score = score;
			score3dTm.text = "Score " + score;
			ScoreAddEffect();
		}
		if (perfect > p_perfect) {
			p_perfect = perfect;
			evaTm.text = "Perfect!";
			evaTm.color = new Color (255f/255f,75f/255f,200f/255f);
			EvaAddEffect();
			rd.enabled = true;
		}
		if (good > p_good) {
			p_good = good;
			evaTm.text = "Good!";
			evaTm.color = new Color (255f/255f,130f/255f,0f/255f);
			EvaAddEffect();
			rd.enabled = true;
		}
		if (nice > p_nice) {
			p_nice = nice;
			evaTm.text = "Nice!";
			evaTm.color = new Color (255f/255f,255f/255f,60f/255f);
			EvaAddEffect();
			rd.enabled = true;
		}
		if (bad > p_bad) {
			p_bad = bad;
			if (maxCombo < combo) {
				maxCombo = combo;
			}
			combo = 0;
			evaTm.text = "Bad!";
			evaTm.color = new Color (60f/255f,125f/255f,255f/255f);
			EvaAddEffect();
			rd.enabled = true;
		}
		if (miss > p_miss) {
			p_miss = miss;
			if (maxCombo < combo) {
				maxCombo = combo;
			}
			combo = 0;
			evaTm.text = "Miss!";
			evaTm.color = new Color (0f/255f,255f/255f,50f/255f);
			EvaAddEffect();
			rd.enabled = true;
		}
		if (combo != p_combo) {
			p_combo = combo;
			combo3dTm.text = "Combo " + combo;
			ComboAddEffect();
			rd.enabled = true;
		}
	}
	
	public void addPerfect() {
		perfect++;
		combo++;
		score += 100;
	}

	public void addGood(){
		good++;
		combo++;
		score += 70;
	}

	public void addNice(){
		nice++;
		combo++;
		score += 50;
	}

	public void addBad(){
		bad++;
		combo = 0;
		score += 10;
	}

	public void addmiss(){
		miss++;
	}

	void EvaAddEffect() {
		eva.transform.position = new Vector4(-20f,7f,-63f);
		eva.transform.DOMove(new Vector3(-23f,7f,-61f),0.1f);
		//eva.transform.localScale = new Vector3 (1.5f,1.5f,1.5f);
		//eva.transform.DOScale(new Vector3(1f,1f,1f), 0.2f);
	}

	void ScoreAddEffect() {
		score3d.transform.position = new Vector4(-20f,10f,-63f);
		score3d.transform.DOMove(new Vector3(-23f,10f,-61f),0.1f);
		//score3d.transform.localScale = new Vector3 (1.5f,1.5f,1.5f);
		//score3d.transform.DOScale(new Vector3(1f,1f,1f), 0.2f);
	}

	void ComboAddEffect() {
		combo3d.transform.position = new Vector4(14f,7f,-42f);
		combo3d.transform.DOMove(new Vector3(17f,7f,-40f),0.1f);
		//combo3d.transform.localScale = new Vector3 (1.5f,1.5f,1.5f);
		//combo3d.transform.DOScale(new Vector3(1f,1f,1f), 0.2f);
	}

}
