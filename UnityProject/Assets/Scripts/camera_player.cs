using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_player : MonoBehaviour {

	private Camera cam;
	// Use this for initialization
	void Start () {
		cam = GetComponent<Camera> ();
		cam.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("c")) {
			cam.enabled = !cam.enabled;
		}
	}
}
