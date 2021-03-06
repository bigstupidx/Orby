﻿using UnityEngine;
using System.Collections;

public class gRecHintClass : MonoBehaviour {

	static public float recHintState = -1;
	static public string rec = "";
	static public int counter = 0;
	// Use this for initialization
	void Start () {
		if (recHintState != -1) gameObject.GetComponent<SpriteRenderer>().color = Color.red;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseClick () {
				Debug.Log ("start rec");

	}

	// Update is called once per frame
	void OnMouseUp () {
		Debug.Log("start rec");

		if (recHintState == -1) {
			Application.LoadLevel(Application.loadedLevel);
			counter = 0;
			recHintState = 0;
			rec = "";
		} else {
			recHintState = -1;
			gameObject.GetComponent<SpriteRenderer>().color = Color.white;
			Debug.Log("rec: ");
			Debug.Log(rec);
		}
	}

	public static void recHint(Transform tr) {
		if (recHintState != -1) {
			rec = rec + 		
				"\nactions[" + counter + "].id = new Vector3("+tr.position.x+"F, "+tr.position.y+"F, "+tr.position.z+"F);" +
				"\nactions[" + counter + "].time = "+(Time.unscaledTime - recHintState)+"F;" +
				"\nactions[" + counter + "].mouse = new Vector3("+Input.mousePosition.x+", "+Input.mousePosition.y+", "+Input.mousePosition.z+");";
			recHintState += Time.unscaledTime - recHintState;
			counter++;
		}
	}
}
