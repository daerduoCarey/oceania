using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_spears_selector : MonoBehaviour {

	public static bool[] pick_or_not = new bool[4] { false, false, false, false };
	public int spear_id;

	private Vector3 small, big;

	// Use this for initialization
	void Start () {
		big = transform.localScale;
		small = transform.localScale * 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
		if (pick_or_not [spear_id]) {
			transform.localScale = big;
		} else {
			transform.localScale = small;
		}
	}
}
