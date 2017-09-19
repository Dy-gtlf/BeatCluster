using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fadein : MonoBehaviour {

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
		FadeinScript();
	}

	public void FadeinScript(){
		if ( alfa >= 0 ) {
			alfa -= speed;
			GetComponent<Image>().color = new Color(red,blue,green,alfa);
		}
		if ( alfa < 0 ) {
			Destroy (this.gameObject);
		}
	}

}
