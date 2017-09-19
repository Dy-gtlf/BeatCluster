using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fadeout : MonoBehaviour {

	private GameObject parent;
	public float speed;
	public float red, blue, green, alfa;

	void Start(){
		red = GetComponent<Image>().color.r;
		blue = GetComponent<Image>().color.b;
		green = GetComponent<Image>().color.g;
		GetComponent<Image>().color = new Color(red,blue,green,alfa);
		parent = GameObject.Find("Fade");
		this.transform.parent = parent.transform;
		this.transform.position = parent.transform.position;
	}

	void Update(){
		FadeoutScript();
	}

	public void FadeoutScript(){
		if ( alfa <= 1 ) {
			alfa += speed;
			GetComponent<Image>().color = new Color(red,blue,green,alfa);
		}
	}

}
