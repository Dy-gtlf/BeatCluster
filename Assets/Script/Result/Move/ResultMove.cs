using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ResultMove : MonoBehaviour {

	public float sx;
	public float sy;
	public float sz;
	private float x;
	private float y;
	private float z;
	public float time;

	private float scaleX;
	private float scaleY;
	private float scaleZ;
	public GameObject canvas;

	public float delay = 0f;

	void Start(){
		canvas = GameObject.Find("Canvas");
		// 比率取得
		scaleX = canvas.GetComponent<RectTransform>().localScale.x;
		scaleY = canvas.GetComponent<RectTransform>().localScale.y;
		scaleZ = canvas.GetComponent<RectTransform>().localScale.z;
		// 移動先(現在)座標
		x = GetComponent<RectTransform>().localPosition.x + canvas.GetComponent<RectTransform>().localPosition.x / scaleX;
		y = GetComponent<RectTransform>().localPosition.y + canvas.GetComponent<RectTransform>().localPosition.y / scaleY;
		z = GetComponent<RectTransform>().localPosition.z + canvas.GetComponent<RectTransform>().localPosition.z / scaleZ;
		// 移動前座標
		GetComponent<RectTransform>().localPosition = new Vector3(sx, sy, sz);
		// 移動
		Invoke("Move", delay);
	}

	void Move() {
		// 目的座標に移動
		GetComponent<RectTransform>().DOMove(new Vector3(x * scaleX, y * scaleY, z * scaleZ), time);
	}

}
