using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class alert_text_manager : MonoBehaviour {

	public static string alert_message;
	Text text;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
		alert_message = "";
	}
	
	// Update is called once per frame
	void Update () {
		text.text = alert_message;
	}
}
